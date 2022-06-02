using Caliburn.Micro;
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
    /// Interaction logic for MessageBoxView.xaml
    /// </summary>
    public partial class MessageBoxView : Window
    {
        public MessageBoxView()
        {
            InitializeComponent();
            //if (MessageBoxText.Text.ToString() == "Xác nhận hủy đơn")
            //{
            //    btnConfirm2.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    btnConfirm2.Visibility = Visibility.Visible;
            //}    
        }
        private void ConfirmPaymentClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            if(MessageBoxText.Text.ToString() == "Thanh toán thành công")
            {
                ListOrderViewModel.GetInstance().TryCloseAsync();
                TablesViewModel.GetInstance().TryCloseAsync();
            }   
            else if(MessageBoxText.Text.ToString() == "Hủy đơn thành công")
            {
                ListOrderViewModel.GetInstance().TryCloseAsync();
                TablesViewModel.GetInstance().TryCloseAsync();

                TableDetailViewModel.GetInstance().TryCloseAsync();
                TablesViewModel.GetInstance().TablesAllList[Int32.Parse(GlobalDef.ReceiptDetail.Table)].TableStatus = false;
            }    
            
        }

        private void ConfirmDeleteClick(object sender, RoutedEventArgs e)
        {
            ReceiptModel.GetInstance().ListReceipt.Remove(GlobalDef.ReceiptDetail);
            this.Hide();
            TableDetailViewModel.GetInstance().TryCloseAsync(true);
            MessageBoxViewModel messageBoxViewModel = new MessageBoxViewModel("Hủy đơn thành công");
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowWindowAsync(messageBoxViewModel);
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
