﻿using CoffeePos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.ViewModels
{
    public class ReceiptReportViewModel
    {
        private static ReceiptReportViewModel _instance;
        public static ReceiptReportViewModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new ReceiptReportViewModel();
                }
            }
            return _instance;
        }

        public ReceiptReportViewModel()
        {
        }

        public void ClearDataReport()
        {
            Stt.Clear();
            NameFood.Clear();
            FoodSize.Clear();
            FoodPrice.Clear();
            FoodCount.Clear();
            FoodPayment.Clear();

        }
        public void getDataReport()
        {

            foreach (var food in GlobalDef.ReceiptPayment.Foods)
            {
                Stt.Add(food.FoodOrderID);
                NameFood.Add(food.FoodOrderName);
                FoodSize.Add(food.FoodSize);
                if(food.FoodSize == "M")
                {
                    FoodPrice.Add(food.foodOrderVariations[0].price);
                }    
                else
                {
                    FoodPrice.Add(food.foodOrderVariations[1].price);
                }    
                FoodCount.Add(food.FoodOrderCount);
                
                FoodPayment.Add(food.FoodOrderPrice);
            }
            TotalPayment = GlobalDef.ReceiptPayment.TotalPrice;
        }

        public void getDataDone()
        {
            foreach (var food in GlobalDef.ReceiptDoneDetail.receiptDetails)
            {
                int i = 1;
                Stt.Add(i);
                i++;
                NameFood.Add(food.Name);
                FoodSize.Add(food.drinkCakeVariation.name);
                FoodPrice.Add(food.drinkCakeVariation.price);

                FoodCount.Add(food.Amount);

                FoodPayment.Add(food.Price);
            }
            TotalPayment = GlobalDef.ReceiptDoneDetail.TotalPrice;
            DateReceipt = GlobalDef.ReceiptDoneDetail.createdAtFormatVN;
            ReceiptID = GlobalDef.ReceiptDoneDetail.Id;
        }

        private string employeeName;

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        private int tableID;

        public int TableID
        {
            get { return tableID; }
            set { tableID = value; }
        }

        private List<string> foodSize = new List<string>();

        public List<string> FoodSize
        {
            get { return foodSize; }
            set { foodSize = value; }
        }


        private int receiptID;

        public int ReceiptID
        {
            get { return receiptID; }
            set { receiptID = value; }
        }

        private DateTime dateReceipt;

        public DateTime DateReceipt
        {
            get { return dateReceipt; }
            set { dateReceipt = value; }
        }

        private DateTime timeReceipt;

        public DateTime TimeReceipt
        {
            get { return timeReceipt; }
            set { timeReceipt = value; }
        }

        private List<int> stt = new List<int>();
        public List<int> Stt
        {
            get { return stt; }

                set { stt = value; }
        }

        private List<string> nameFood = new List<string>();
        public List<string> NameFood
        {
            get { return nameFood; }

            set { nameFood = value; }
        }

        private List<int> foodCount = new List<int>();
        public List<int> FoodCount
        {
            get { return foodCount; }

            set { foodCount = value; }
        }

        private List<double> foodPrice = new List<double>();
        public List<double> FoodPrice
        {
            get { return foodPrice; }

            set { foodPrice = value; }
        }

        private List<double> foodPayment = new List<double>();
        public List<double> FoodPayment
        {
            get { return foodPayment; }

            set { foodPayment = value; }
        }

        private double totalPayment = 0;
        public double TotalPayment
        {
            get { return totalPayment; }

            set { totalPayment = value; }
        }
    }
}
