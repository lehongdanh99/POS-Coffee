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

        public TableDetailViewModel(Receipt receipt, bool canEdit)
        {
            GlobalDef.ReceiptDetail = receipt;
            ListFoodOrder = receipt.Foods;
            TableNumOrder = Int32.Parse(receipt.Table); ;
            PaymentOrder = receipt.Payment;
            TotalOrder = receipt.Total;
            DiscountOrder = receipt.Discount;
            CanEdit = canEdit;
        }

        bool isAllServed = false;

        public bool IsAllServed
        {
            get { return isAllServed; }
            set { isAllServed = value;
                NotifyOfPropertyChange(() => IsAllServed);
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
        private List<FoodOrder> listfoodOrder;

        public List<FoodOrder> ListFoodOrder
        {
            get { return listfoodOrder; }
            set { listfoodOrder = value; NotifyOfPropertyChange(() => ListFoodOrder); }
        }

        private int tableNumOrder;

        public int TableNumOrder
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

        public void SwtitchTable()
        {
            eventSwitchTableCallBack.Invoke(TableNumOrder);
            //TablesViewModel tableViewModel = new TablesViewModel(true);
            
            TablesViewModel.GetInstance().eventChooseTableToOrder += HandleCallBacChooseTable;
            //WindowManager windowManager = new WindowManager();
            //windowManager.ShowWindowAsync(tableViewModel);
        }
        public void HandleCallBacChooseTable(int TableChoose)
        {
            TableNumOrder = TableChoose;
            NotifyOfPropertyChange(() => TableNumOrder);
        }

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
                    food.ServedFood = false;
                }
                IsAllServed = false;
            }
            else
            {
                IsAllServed = true;
            }
        }

        public void BtnChooseDiscount()
        {
            HomeViewModel.GetInstance().btListVoucher_Click();
        }


        public void btnAddFoods()
        {
            foreach(var food in ListFoodOrder)
            HomeViewModel.GetInstance().ListViewFoodOrders.ToList().Add(food);
            WindowManager windowManager = new WindowManager();
            windowManager.ShowDialogAsync(HomeViewModel.GetInstance());
            HomeViewModel.GetInstance().GetFoodOrderTotal();
            this.TryCloseAsync();
        }

        public void btnConfirmReceipt()
        {
            Receipt ReceiptTest = new Receipt();
            WindowManager windowManager = new WindowManager();
            ReceiptTest.Foods = ListFoodOrder.ToList();
            ReceiptTest.Table = TableNumOrder.ToString();
            ReceiptTest.Total = TotalOrder;
            ReceiptTest.Discount = DiscountOrder;
            ReceiptTest.Payment = PaymentOrder;
            ReceiptTest.CheckOut = DateTime.Now;
            ReceiptTest.CheckIn = DateTime.Now;
            ReceiptTest.Note = string.Empty;
            foreach(Receipt receipt in ReceiptModel.GetInstance().ListReceipt)
            {
                if(receipt.Id == ReceiptTest.Id
                    && receipt.Total == ReceiptTest.Total && receipt.Payment == ReceiptTest.Payment)
                {
                    ListTable.GetInstance().ListTables.TableNumber[TableNumOrder].TableStatus = true;
                    ListTable.GetInstance().ListTables.TableNumber[Int32.Parse(receipt.Table)].TableStatus = false;
                    ReceiptModel.GetInstance().ListReceipt[receipt.Id] = ReceiptTest;
                    this.TryCloseAsync();

                    //FoodOrderModel.GetInstance().FoodOrders.Clear();
                    HomeViewModel.GetInstance().TableNum = 0;
                    HomeViewModel.GetInstance().GetFoodOrderTotal();
                    HomeViewModel.GetInstance().ListViewFoodOrders.Clear();
                    //windowManager.ShowWindowAsync(TablesViewModel.GetInstance());
                    return;
                }
                    
                
            }
            ListTable.GetInstance().ListTables.TableNumber[TableNumOrder].TableStatus = true;
            //ListOrderViewModel.GetInstance().AddListReceipt(Receipt);
            ReceiptModel.GetInstance().ListReceipt.Add(ReceiptTest);
           
            //FoodOrderModel.GetInstance().FoodOrders.Clear();
            HomeViewModel.GetInstance().TableNum = 0;
            HomeViewModel.GetInstance().ListViewFoodOrders.Clear();
            HomeViewModel.GetInstance().GetFoodOrderTotal();
            this.TryCloseAsync();
        }
    }
}
