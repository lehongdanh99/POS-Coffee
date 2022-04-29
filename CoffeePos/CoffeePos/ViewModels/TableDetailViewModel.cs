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


        public TableDetailViewModel(Receipt receipt, bool canSwitch)
        {
            ListFoodOrder = receipt.Foods;
            TableNumOrder = receipt.Table;
            PaymentOrder = receipt.Payment;
            TotalOrder = receipt.Total;
            CanSwitch = canSwitch;
        }

        

        private bool CanSwitch;

        private Visibility visibilityCanSwitch;
        public Visibility VisibilityCanSwitch
        {
            get 
            {
                if(CanSwitch)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
            set 
            { 
                visibilityCanSwitch = value;
                NotifyOfPropertyChange(() => VisibilityCanSwitch);
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

        public void btnConfirmReceipt()
        {
            Receipt ReceiptTest = new Receipt();
            WindowManager windowManager = new WindowManager();
            ReceiptTest.Foods = ListFoodOrder.ToList();
            ReceiptTest.Table = TableNumOrder;
            ReceiptTest.Total = TotalOrder;
            ReceiptTest.Payment = PaymentOrder;
            ReceiptTest.CheckOut = DateTime.Now;
            ReceiptTest.CheckIn = DateTime.Now;
            ReceiptTest.Note = string.Empty;
            foreach(Receipt receipt in ReceiptModel.GetInstance().ListReceipt)
            {
                if(receipt.Id == ReceiptTest.Id && receipt.Foods == ReceiptTest.Foods
                    && receipt.Total == ReceiptTest.Total && receipt.Payment == ReceiptTest.Payment
                    && receipt.CheckOut == ReceiptTest.CheckOut && receipt.CheckIn == ReceiptTest.CheckIn)
                {
                    ListTable.GetInstance().ListTables.TableNumber[TableNumOrder].TableStatus = true;
                    ListTable.GetInstance().ListTables.TableNumber[receipt.Table].TableStatus = false;
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
            HomeViewModel.GetInstance().ListViewFoodOrders.RemoveAt(0);
            HomeViewModel.GetInstance().GetFoodOrderTotal();
            this.TryCloseAsync();
        }
    }
}
