using Caliburn.Micro;
using CoffeePos.Common;
using CoffeePos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            TotalPayment = receiptPayment.TotalPrice;
            DiscountOrder = receiptPayment.DiscountPrice.value;
            MoneySuggestList = getMoneySuggestList();
            foreach (var customer in HomeViewModel.GetInstance().Customer)
            {
                SearchCustomer.Add(customer.phone);
            }
        }

        public void ClearDataPayment()
        {
            ListFoodOrder = new List<FoodOrder>();
            CustomerName = "";
            TotalPayment = 0;
            DiscountOrder = 0;
            CustomerPay = 0;
            RefundMoney = 0;
            PointTradePercent = 0;
            PointCustomer = 0;
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

        private string customerPhone;

        public string CustomerPhone
        {
            get { return customerPhone; }
            set { customerPhone = value; }
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

        public void btRegister_Click()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowDialogAsync(registerViewModel);
            
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
            DiscountOrder = selectedVoucher.value;
            TotalPayment = receiptPayment.TotalPrice - (receiptPayment.TotalPrice * DiscountOrder / 100) - (receiptPayment.TotalPrice * PointTradePercent / 100);
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
            GlobalDef.windowManager.ShowDialogAsync(ListVouchersViewModel.GetInstance());
        }

        public void SearchCustomerChange(string search)
        {
            if(search == "")
            {
                PointCustomer = 0;
                TradePoint(PointCustomer);
            }    
            foreach (var customer in HomeViewModel.GetInstance().Customer)
            {
                if (search == customer.phone)
                {
                    PointCustomer = customer.point;
                    TradePoint(PointCustomer);
                    CustomerName = customer.name;
                    CustomerPhone = customer.phone;
                    Customer = customer;
                    break;
                }
            }
            TotalPayment = receiptPayment.TotalPrice - (receiptPayment.TotalPrice * PointTradePercent/100) - (receiptPayment.TotalPrice * DiscountOrder / 100);
            RefundMoney = CustomerPay - TotalPayment;
        }

        public Customer Customer = new Customer();

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

        public void CompletePaymentZaloPay()
        {
            ObservableCollection<Receipt> receipts = ReceiptModel.GetInstance().ListReceipt;
            if (receipts.Count == 0 && !GlobalDef.IsDeliveryPayment)
            {
                ClearDataPayment();
                return;
            }
            ReceiptToPush receipt = new ReceiptToPush();
            if(GlobalDef.IsDeliveryPayment)
            {
                receipt.serviceType = "AWAY";
                GlobalDef.ReceiptPayment.ServiceType = "AWAY";
            }    
            else
            {
                receipt.serviceType = "EATIN";
                GlobalDef.ReceiptPayment.ServiceType = "EATIN";
            }
            receipt.employeeId = GlobalDef.employeeGlobal.Id;
            receipt.customerId = Customer.Id;
            receipt.paymentType = "ZALOPAY";
            receipt.voucherId = receiptPayment.DiscountPrice.id;
            foreach (var food in receiptPayment.Foods)
            {
                ReceiptDetailToPush receiptDetails = new ReceiptDetailToPush();
                receiptDetails.note = food.FoodOrderMore;
                receiptDetails.amount = food.FoodOrderCount;
                if (food.FoodSize == "M")
                {
                    receiptDetails.drinkCakeVariationId = food.foodOrderVariations[0].id;
                }
                else
                {
                    receiptDetails.drinkCakeVariationId = food.foodOrderVariations[1].id;
                }
                receipt.receiptDetail.Add(receiptDetails);
            }
            
            bool result = RestAPIClient<ReceiptToPush>.PostData(receipt, GlobalDef.ZALOPAY_API, GlobalDef.token);

            if (result)
            {
                System.Diagnostics.Process.Start(GlobalDef.zaloPayResult.order_url);
                MessageBoxViewModel messageBoxViewModel = new MessageBoxViewModel("Thanh toán thành công");
                //WindowManager windowManager = new WindowManager();
                ClearDataPayment();
                GlobalDef.windowManager.ShowDialogAsync(messageBoxViewModel);
            }
            else
            {
                MessageBoxViewModel messageBoxViewModel = new MessageBoxViewModel("Thanh toán không thành công");
            }
        }


        public void CompletePaymentReceipt()
        {
            ObservableCollection<Receipt> receipts = ReceiptModel.GetInstance().ListReceipt;
            if(receipts.Count == 0 && !GlobalDef.IsDeliveryPayment)
            {
                ClearDataPayment();
                return;
            }    
            else if(!GlobalDef.IsDeliveryPayment)
            {
                ReceiptModel.GetInstance().ListReceipt.RemoveAt(receiptPayment.Id);
                var numbersTable = receiptPayment.Table.Split(',').Select(Int32.Parse).ToList();
                //for (int i = 0 ; i < ListTable.GetInstance().ListTables.TableNumber.Count; i++)
                //{
                if (numbersTable.Count != 0)
                {
                    foreach (var table in numbersTable)
                    {
                        //if(ListTable.GetInstance().ListTables.TableNumber[i].TableID == numbersTable[j])
                        //{
                        //    ListTable.GetInstance().ListTables.TableNumber[i].TableStatus = false;
                        //}
                        TablesViewModel.GetInstance().TablesAllList[table - 1].TableStatus = false;
                    }
                }

            }
            
                   
            //}    
            //ListTable.GetInstance().ListTables.TableNumber[receiptPayment.Table].TableStatus = false;
            ReceiptModel.GetInstance().ListReceiptDone.Add(receiptPayment);


            ReceiptToPush receipt = new ReceiptToPush();

            if (GlobalDef.IsDeliveryPayment)
            {
                receipt.serviceType = "AWAY";
                GlobalDef.ReceiptPayment.ServiceType = "AWAY";
            }
            else
            {
                receipt.serviceType = "EATIN";
                GlobalDef.ReceiptPayment.ServiceType = "EATIN";
            }

            receipt.customerId = Customer.Id;
            receipt.paymentType = "CASH";
            receipt.voucherId = receiptPayment.DiscountPrice.id;
            foreach (var food in receiptPayment.Foods)
            {
                ReceiptDetailToPush receiptDetails = new ReceiptDetailToPush();
                receiptDetails.note = food.FoodOrderMore;
                receiptDetails.amount = food.FoodOrderCount;
                if (food.FoodSize == "M")
                {
                    receiptDetails.drinkCakeVariationId = food.foodOrderVariations[0].id;
                }
                else
                {
                    receiptDetails.drinkCakeVariationId = food.foodOrderVariations[1].id;
                }
                receipt.receiptDetail.Add(receiptDetails);
            }
            bool result = RestAPIClient<ReceiptToPush>.PostData(receipt, GlobalDef.RECEIPTDONE_API,GlobalDef.token);

            if (result)
            {
                GlobalDef.cusPhone = Customer.phone;
                //ReceiptModel.GetInstance().ListReceipt.RemoveAt()
                ClearDataPayment();
                GlobalDef.IsPaymentClick = true;
                ReceiptReportViewModel.GetInstance().ClearDataReport();
                ReceiptReportViewModel.GetInstance().getDataReport();
                GlobalDef.windowManager.ShowDialogAsync(ReceiptReportViewModel.GetInstance());

                
            }
            else
            {
                MessageBoxViewModel messageBoxViewModel = new MessageBoxViewModel("Thanh toán không thành công");
            }    
            //try
            //{
            //    using (var client = new HttpClient())
            //    {
            //        client.BaseAddress = new Uri("http://34.126.139.165:8080/api/");
            //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalDef.token);

            //        var json = JsonConvert.SerializeObject(receipt);
            //        var payload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            //        var response = client.PostAsync(client.BaseAddress + "receipt", payload).Result;
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            MessageBoxViewModel messageBoxViewModel = new MessageBoxViewModel("Thanh toán thành công");
            //            //WindowManager windowManager = new WindowManager();
            //            ClearDataPayment();
            //            GlobalDef.windowManager.ShowDialogAsync(messageBoxViewModel);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }
    }
}
