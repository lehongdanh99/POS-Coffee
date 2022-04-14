using Caliburn.Micro;
using CoffeePos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static CoffeePos.Models.ReceiptModel;

namespace CoffeePos.ViewModels
{
    internal class TableDetailViewModel : Screen
    {
        public TableDetailViewModel(ObservableCollection<FoodOrder> listFoodOrder, int tableID, double total, double amount, bool confirmFromHome)
        {
            ListFoodOrder = listFoodOrder;
            TableNumOrder = tableID;
            PaymentOrder = amount;
            TotalOrder = total;
            ConfirmFromHome = confirmFromHome;
        }

        public Receipt Receipt = new Receipt();

        private bool ConfirmFromHome;

        private Visibility visibilityCanSwitch;
        public Visibility VisibilityCanSwitch
        {
            get { return visibilityCanSwitch; }
            set 
            { 
                visibilityCanSwitch = value;
                NotifyOfPropertyChange(() => VisibilityCanSwitch);
            }
        }
        private ObservableCollection<FoodOrder> orderTable;

        public ObservableCollection<FoodOrder> ListFoodOrder
        {
            get { return orderTable; }
            set { orderTable = value; NotifyOfPropertyChange(() => ListFoodOrder); }
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

        public void btnConfirmReceipt()
        {
            Receipt.Foods = ListFoodOrder;
            Receipt.Table = TableNumOrder;
            Receipt.Total = TotalOrder;
            Receipt.Payment = PaymentOrder;
            Receipt.CheckOut = DateTime.Now;
            Receipt.CheckIn = DateTime.Now;
            Receipt.Note = string.Empty;

            //ListOrderViewModel.GetInstance().AddListReceipt(Receipt);
            ReceiptModel.GetInstance().ListReceipt.Add(Receipt);
        }
    }
}
