using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.ViewModels
{
    internal class TableDetailViewModel : Screen
    {
        public TableDetailViewModel(ObservableCollection<FoodOrder> listFoodOrder, int tableID, double total, double amount)
        {
            orderTable = listFoodOrder;
            TableNumOrder = tableID;
            PaymentOrder = amount;
            TotalOrder = total;
        }

        private ObservableCollection<FoodOrder> orderTable;

        public ObservableCollection<FoodOrder> OrderTable
        {
            get { return orderTable; }
            set { orderTable = value; NotifyOfPropertyChange(() => OrderTable); }
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
    }
}
