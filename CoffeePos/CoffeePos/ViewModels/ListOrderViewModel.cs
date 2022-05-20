using Caliburn.Micro;
using CoffeePos.Common;
using CoffeePos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
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

        private Receipt ReceiptSelected;
        private Visibility visibilityReceiptDone;

        public Visibility VisibilityReceiptDone
        {
            get { return visibilityReceiptDone; }
            set { visibilityReceiptDone = value;
                NotifyOfPropertyChange(() => VisibilityReceiptDone);
            }
        }

        private SolidColorBrush backgroundShowListDone;
        public SolidColorBrush BackgroundShowListDone
        {
            get { return backgroundShowListDone; }
            set { backgroundShowListDone = value;
                NotifyOfPropertyChange(() => BackgroundShowListDone);
            }
        }

        private SolidColorBrush backgroundShowList;
        public SolidColorBrush BackgroundShowList
        {
            get { return backgroundShowList; }
            set
            {
                backgroundShowList = value;
                NotifyOfPropertyChange(() => BackgroundShowList);
            }
        }


        public void btnShowListReceipt()
        {
            //this.Hide();
            BackgroundShowList = new SolidColorBrush(Colors.White);
            BackgroundShowListDone = new SolidColorBrush(Colors.Orange);
            ListReceipts = ReceiptModel.GetInstance().ListReceipt;
            VisibilityReceiptDone = Visibility.Visible;
            NotifyOfPropertyChange(() => ListReceipts);
            NotifyOfPropertyChange(() => VisibilityReceiptDone);
        }

        public void btnShowListReceiptDone()
        {
            BackgroundShowList = new SolidColorBrush(Colors.Orange);
            BackgroundShowListDone = new SolidColorBrush(Colors.White);
            ListReceipts = ReceiptModel.GetInstance().ListReceiptDone;
            VisibilityReceiptDone = Visibility.Hidden;
            NotifyOfPropertyChange(() => ListReceipts);
            NotifyOfPropertyChange(() => VisibilityReceiptDone);
        }

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
            TableDetailViewModel tableDetailViewModel = new TableDetailViewModel(receipt, true);
            //tableDetailViewModel.eventChange += HandleCallBack;
            GlobalDef.DetailFromHome = Visibility.Visible;
            ReceiptSelected = receipt;
            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(tableDetailViewModel);
        }

        public void PaymentReceipt(Receipt receipt)
        {
            GlobalDef.ReceiptPayment = receipt;
            //PaymentViewModel paymentViewModel = new PaymentViewModel(receipt);
            //tableDetailViewModel.eventChange += HandleCallBack;

            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(PaymentViewModel.GetInstance());
            PaymentViewModel.GetInstance().getDataPayment();
            this.TryCloseAsync();
            //RegisterViewModel registerViewModel = new RegisterViewModel();
            //WindowManager windowManager = new WindowManager();
            //windowManager.ShowDialogAsync(registerViewModel);
        }

        public void RemoveFoodInReceipt(FoodOrder foodOrder)
        {
            if(ReceiptSelected != null)
            {
                ReceiptSelected.Foods.Remove(foodOrder);
            }
        }
        //public void CompleteFoodInReceipt(FoodOrder foodOrder)
        //{
        //    if (ReceiptSelected != null)
        //    {
        //        foreach(var food in ReceiptSelected.Foods)
        //        {
        //            if(food == foodOrder)
        //            {
        //                food.IsDoneFood = true;
        //                break;
        //            }
        //        }
        //    }
        //}

    }
}
