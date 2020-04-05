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

using SmartSorage.Class;
using System.Windows;

namespace SmartSorage.ViewModel
{
    class AddGoodsViewModel:PropertyChange
    {

        public DataContext DataContextInfo;
        public Action CloseAct { get; set; }

        private CsvInterfase _csvFile;
        private string _selectSeassons;
        private List<string> _listSeassons;
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
        public string SelectSeassons
        {
            get { return _selectSeassons; }
            set
            {
                _selectSeassons = value;
                OnPropertyChangr("SelectSeassons");
            }
        }

        public List<string> ListSeassons
        {
            get { return _listSeassons; }
            set
            {
                _listSeassons = value;
                OnPropertyChangr("ListSeassons");
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
            ListSeassons = new List<string>()
            {
                "winter",
                "spring",
                "summer",
                "autumn",
                "none"
            };

            DataContextInfo = data;

            _csvFile = new CsvInterfase();

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
                NewGoods.Img = ImageAplication.ConvertToByte(new System.Drawing.Bitmap(FileDialog.FileName));
                ImgSourse = NewGoods.Img;
            }
        }

        private void AddGoods(object parametr)
        {
            NewGoods.DateReg = DateTime.Now;
            NewGoods.QrImg = ImageAplication.GenerateQrCode(NewGoods.Name, 5);
            NewGoods.Seassons = SelectSeassons;

            _csvFile.PathFile = NewGoods.Name;
            _csvFile.SaveCsv(NewGoods.Prise);

            DataContextInfo.Goods.Add(NewGoods);
            DataContextInfo.SaveChanges();
            NewGoods = new Goods();
            ImgSourse = null;
        }

        private void CloseWindow(object parametr)
        {
            CloseAct();
        }

    }
}
