using SmartSorage.Class;
using SmartSorage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SmartSorage.ViewModel
{
    class EditeGoodsViewModel:PropertyChange
    {

        public DataContext DataContextInfo;
        public Action CloseAct { get; set; }

        private Goods _newGoods;
        private byte[] _imgSourse;

        public byte[] ImgSourse
        {
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
        public EditeGoodsViewModel(Goods NowGoods, DataContext data)
        {
            NewGoods = NowGoods;
            ImgSourse = NewGoods.Img;

            DataContextInfo = data;

            LoadFileCommand = new DelegetCommand(LoadFile);
            CloseWindowCommand = new DelegetCommand(CloseWindow);
            EntryGoodsCommand = new DelegetCommand(EditGoods);
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

        private void CloseWindow(object parametr)
        {
            CloseAct();
        }

        private void EditGoods(object parametr)
        {

            DataContextInfo.SaveChanges();

        }
    }
}
