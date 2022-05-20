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
            GetFoodOrderTotal();
            GlobalDef.IsChooseVoucerToPayment = false;
        }

        public void GetFoodOrderTotal()
        {
            TotalPayment = receiptPayment.Payment - (receiptPayment.Payment * DiscountOrder / 100);
            NotifyOfPropertyChange(() => TotalPayment);
        }

        public void btListVoucher_Click()
        {
            GlobalDef.IsChooseVoucerToPayment = true;
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowWindowAsync(ListVouchersViewModel.GetInstance());
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
                    ListTable.GetInstance().ListTables.TableNumber[numbersTable[j]].TableStatus = false;
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
