using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Input;

using SmartSorage.Model;
using SmartSorage.View;

namespace SmartSorage.ViewModel
{
    class GoodsViewModel:PropertyChange
    {

        private DataContext _mainDataContext;

        private IEnumerable<Goods> _goodsItemList;
        private Goods _selectItemGoods;
        public ICommand AddGoodsCommad { get; private set; }
        public ICommand EdutGoodsCommand { get; private set; }
        public ICommand DeleteGoodsCommand { get; private set; }

        public IEnumerable<Goods> GoodsItemList
        {
            get
            {
                return _goodsItemList;
            }
            set
            {
                _goodsItemList = value;
                OnPropertyChangr("GoodsItemList");
            }
        }

        public Goods SelectItemGoods {
            get
            {
                return _selectItemGoods;
            }
            set
            {
                _selectItemGoods = value;
                OnPropertyChangr("SelectItemGoods");
            }
        }

        public GoodsViewModel()
        {

            _mainDataContext = new DataContext();
            _mainDataContext.Goods.Load();

            GoodsItemList = _mainDataContext.Goods.Local.ToBindingList();
            AddGoodsCommad = new DelegetCommand(AddGoodsCommandEv);
            DeleteGoodsCommand = new DelegetCommand(DeleteGoodsCommandEv, IsGoodsCommands);
            EdutGoodsCommand = new DelegetCommand(EditGoodsCommandEv, IsGoodsCommands);
        }


        private void AddGoodsCommandEv(object parametr)
        {
            AddGoodsViewModel addGoodsViewModel = new AddGoodsViewModel(_mainDataContext);
            AddWindow DialogWin = new AddWindow();
            DialogWin.DataContext = addGoodsViewModel;
            if (addGoodsViewModel.CloseAct == null)
                addGoodsViewModel.CloseAct = new Action(() => DialogWin.Close());

            DialogWin.ShowDialog();
        }

        private void DeleteGoodsCommandEv(object parametr)
        {
            Goods SelGoods = parametr as Goods;
            _mainDataContext.Goods.Remove(SelGoods);
            _mainDataContext.SaveChanges();
        }

        private void EditGoodsCommandEv(object parametr)
        {
            
            EditeGoodsViewModel editGoodsViewModel = new EditeGoodsViewModel(SelectItemGoods, _mainDataContext);
            AddWindow DialogWin = new AddWindow();
            DialogWin.DataContext = editGoodsViewModel;
            if (editGoodsViewModel.CloseAct == null)
                editGoodsViewModel.CloseAct = new Action(() => DialogWin.Close());

            DialogWin.ShowDialog();
        }

        private bool IsGoodsCommands(object parametr)
        {
            if (SelectItemGoods == null)
                return false;
            return true;
        }

    }
}
