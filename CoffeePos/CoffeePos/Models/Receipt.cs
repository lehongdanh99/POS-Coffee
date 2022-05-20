﻿using System;
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

            public double Total { get; set; }

            public double Payment { get; set; }

            public string Note { get; set; }

            public string CheckIn { get; set; }

            public string CheckOut { get; set; }

            public string Voucher { get; set; }

            public int Discount { get; set; }

            public Receipt(List<FoodOrder> foods = default, string table = default, double total = default, double payment = default, string note = default, string checkIn = default, string checkOut = default, string voucher = default, int discount = 0)
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
