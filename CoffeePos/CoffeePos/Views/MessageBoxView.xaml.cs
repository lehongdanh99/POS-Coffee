using Caliburn.Micro;
using CoffeePos.Common;
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
    /// Interaction logic for MessageBoxView.xaml
    /// </summary>
    public partial class MessageBoxView : Window
    {
        public MessageBoxView()
        {
            InitializeComponent();
        }
        private void ConfirmPaymentClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            if(MessageBoxText.Text.ToString() == "Thanh toán thành công")
            {
                ListOrderViewModel.GetInstance().TryCloseAsync();
                TablesViewModel.GetInstance().TryCloseAsync();
            }   
            else
            {

            }    
            
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
