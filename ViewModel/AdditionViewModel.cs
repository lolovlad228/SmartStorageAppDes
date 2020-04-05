using SmartSorage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartSorage.ViewModel
{
    class AdditionViewModel:PropertyChange
    {
        public Action CloseAct;


        private Goods _selectGoods;
        public ICommand CloseWindow { get; private set; }

        public Goods SelectGoods
        {
            get { return _selectGoods; }
            set
            {
                _selectGoods = value;
                OnPropertyChangr("SelectGoods");
            }
        }

        public AdditionViewModel(Goods ParamGoods)
        {
            SelectGoods = ParamGoods;

            CloseWindow = new DelegetCommand(Closeu, (obj) => false);
        }

        private void Closeu(object param)
        {
            CloseAct();
        }

    }
}
