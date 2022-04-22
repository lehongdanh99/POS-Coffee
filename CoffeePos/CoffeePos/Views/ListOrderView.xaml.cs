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
    /// Interaction logic for ListOrderView.xaml
    /// </summary>
    public partial class ListOrderView : Window
    {
        public ListOrderView()
        {
            InitializeComponent();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ViewDetailReceipt_Click(object sender, RoutedEventArgs e)
        {

            Receipt obj = ((FrameworkElement)sender).DataContext as Receipt;
            ListOrderViewModel.GetInstance().ViewDetailReceipt(obj);
        }

        private void PaymentReceipt_Click(object sender, RoutedEventArgs e)
        {
            Receipt obj = ((FrameworkElement)sender).DataContext as Receipt;
            ListOrderViewModel.GetInstance().PaymentReceipt(obj);
        }
    }
}
