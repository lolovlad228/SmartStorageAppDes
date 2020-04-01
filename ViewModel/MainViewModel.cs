using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

using SmartSorage.View.Pages;

namespace SmartSorage.ViewModel
{
    class MainViewModel : PropertyChange
    {

        private Page _goodsPage;
        private Page _stateStoragePage;
        private Page _stateRobotPage;
        private Page _stateBoxPage;
        private Page _documentPage;
        private Page _currentPage;
        public ICommand SelectPage { get; private set; }
        public Page GoodsPage
        {
            get { return _goodsPage; }
            set
            {
                _goodsPage = value;
                OnPropertyChangr("GoodsPage");
            }
        }
        public Page StateStoragePage
        {
            get { return _stateStoragePage; }
            set
            {
                _stateStoragePage = value;
                OnPropertyChangr("StateStorage");
            }
        }
        public Page StateRobotPage
        {
            get { return _stateRobotPage; }
            set
            {
                _stateRobotPage = value;
                OnPropertyChangr("StateRobot");
            }
        }
        public Page DocumentPage
        {
            get { return _documentPage; }
            set
            {
                _documentPage = value;
                OnPropertyChangr("Document");
            }
        }
        public Page StateBoxPage
        {
            get { return _stateBoxPage; }
            set
            {
                _stateBoxPage = value;
                OnPropertyChangr("StateBox");
            }
        }

        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnPropertyChangr("CurrentPage");
            }
        }
        public MainViewModel()
        {

            GoodsPage = new Goods();
            StateStoragePage = new StateStorage();
            StateRobotPage = new StateRobot();
            DocumentPage = new Document();
            StateBoxPage = new StateBox();

            SelectPage = new DelegetCommand(SelCom);

            CurrentPage = GoodsPage;

        }

        private void SelCom(object parametr)
        {
            Page PageCur = parametr as Page;
            CurrentPage = PageCur;
        }
    }
}
