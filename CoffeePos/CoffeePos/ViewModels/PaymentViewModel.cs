using Caliburn.Micro;
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
        //private static PaymentViewModel _instance;
        //public static PaymentViewModel GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new PaymentViewModel();
        //        }
        //    }
        //    return _instance;
        //}
        public PaymentViewModel(Receipt receipt)
        {
            receiptPayment = receipt;
            ListFoodOrder = receipt.Foods;
            MoneySuggestList = getMoneySuggestList();
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

        private List<FoodOrder> listfoodOrder;

        public List<FoodOrder> ListFoodOrder
        {
            get { return listfoodOrder; }
            set { listfoodOrder = value; NotifyOfPropertyChange(() => ListFoodOrder); }
        }

        public void CompletePaymentReceipt()
        {
            MessageBoxViewModel messageBoxViewModel = new MessageBoxViewModel();
            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(messageBoxViewModel);
            ReceiptModel.GetInstance().ListReceipt.Remove(receiptPayment);
            ListTable.GetInstance().ListTables.TableNumber[receiptPayment.Table].TableStatus = false;
            ReceiptModel.GetInstance().ListReceiptDone.Add(receiptPayment);
        }
    }
}
