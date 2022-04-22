﻿using Caliburn.Micro;
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
        public TableDetailViewModel(Receipt receipt, bool canSwitch)
        {
            ListFoodOrder = receipt.Foods;
            TableNumOrder = receipt.Table;
            PaymentOrder = receipt.Payment;
            TotalOrder = receipt.Total;
            CanSwitch = canSwitch;
        }

        public Receipt Receipt = new Receipt();

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

        public void SwtitchTable()
        {

            TablesViewModel tableViewModel = new TablesViewModel(true);
            tableViewModel.eventChooseTableToOrder += HandleCallBacChooseTable;
            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(tableViewModel);
        }
        public void HandleCallBacChooseTable(int TableChoose)
        {
            TableNumOrder = TableChoose;
            NotifyOfPropertyChange(() => TableNumOrder);
        }

        public void btnConfirmReceipt()
        {
            WindowManager windowManager = new WindowManager();
            Receipt.Foods = ListFoodOrder;
            Receipt.Table = TableNumOrder;
            Receipt.Total = TotalOrder;
            Receipt.Payment = PaymentOrder;
            Receipt.CheckOut = DateTime.Now;
            Receipt.CheckIn = DateTime.Now;
            Receipt.Note = string.Empty;
            foreach(Receipt receipt in ReceiptModel.GetInstance().ListReceipt)
            {
                if(receipt.Id == Receipt.Id)
                {
                    ListTable.GetInstance().ListTables.TableNumber[TableNumOrder].TableStatus = true;
                    ListTable.GetInstance().ListTables.TableNumber[receipt.Table].TableStatus = false;
                    ReceiptModel.GetInstance().ListReceipt[receipt.Id] = Receipt;
                    this.TryCloseAsync();
                    TablesViewModel tableViewModel = new TablesViewModel(false);


                    windowManager.ShowWindowAsync(tableViewModel);
                    return;
                }
                    
                
            }
            ListTable.GetInstance().ListTables.TableNumber[TableNumOrder].TableStatus = true;
            //ListOrderViewModel.GetInstance().AddListReceipt(Receipt);
            ReceiptModel.GetInstance().ListReceipt.Add(Receipt);
            this.TryCloseAsync();
            FoodOrderModel.GetInstance().FoodOrders.Clear();
            HomeViewModel.GetInstance().GetFoodOrderTotal();

        }
    }
}
