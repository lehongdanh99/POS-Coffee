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
using static CoffeePos.FoodOrderModel;
using static CoffeePos.Models.ReceiptModel;

namespace CoffeePos.ViewModels
{
    internal class TableDetailViewModel : Screen
    {

        public TableDetailViewModelEvent eventSwitchTableCallBack;
        public delegate void TableDetailViewModelEvent(int SelectedTable);

        private static TableDetailViewModel _instance;
        public static TableDetailViewModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new TableDetailViewModel();
                }
            }
            return _instance;
        }

        public TableDetailViewModel()
        {
            getdataTableDetail();
        }
        public void getdataTableDetail()
        {
            //GlobalDef.ReceiptDetail = receipt;
            ListFoodOrder = GlobalDef.ReceiptDetail.Foods;
            TableNumOrder = GlobalDef.ReceiptDetail.Table;
            PaymentOrder = GlobalDef.ReceiptDetail.Payment;
            TotalOrder = GlobalDef.ReceiptDetail.TotalPrice;
            DiscountOrder = GlobalDef.ReceiptDetail.DiscountPrice.value;
            CanEdit = GlobalDef.canEditDetail;
            checkServed();
        }

        bool isAllServed = false;

        public bool IsAllServed
        {
            get { return isAllServed; }
            set { isAllServed = value;
                NotifyOfPropertyChange(() => IsAllServed);
            }
        }

        bool canSwitch = false;

        public bool CanSwitch
        {
            get { return canSwitch; }
            set
            {
                canSwitch = value;
                NotifyOfPropertyChange(() => CanSwitch);
            }
        }

        private bool CanEdit;

        private Visibility detailFromHome;

        public Visibility DetailFromHome
        {
            get { return GlobalDef.DetailFromHome; }
            set { detailFromHome = value; }
        }

        private Visibility visibleCanEdit;
        public Visibility VisibleCanEdit
        {
            get 
            {
                if(CanEdit)
                {
                    GlobalDef.DetailTable = Visibility.Visible;
                    return Visibility.Visible;
                }
                    
                else
                {
                    GlobalDef.DetailTable = Visibility.Collapsed;
                    return Visibility.Collapsed;
                }
            }
            set 
            {
                visibleCanEdit = value;
                NotifyOfPropertyChange(() => VisibleCanEdit);
            }
        }

        private Visibility visibleShow;
        public Visibility VisibleShow
        {
            get
            {
                if (!CanEdit)
                {
                    GlobalDef.DetailTable = Visibility.Visible;
                    return Visibility.Visible;
                }

                else
                {
                    GlobalDef.DetailTable = Visibility.Collapsed;
                    return Visibility.Collapsed;
                }
            }
            set { visibleShow = value; }
        }
        private List<FoodOrder> listfoodOrder;

        public List<FoodOrder> ListFoodOrder
        {
            get { return listfoodOrder; }
            set { listfoodOrder = value; NotifyOfPropertyChange(() => ListFoodOrder); }
        }

        private string tableNumOrder;

        public string TableNumOrder
        {
            get { return tableNumOrder; }
            set
            {
                tableNumOrder = value;
                NotifyOfPropertyChange(() => TableNumOrder);
            }
        }

        private double paymentOrder;

        public double PaymentOrder
        {
            get { return paymentOrder; }
            set { 
                paymentOrder = value;
                NotifyOfPropertyChange(() => PaymentOrder);
            }
        }

        private double totalOrder;

        public double TotalOrder
        {
            get { return totalOrder; }
            set
            {
                totalOrder = value;
                NotifyOfPropertyChange(() => TotalOrder);
            }
        }

        private int discountOrder;

        public int DiscountOrder
        {
            get { return discountOrder; }
            set
            {
                discountOrder = value;
                NotifyOfPropertyChange(() => DiscountOrder);
            }
        }

        private bool enableRemoveBtn;
        public bool EnableDeleteReceiptBtn
        {
            get { return enableRemoveBtn; }
            set
            {
                enableRemoveBtn = value;
                NotifyOfPropertyChange(() => EnableDeleteReceiptBtn);
            }
        }

        //public void SwtitchTable()
        //{
        //    eventSwitchTableCallBack.Invoke(TableNumOrder);
        //    //TablesViewModel tableViewModel = new TablesViewModel(true);
            
        //    TablesViewModel.GetInstance().eventChooseTableToOrder += HandleCallBacChooseTable;
        //    //WindowManager windowManager = new WindowManager();
        //    //windowManager.ShowDialogAsync(tableViewModel);
        //}
        //public void HandleCallBacChooseTable(int TableChoose)
        //{
        //    TableNumOrder = TableChoose;
        //    NotifyOfPropertyChange(() => TableNumOrder);
        //}

        public void BtnServedFood()
        {
            foreach(var food in ListFoodOrder)
            {
                if(!food.ServedFood)
                {
                    IsAllServed = false;
                    food.ServedFood = true;
                }
            } 

            if(IsAllServed)
            {
                foreach(var food in ListFoodOrder)
                {
                    if(food.IsEnable)
                    {
                        food.ServedFood = false;
                    }
                    
                }
                IsAllServed = false;
            }
            else
            {
                IsAllServed = true;
            }
        }

        public void BtnDeleteFood()
        {
            MessageBoxViewModel messageBoxViewModel;
            foreach (var food in ListFoodOrder)
            {
                if (food.ServedFood)
                {
                    messageBoxViewModel = new MessageBoxViewModel("Không thể hủy đơn");
                    //WindowManager windowManager = new WindowManager();
                    GlobalDef.windowManager.ShowDialogAsync(messageBoxViewModel);
                    return;
                }

            }
            
                messageBoxViewModel = new MessageBoxViewModel("Xác nhận hủy đơn");
                //WindowManager windowManager = new WindowManager();
                GlobalDef.windowManager.ShowDialogAsync(messageBoxViewModel);
                return;
            

            
        }

        public void BtnEditFood()
        {
            TableDetailViewModel.GetInstance().TryCloseAsync();
            //HomeViewModel.GetInstance().TryCloseAsync();
            TablesViewModel.GetInstance().TryCloseAsync();
            ListOrderViewModel.GetInstance().TryCloseAsync();
            HomeViewModel.GetInstance().IsEditting = false;
            foreach(var food in ListFoodOrder)
            {
                FoodOrderModel.GetInstance().FoodOrders.Add(food);
            }
            List<int> listTable = TableNumOrder.Split(',').Select(Int32.Parse).ToList();
            if(listTable.Count > 1)
            {
                foreach (var table in listTable)
                {
                    TablesViewModel.GetInstance().TablesAllList[table - 1].TableStatus = false;
                    TablesViewModel.GetInstance().TablesAllList[table - 1].IsCheckChoose = Visibility.Visible;
                }
            }
            else
            {
                TablesViewModel.GetInstance().TablesAllList[listTable[0]].TableStatus = false;
            }
            HomeViewModel.GetInstance().TableNum = TableNumOrder;
            HomeViewModel.GetInstance().ReceiptIdtoEdit = GlobalDef.ReceiptDetail.Id;
            HomeViewModel.GetInstance().DiscountOrder = DiscountOrder;
            HomeViewModel.GetInstance().voucherToOrder = GlobalDef.ReceiptDetail.DiscountPrice;
            HomeViewModel.GetInstance().getDataHome();
            //GlobalDef.windowManager.ShowDialogAsync(HomeViewModel.GetInstance());
        }

        public void checkServed()
        {
            IsAllServed = true;
            CanSwitch = false;
            foreach (var food in ListFoodOrder)
            {
                if (!food.ServedFood)
                {
                    IsAllServed = false;
                }
                if (food.IsEnable)
                {
                    CanSwitch = true;
                }

            }
        }

        public void BtnChooseDiscount()
        {
            HomeViewModel.GetInstance().btListVoucher_Click();
        }

        public void btnPaymentReceipt()
        {

            Receipt ReceiptTest = new Receipt();
            ReceiptTest.Foods = ListFoodOrder.ToList();
            ReceiptTest.Table = TableNumOrder.ToString();
            ReceiptTest.TotalPrice = TotalOrder;
            ReceiptTest.DiscountPrice = GlobalDef.ReceiptDetail.DiscountPrice;
            ReceiptTest.Payment = PaymentOrder;
            ReceiptTest.CheckOut = DateTime.Now.ToString("HH:mm");
            ReceiptTest.CheckIn = DateTime.Now.ToString("HH:mm");
            ReceiptTest.Note = string.Empty;
            
            GlobalDef.ReceiptPayment = ReceiptTest;
            PaymentViewModel.GetInstance().getDataPayment();
            ListOrderViewModel.GetInstance().PaymentReceipt(ReceiptTest);
            this.TryCloseAsync();
        }


        public void btnAddFoods()
        {
            foreach(var food in ListFoodOrder)
            HomeViewModel.GetInstance().ListViewFoodOrders.ToList().Add(food);
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowDialogAsync(HomeViewModel.GetInstance());
            HomeViewModel.GetInstance().GetFoodOrderTotal();
            this.TryCloseAsync();
        }

        public void CheckIsEnableServe()
        {
            foreach (var food in ListFoodOrder)
            {
                if(food.ServedFood)
                {
                    food.IsEnable = false;
                }
                else
                {
                    food.IsEnable = true;
                }
            }
        }

        public void btnConfirmReceipt()
        {
            CheckIsEnableServe();
            Receipt ReceiptTest = new Receipt();
            //WindowManager windowManager = new WindowManager();
            ReceiptTest = GlobalDef.ReceiptDetail;
            ReceiptTest.Foods = ListFoodOrder.ToList();
            ReceiptTest.Table = TableNumOrder.ToString();
            ReceiptTest.TotalPrice = TotalOrder;
            ReceiptTest.DiscountPrice = GlobalDef.ReceiptDetail.DiscountPrice;
            ReceiptTest.Payment = PaymentOrder;
            ReceiptTest.CheckOut = DateTime.Now.ToString("HH:mm");
            ReceiptTest.CheckIn = DateTime.Now.ToString("HH:mm");
            ReceiptTest.Note = string.Empty;
            HomeViewModel.GetInstance().IsEditting = true;
            foreach (Receipt receipt in ReceiptModel.GetInstance().ListReceipt)
            {
                try
                {
                    if (receipt.Id == GlobalDef.ReceiptDetail.Id && GlobalDef.ReceiptDetail.Id != 0)
                    {
                        foreach (var table in receipt.Table.Split(',').Select(Int32.Parse).ToList())
                        {
                            TablesViewModel.GetInstance().TablesAllList[table - 1].TableStatus = false;
                        }
                        //TablesViewModel.GetInstance().TablesAllList[Int32.Parse(receipt.Table)].TableStatus = false;
                        foreach (var table in TableNumOrder.Split(',').Select(Int32.Parse).ToList())
                        {
                            TablesViewModel.GetInstance().TablesAllList[table - 1].TableStatus = true;
                            TablesViewModel.GetInstance().TablesAllList[table - 1].IsCheckChoose = Visibility.Collapsed;
                        }


                        ReceiptModel.GetInstance().ListReceipt[receipt.Id - 1] = ReceiptTest;
                        this.TryCloseAsync(true);
                        HomeViewModel.GetInstance().ReceiptIdtoEdit = 0;
                        //FoodOrderModel.GetInstance().FoodOrders.Clear();
                        
                        
                        HomeViewModel.GetInstance().ListViewFoodOrders.Clear();
                        HomeViewModel.GetInstance().GetFoodOrderTotal();
                        HomeViewModel.GetInstance().TableNum = "0";
                        //windowManager.ShowDialogAsync(TablesViewModel.GetInstance());
                        return;
                    }
                    else
                    {
                        int Id = GlobalDef.ReceiptDetail.Id;
                        int re = receipt.Id;
                    }    
                }catch (Exception ex)
                {
                    var table = TableNumOrder.Split(',').Select(Int32.Parse).ToList();
                    MessageBox.Show(ex.Message);

                }
                  
                    
                
            }
            foreach(Receipt receipt in ReceiptModel.GetInstance().ListReceiptDone)
            {
                if(receipt.Id== GlobalDef.ReceiptDetail.Id && GlobalDef.ReceiptDetail.Id != 0)
                {
                    this.TryCloseAsync();
                    return;
                }    
            }    
            foreach(var table in TableNumOrder.Split(',').Select(Int32.Parse).ToList())
            {
                TablesViewModel.GetInstance().TablesAllList[table -1].TableStatus = true;
                TablesViewModel.GetInstance().TablesAllList[table - 1].IsCheckChoose = Visibility.Collapsed;

            }

            //ListOrderViewModel.GetInstance().AddListReceipt(Receipt);
            //ReceiptTest.Id = ReceiptModel.GetInstance().ListReceipt.Count();
            ReceiptModel.GetInstance().ListReceipt.Add(ReceiptTest);
            for(int i=0;i<ReceiptModel.GetInstance().ListReceipt.Count;i++)
            {
                if(ReceiptModel.GetInstance().ListReceipt[i] == ReceiptTest)
                {
                    ReceiptModel.GetInstance().ListReceipt[i].Id = ReceiptModel.GetInstance().ListReceipt.Count();
                }    
                 
            }
            HomeViewModel.GetInstance().ReceiptIdtoEdit = 0;
            //FoodOrderModel.GetInstance().FoodOrders.Clear();
            HomeViewModel.GetInstance().TableNum = "0";
            HomeViewModel.GetInstance().DiscountOrder = 0;
            HomeViewModel.GetInstance().voucherToOrder = new Voucher();
            HomeViewModel.GetInstance().ListViewFoodOrders.Clear();
            HomeViewModel.GetInstance().GetFoodOrderTotal();
            this.TryCloseAsync();
        }
    }
}
