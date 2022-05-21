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

namespace CoffeePos.Views
{
    /// <summary>
    /// Interaction logic for ListVouchersView.xaml
    /// </summary>
    public partial class ListVouchersView : Window
    {
        public ListVouchersView()
        {
            InitializeComponent();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChooseVoucher(object sender, RoutedEventArgs e)
        {
            Voucher obj = ((FrameworkElement)sender).DataContext as Voucher;
            
            if(GlobalDef.IsChooseVoucerToOrder == true)
            {
                HomeViewModel.GetInstance().HandleCallBackChooseVoucher(obj);
                this.Hide();
            }
            else if (GlobalDef.IsChooseVoucerToPayment == true)
            {
                PaymentViewModel.GetInstance().HandleCallBackChooseVoucher(obj);
                this.Hide();
            }  


        }
    }
}
