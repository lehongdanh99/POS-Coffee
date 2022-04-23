using Caliburn.Micro;
using CoffeePos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoffeePos.Models.ReceiptModel;

namespace CoffeePos.ViewModels
{
    internal class ListOrderViewModel : Screen
    {
        private static ListOrderViewModel _instance;
        public static ListOrderViewModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new ListOrderViewModel();
                }
            }
            return _instance;
        }
        public ListOrderViewModel()
        {
            //ListOrders = getListOrders();
            ListReceipts = ReceiptModel.GetInstance().ListReceipt;
            
        }

        //private ObservableCollection<Receipt> getListOrders()
        //{
        //    return new ObservableCollection<Receipt>()
        //    {
        //        new Receipt()
        //    }
        //}

        public void AddListReceipt(Receipt receipt)
        {
            ListReceipts.Add(receipt);
            NotifyOfPropertyChange(() => ListReceipts);
        }

        private ObservableCollection<Receipt> listReceipts = ReceiptModel.GetInstance().ListReceipt;

        public ObservableCollection<Receipt> ListReceipts
        {
            get { return listReceipts; }
            set { listReceipts = value; NotifyOfPropertyChange(() => ListReceipts); }
        }

        public void ViewDetailReceipt (Receipt receipt)
        {
            TableDetailViewModel tableDetailViewModel = new TableDetailViewModel(receipt, false);
            //tableDetailViewModel.eventChange += HandleCallBack;

            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(tableDetailViewModel);
        }

        public void PaymentReceipt(Receipt receipt)
        {
            PaymentViewModel paymentViewModel = new PaymentViewModel();
            //tableDetailViewModel.eventChange += HandleCallBack;

            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(paymentViewModel);
            //RegisterViewModel registerViewModel = new RegisterViewModel();
            //WindowManager windowManager = new WindowManager();
            //windowManager.ShowDialogAsync(registerViewModel);
        }

    }
}
