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

            Initialize();
        }

        public void getDataListOrder()
        {
            BackgroundShowList = new SolidColorBrush(Colors.White);
            BackgroundShowListDone = new SolidColorBrush(Colors.DarkSlateGray);
            VisibilityReceiptDone = Visibility.Hidden;
            VisibilityReceipt = Visibility.Visible;
            ListReceipts = ReceiptModel.GetInstance().ListReceipt;

            ListReceiptsDone.Clear();


            foreach (ReceiptDone receipt in RestAPIClient<ReceiptDone>.parseJsonToModel(GlobalDef.RECEIPTDONE_API))
            {
                //bool check = false;
                //foreach (ReceiptDone receiptCheck in ListReceiptsDone)
                //{
                //    if(receiptCheck == receipt)
                //    {
                //        check = true;
                //    }   
                //}
                //if (!check)
                //{
                    ListReceiptsDone.Add(receipt);
                //}    
            }
        }

        public void Initialize()
        {
            BackgroundShowList = new SolidColorBrush(Colors.White);
            BackgroundShowListDone = new SolidColorBrush(Colors.DarkSlateGray);
            VisibilityReceiptDone = Visibility.Hidden;
            VisibilityReceipt = Visibility.Visible;
            ListReceipts = ReceiptModel.GetInstance().ListReceipt;



            foreach (ReceiptDone receipt in RestAPIClient<ReceiptDone>.parseJsonToModel(GlobalDef.RECEIPTDONE_API))
            {
                bool check = false;
                foreach (ReceiptDone receiptCheck in RestAPIClient<ReceiptDone>.parseJsonToModel(GlobalDef.RECEIPTDONE_API))
                {
                    if (receiptCheck == receipt)
                    {
                        check = true;
                    }
                }
                if (!check)
                {
                    ListReceiptsDone.Add(receipt);
                }
                else
                {
                    break;
                }

            }
        }

        private Receipt ReceiptSelected;

        private ReceiptDone ReceiptSelectedDone;
        private Visibility visibilityReceiptDone;

        public Visibility VisibilityReceiptDone
        {
            get { return visibilityReceiptDone; }
            set { visibilityReceiptDone = value;
                NotifyOfPropertyChange(() => VisibilityReceiptDone);
            }
        }

        private Visibility visibilityReceipt;

        public Visibility VisibilityReceipt
        {
            get { return visibilityReceipt; }
            set
            {
                visibilityReceipt = value;
                NotifyOfPropertyChange(() => VisibilityReceipt);
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
            BackgroundShowListDone = new SolidColorBrush(Colors.DarkSlateGray);
            ListReceipts = ReceiptModel.GetInstance().ListReceipt;
            VisibilityReceiptDone = Visibility.Hidden;
            VisibilityReceipt = Visibility.Visible;
            NotifyOfPropertyChange(() => ListReceipts);
            NotifyOfPropertyChange(() => VisibilityReceiptDone);
        }

        public void btnShowListReceiptDone()
        {
            BackgroundShowList = new SolidColorBrush(Colors.DarkSlateGray);
            BackgroundShowListDone = new SolidColorBrush(Colors.White);
            ListReceipts = ReceiptModel.GetInstance().ListReceiptDone;
            VisibilityReceiptDone = Visibility.Visible;
            VisibilityReceipt=Visibility.Hidden;
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

        private ObservableCollection<ReceiptDone> listReceiptsDone = new ObservableCollection<ReceiptDone>();

        public ObservableCollection<ReceiptDone> ListReceiptsDone
        {
            get { return listReceiptsDone; }
            set { listReceiptsDone = value; NotifyOfPropertyChange(() => ListReceiptsDone); }
        }

        public void ViewDetailReceipt (Receipt receipt , bool isDone)
        {
            GlobalDef.ReceiptDetail = receipt;
            GlobalDef.canEditDetail = isDone;
            //TableDetailViewModel tableDetailViewModel = new TableDetailViewModel();
            //tableDetailViewModel.eventChange += HandleCallBack;
            
            ReceiptSelected = receipt;
            TableDetailViewModel.GetInstance().getdataTableDetail();
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowDialogAsync(TableDetailViewModel.GetInstance());
        }

        public void ViewDetailReceiptDone(ReceiptDone receipt)
        {
            //GlobalDef.ReceiptDetail = receipt;
            //GlobalDef.canEditDetail = isDone;
            //TableDetailViewModel tableDetailViewModel = new TableDetailViewModel();
            //tableDetailViewModel.eventChange += HandleCallBack;
            GlobalDef.IsPaymentClick = false;
            GlobalDef.ReceiptDoneDetail = receipt;
            ReceiptReportViewModel.GetInstance().ClearDataReport();
            ReceiptReportViewModel.GetInstance().getDataDone();
            GlobalDef.windowManager.ShowDialogAsync(ReceiptReportViewModel.GetInstance());
        }

        public void PaymentReceipt(Receipt receipt)
        {
            GlobalDef.ReceiptPayment = receipt;
            //PaymentViewModel paymentViewModel = new PaymentViewModel(receipt);
            //tableDetailViewModel.eventChange += HandleCallBack;
            PaymentViewModel.GetInstance().getDataPayment();
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowDialogAsync(PaymentViewModel.GetInstance());
            
            
            //RegisterViewModel registerViewModel = new RegisterViewModel();
            //WindowManager windowManager = new WindowManager();
            //windowManager.ShowDialogAsync(registerViewModel);
        }

        //public void RemoveFoodInReceipt(FoodOrder foodOrder)
        //{
        //    if(ReceiptSelected != null)
        //    {
        //        ReceiptSelected.Foods.Remove(foodOrder);
        //    }
        //}
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
