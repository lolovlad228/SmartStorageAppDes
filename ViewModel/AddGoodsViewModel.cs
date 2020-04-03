using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using SmartSorage.Model;
using System.Data.Entity;
using QRCoder;
using SmartSorage.Class;

namespace SmartSorage.ViewModel
{
    class AddGoodsViewModel:PropertyChange
    {

        public DataContext DataContextInfo;
        public Action CloseAct { get; set; }

        private Goods _newGoods;
        private byte[] _imgSourse;

        public byte[] ImgSourse {
            get { return _imgSourse; }
            set
            {
                _imgSourse = value;
                OnPropertyChangr("ImgSourse");
            }
        }

        public ICommand LoadFileCommand { get; private set; }
        public ICommand CloseWindowCommand { get; private set; }
        public ICommand EntryGoodsCommand { get; private set; }
        public Goods NewGoods
        {
            get
            {
                return _newGoods;
            }
            set
            {
                _newGoods = value;
                OnPropertyChangr("NewGoods");
            }
        }

        public AddGoodsViewModel(DataContext data)
        {
            NewGoods = new Goods();

            DataContextInfo = data;

            LoadFileCommand = new DelegetCommand(LoadFile);
            CloseWindowCommand = new DelegetCommand(CloseWindow);
            EntryGoodsCommand = new DelegetCommand(AddGoods);
        }

        private void LoadFile(object parametr)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.Filter = "jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            FileDialog.Title = "LoadImage";
            FileDialog.FilterIndex = 1;

            if (FileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                NewGoods.Img = ImageConver.ConvertToByte(new System.Drawing.Bitmap(FileDialog.FileName));
                ImgSourse = NewGoods.Img;
            }
        }

        private void AddGoods(object parametr)
        {
            NewGoods.DateReg = DateTime.Now;
            QRCodeGenerator GoodsQrCode = new QRCodeGenerator();
            QRCodeData qRCodeData = GoodsQrCode.CreateQrCode(NewGoods.Name, QRCodeGenerator.ECCLevel.Q);
            QRCode GoodsCode = new QRCode(qRCodeData);
            NewGoods.QrImg = ImageConver.ConvertToByte(GoodsCode.GetGraphic(5));

            DataContextInfo.Goods.Add(NewGoods);
            DataContextInfo.SaveChanges();
            
        }

        private void CloseWindow(object parametr)
        {
            CloseAct();
        }

    }
}
