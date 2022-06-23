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

        private ObservableCollection<Receipt> listReceiptDone = new ObservableCollection<Receipt>();

        public ObservableCollection<Receipt> ListReceiptDone
        {
            get { return listReceiptDone; }
            set { listReceiptDone = value; }
        }

        public class Receipt
        {
            public List<FoodOrder> Foods = new List<FoodOrder>();

            public int Id { get; set; }
            public string Table { get; set; }

            public double TotalPrice { get; set; }

            public double Payment { get; set; }

            public string Note { get; set; }

            public string CheckIn { get; set; }

            public string CheckOut { get; set; }

            public string Voucher { get; set; }

            public Voucher DiscountPrice { get; set; }

            //public Receipt(List<FoodOrder> foods = default, string table = default, double total = default, double payment = default, string note = default, string checkIn = default, string checkOut = default, string voucher = default, int discount = 0)
            //{
            //    foods = Foods;
            //    table = Table;
            //    total = TotalPrice;
            //    payment = Payment;
            //    note = Note;
            //    checkIn = CheckIn;
            //    checkOut = CheckOut;
            //    voucher = Voucher;
            //    discount = DiscountPrice;
            //}
        }

        public class ReceiptDetails
        {
            public int id { get; set; }

            private FoodVariations foodVariations = new FoodVariations();
            public FoodVariations drinkCakeVariationId
            {
                get { return foodVariations; }
                set { foodVariations = value; }
            }
            public int Amount { get; set; }
            public int Price { get; set; }
            public string Note { get; set; }

        }

        public class ReceiptDone
        {
            public List<ReceiptDetails> receiptDetails = new List<ReceiptDetails>();

            public int Id { get; set; }
            public string Table { get; set; }

            public double TotalPrice { get; set; }

            public string PaymentType { get; set; }

            public int customerId { get; set; }

            public string Note { get; set; }

            public string serviceType { get; set; }

            public string CheckOut { get; set; }

            public int voucherId { get; set; }

            public int DiscountPrice { get; set; }
        }

        public class ReceiptToPush
        {
            public List<ReceiptDetailToPush> receiptDetail = new List<ReceiptDetailToPush>();
            public string paymentType { get; set; }

            public int customerId { get; set; }
            public string serviceType { get; set; }
            public int voucherId { get; set; }


            private int BranchId = 0;

            public int branchId
            {
                get { return BranchId; }
                set { BranchId = value; }
            }

            private int CustomerPay = 0;

            public int customerPay
            {
                get { return CustomerPay; }
                set { CustomerPay = value; }
            }

            private int DiscountPrice = 0;

            public int discountPrice
            {
                get { return DiscountPrice; }
                set { DiscountPrice = value; }
            }
            private int EmployeeId = 0;

            public int employeeId
            {
                get { return EmployeeId; }
                set { EmployeeId = value; }
            }
            private int Id = 0;

            public int id
            {
                get { return Id = 0; }
                set { Id = value; }
            }
            private int TotalPrice = 0;

            public int totalPrice
            {
                get { return TotalPrice = 0; }
                set { TotalPrice = value; }
            }

        }

        public class ReceiptDetailToPush
        {
            private int foodVariations = new int();
            public int drinkCakeVariationId
            {
                get { return foodVariations; }
                set { foodVariations = value; }
            }

            public int amount { get; set; }
            public string note { get; set; }

        }
    }
}
