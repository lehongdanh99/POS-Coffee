using CoffeePos.Common;
using CoffeePos.Models;
using CoffeePos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static CoffeePos.Models.ReceiptModel;

namespace CoffeePos.Views
{
    /// <summary>
    /// Interaction logic for PaymentView.xaml
    /// </summary>
    public partial class PaymentView : Window
    {
        public PaymentView()
        {
            InitializeComponent();
            BtnPayment.IsEnabled = false;
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void MoneySuggest_Click(object sender, RoutedEventArgs e)
        {
            MoneySuggest obj = ((FrameworkElement)sender).DataContext as MoneySuggest;

            int i = 0;
            TxtMoneyoutput.Text = obj.Value.ToString();
            TxtMoneyInput.Text = obj.Value.ToString();
        }
        private void PaymentCashClick(object sender, RoutedEventArgs e)
        {
            MoneyInput.Visibility = Visibility.Visible;
        }
        private void PaymentZaloClick(object sender, RoutedEventArgs e)
        {
            MoneyInput.Visibility = Visibility.Collapsed;
        }

        private void textChangedEventHandler(object sender, EventArgs e)
        {
            
            int txtRefund;
            PaymentViewModel.GetInstance().CustomerPay = Int32.Parse(TxtMoneyInput.Text);
            txtRefund = Int32.Parse(TxtMoneyoutput.Text) - Int32.Parse(TxtTotalPayment.Text);
            PaymentViewModel.GetInstance().RefundMoney = txtRefund;
            if(PaymentViewModel.GetInstance().CustomerPay == 0)
            {
                PaymentViewModel.GetInstance().RefundMoney = 0;
            }    
            if(txtRefund < 0)
            {
                TxtRefundMoney.Foreground = new SolidColorBrush(Colors.Red);
                BtnPayment.IsEnabled = false;
            }    
            else
            {
                BtnPayment.IsEnabled = true;
                TxtRefundMoney.Foreground = new SolidColorBrush(Colors.Blue);
            }    
        }

        private void PaymentFinalClick(object sender, RoutedEventArgs e)
        {
            this.Hide();

        }

        private void btnChooseVoucher(object sender, RoutedEventArgs e)
        {
            PaymentViewModel.GetInstance().GetFoodOrderTotal(Int32.Parse(TxtMoneyoutput.Text));
        }

        private void BtnIn_Click(object sender, RoutedEventArgs e)
        {
            ReceiptReportViewModel.GetInstance().getDataReport();
            GlobalDef.windowManager.ShowDialogAsync(ReceiptReportViewModel.GetInstance());

        }

        private void SearchCustomerClick(object sender, RoutedEventArgs e)
        {
            string obj = ((FrameworkElement)sender).DataContext as string;
              
            PaymentViewModel.GetInstance().SearchCustomerChange(CustomerNameCb.Text);
        }
    }
}
