using Caliburn.Micro;
using CoffeePos.Common;
using CoffeePos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoffeePos.Models.ReceiptModel;

namespace CoffeePos.ViewModels
{
    internal class PaymentViewModel : Screen
    {
        private static PaymentViewModel _instance;
        public static PaymentViewModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new PaymentViewModel();
                }
            }
            return _instance;
        }
        public PaymentViewModel()
        {

            getDataPayment();
        }
        
        public void getDataPayment()
        {
            receiptPayment = GlobalDef.ReceiptPayment;
            ListFoodOrder = receiptPayment.Foods;
            TotalPayment = receiptPayment.Total;
            DiscountOrder = receiptPayment.Discount;
            MoneySuggestList = getMoneySuggestList();
            foreach (var customer in HomeViewModel.GetInstance().Customer)
            {
                SearchCustomer.Add(customer.Phone);
            }
        }

        private int discountOrder = 0;

        public int DiscountOrder
        {
            get { return discountOrder; }
            set { discountOrder = value; NotifyOfPropertyChange(() => DiscountOrder); }
        }

        private double totalPayment;

        public double TotalPayment
        {
            get { return totalPayment; }
            set { totalPayment = value;
                NotifyOfPropertyChange(() => TotalPayment);
            }
        }



        private int pointTradePercent;

        public int PointTradePercent
        {
            get { return pointTradePercent; }
            set { pointTradePercent = value; NotifyOfPropertyChange(() => PointTradePercent); }
        }

        private double pointCustomer;

        public double PointCustomer
        {
            get { return pointCustomer; }
            set { pointCustomer = value; NotifyOfPropertyChange(() => PointCustomer); }
        }

        private string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; NotifyOfPropertyChange(() => CustomerName); }
        }

        private double customerPay;

        public double CustomerPay
        {
            get { return customerPay; }
            set
            {
                customerPay = value;
                NotifyOfPropertyChange(() => CustomerPay);
            }
        }

        private double refundMoney;

        public double RefundMoney
        {
            get { return refundMoney; }
            set { refundMoney = value;
                NotifyOfPropertyChange(() => RefundMoney);
            }
        }

        private List<string> searchCustomer = new List<string>();
        public List<string> SearchCustomer
        {
            get { return searchCustomer; }
            set { searchCustomer = value; NotifyOfPropertyChange(() => SearchCustomer); }
        }

        private Receipt receiptPayment;

        private ObservableCollection<MoneySuggest> getMoneySuggestList()
        {
            return new ObservableCollection<MoneySuggest>()
            {
                new MoneySuggest(1000),
                new MoneySuggest(2000),
                new MoneySuggest(5000),
                new MoneySuggest(10000),
                new MoneySuggest(20000),
                new MoneySuggest(50000),
                new MoneySuggest(100000),
                new MoneySuggest(200000),
                new MoneySuggest(500000),
            };
        }

        private ObservableCollection<MoneySuggest> moneySuggest = new ObservableCollection<MoneySuggest>();
        public ObservableCollection<MoneySuggest> MoneySuggestList
        {
            get { return moneySuggest; }
            set
            {
                moneySuggest = value;
                NotifyOfPropertyChange(() => MoneySuggestList);
            }
        }

        public void HandleCallBackChooseVoucher(Voucher selectedVoucher)
        {
            DiscountOrder = selectedVoucher.Percent;
            TotalPayment = TotalPayment - (TotalPayment * DiscountOrder / 100);
            RefundMoney = CustomerPay - TotalPayment;
            GlobalDef.IsChooseVoucerToPayment = false;
        }

        public void GetFoodOrderTotal(double cuspay)
        {
            //if(DiscountOrder == 0 || cuspay == null)
            //{
            //    return;
            //}
            //TotalPayment = receiptPayment.Payment - (receiptPayment.Payment * DiscountOrder / 100);
            //RefundMoney = cuspay - TotalPayment;
            //NotifyOfPropertyChange(() => RefundMoney);
            //NotifyOfPropertyChange(() => TotalPayment);
        }

        public void btListVoucher_Click()
        {
            ListVouchersViewModel.GetInstance().GetEnableVoucher();
            GlobalDef.IsChooseVoucerToPayment = true;
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowWindowAsync(ListVouchersViewModel.GetInstance());
        }

        public void SearchCustomerChange(string search)
        {
            foreach (var customer in HomeViewModel.GetInstance().Customer)
            {
                if (search == customer.Phone)
                {
                    PointCustomer = customer.Point;
                    TradePoint(PointCustomer);
                    CustomerName = customer.Name;
                    break;
                }
            }
            TotalPayment = TotalPayment - (TotalPayment * PointTradePercent/100);
            RefundMoney = CustomerPay - TotalPayment;
        }

        public void TradePoint(double point)
        {
            if(point < 0)
            {
                PointTradePercent = 0;
            }    
            else if(point > 100)
            {
                PointTradePercent = 5;
            }    
            else if(point > 1000)
            {
                PointTradePercent = 10;
            }    
            else if(point > 10000)
            {
                PointTradePercent = 15;
            }
            else if (point > 100000)
            {
                PointTradePercent = 20;
            }
        }

        private List<FoodOrder> listfoodOrder;

        public List<FoodOrder> ListFoodOrder
        {
            get { return listfoodOrder; }
            set { listfoodOrder = value; NotifyOfPropertyChange(() => ListFoodOrder); }
        }

        public void CompletePaymentReceipt()
        {

            ObservableCollection<Receipt> receipts = ReceiptModel.GetInstance().ListReceipt;
            if(receipts.Count == 0)
            {
                return;
            }    
            ReceiptModel.GetInstance().ListReceipt.RemoveAt(receiptPayment.Id);
            var numbersTable = receiptPayment.Table.Split(',').Select(Int32.Parse).ToList();
            //for (int i = 0 ; i < ListTable.GetInstance().ListTables.TableNumber.Count; i++)
            //{
                
                for(int j = 0; j < numbersTable.Count; j++)
                {
                //if(ListTable.GetInstance().ListTables.TableNumber[i].TableID == numbersTable[j])
                //{
                //    ListTable.GetInstance().ListTables.TableNumber[i].TableStatus = false;
                //}
                TablesViewModel.GetInstance().TablesAllList[numbersTable[j]].TableStatus = false;
                }    
            //}    
            //ListTable.GetInstance().ListTables.TableNumber[receiptPayment.Table].TableStatus = false;
            ReceiptModel.GetInstance().ListReceiptDone.Add(receiptPayment);
            MessageBoxViewModel messageBoxViewModel = new MessageBoxViewModel("Thanh toán thành công");
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowWindowAsync(messageBoxViewModel);
        }
    }
}
