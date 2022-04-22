using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using static CoffeePos.FoodOrderModel;

namespace CoffeePos.Models
{
    public class ReceiptModel : PropertyChangedBase
    {
        private static ReceiptModel _instance;
        public static ReceiptModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new ReceiptModel();
                }
            }
            return _instance;
        }

        private ObservableCollection<Receipt> listReceipt = new ObservableCollection<Receipt>();

        public ObservableCollection<Receipt> ListReceipt
        {
            get { return listReceipt; }
            set { listReceipt = value; }
        }

        public class Receipt
        {
            public ObservableCollection<FoodOrder> Foods { get; set; }

            public int Id { get; set; }
            public int Table { get; set; }

            public double Total { get; set; }

            public double Payment { get; set; }

            public string Note { get; set; }

            public DateTime CheckIn { get; set; }

            public DateTime CheckOut { get; set; }

            public string Voucher { get; set; }

            public string Discount { get; set; }

            public Receipt(ObservableCollection<FoodOrder> foods = default, int table = default, double total = default, double payment = default, string note = default, DateTime checkIn = default, DateTime checkOut = default, string voucher = default, string discount = default)
            {
                foods = Foods;
                table = Table;
                total = Total;
                payment = Payment;
                note = Note;
                checkIn = CheckIn;
                checkOut = CheckOut;
                voucher = Voucher;
                discount = Discount;
            }
        }
    }
}
