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
using static CoffeePos.Models.TableModel;
using static CoffeePos.Models.ReceiptModel;
using CoffeePos.Common;

namespace CoffeePos.Views
{
    /// <summary>
    /// Interaction logic for TablesView.xaml
    /// </summary>
    public partial class TablesView : Window
    {
        public TablesView()
        {
            InitializeComponent();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PaymentTable_Click(object sender, RoutedEventArgs e)
        {
            Receipt obj = ((FrameworkElement)sender).DataContext as Receipt;
            ListOrderViewModel.GetInstance().PaymentReceipt(obj);
        }
        private void ChooseTable_Click(object sender, RoutedEventArgs e)
        {
            Models.TableModel.Table obj = ((FrameworkElement)sender).DataContext as Models.TableModel.Table;
            //TablesViewModel.GetInstance.btTableSelected_Click(obj);
            if(obj.TableStatus == true)
            {
                TablesViewModel.GetInstance().btTableSelected_Click(obj);
            }    
            else
            {
                if(GlobalDef.IsChooseTableToOrder)
                {
                    HomeViewModel.GetInstance().HandleCallBacChooseTable(obj.TableID);
                    this.Hide();
                }    
                else
                {

                }
                
            }    
            
        }
    }
}
