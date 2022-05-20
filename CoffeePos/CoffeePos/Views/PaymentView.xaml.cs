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
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void MoneySuggest_Click(object sender, RoutedEventArgs e)
        {
            MoneySuggest obj = ((FrameworkElement)sender).DataContext as MoneySuggest;
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
            TxtMoneyoutput.Text = TxtMoneyInput.Text;
        }

        private void PaymentFinalClick(object sender, RoutedEventArgs e)
        {
            this.Hide();

        }
    }
}
