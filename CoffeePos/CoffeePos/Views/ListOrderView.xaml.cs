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
            this.Hide();
        }

        //private void btnShowListReceipt(object sender, RoutedEventArgs e)
        //{
        //    //this.Hide();
        //    ListOrderViewModel.GetInstance().ListReceipts = ReceiptModel.GetInstance().ListReceipt;
        //}

        //private void ShowListReceiptDone(object sender, RoutedEventArgs e)
        //{
            
        //}

        private void ViewDetailReceipt_Click(object sender, RoutedEventArgs e)
        {

            Receipt obj = ((FrameworkElement)sender).DataContext as Receipt;
            GlobalDef.DetailFromHome = Visibility.Visible;
            ListOrderViewModel.GetInstance().ViewDetailReceipt(obj, true);
        }

        private void ViewDetailReceiptDone_Click(object sender, RoutedEventArgs e)
        {

            ReceiptDone obj = ((FrameworkElement)sender).DataContext as ReceiptDone;
            GlobalDef.DetailFromHome = Visibility.Hidden;
            ListOrderViewModel.GetInstance().ViewDetailReceiptDone(obj);
        }

        private void PaymentReceipt_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            Receipt obj = ((FrameworkElement)sender).DataContext as Receipt;
            foreach(var food in obj.Foods)
            {
                if (!food.ServedFood)
                {
                    MessageBoxViewModel messageBoxViewModel = new MessageBoxViewModel("Chưa hoàn thành đơn");
                    //WindowManager windowManager = new WindowManager();
                    GlobalDef.windowManager.ShowDialogAsync(messageBoxViewModel);
                    return;
                }
            }    
            ListOrderViewModel.GetInstance().PaymentReceipt(obj);
        }
    }
}
