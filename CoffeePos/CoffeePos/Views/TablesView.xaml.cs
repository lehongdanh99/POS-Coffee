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
using CoffeePos.Common;
using CoffeePos.Models;
using Table = CoffeePos.Models.Table;

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
            if (GlobalDef.IsChooseTableToOrder)
            {
                return;
            }
            Table obj = ((FrameworkElement)sender).DataContext as Table;
            for (int i = 0; i < ReceiptModel.GetInstance().ListReceipt.Count; i++)
            {
                foreach (var table in ReceiptModel.GetInstance().ListReceipt[i].Table.Split(',').Select(Int32.Parse).ToList())
                {
                    if (table == obj.TableID)
                    {
                        foreach (var food in ReceiptModel.GetInstance().ListReceipt[i].Foods)
                        {
                            if (!food.ServedFood)
                            {
                                MessageBoxViewModel messageBoxViewModel = new MessageBoxViewModel("Chưa hoàn thành đơn");
                                //WindowManager windowManager = new WindowManager();
                                GlobalDef.windowManager.ShowDialogAsync(messageBoxViewModel);
                                return;
                            }
                        }
                        ListOrderViewModel.GetInstance().PaymentReceipt(ReceiptModel.GetInstance().ListReceipt[i]);
                        break;
                    }
                }    
                
            }    
        }

        private void ChooseTable_Click(object sender, RoutedEventArgs e)
        {
            if(!GlobalDef.IsChooseTableToOrder)
            {
                return;
            }    
            Table obj = ((FrameworkElement)sender).DataContext as Table;
            //if (GlobalDef.IsChooseTableToOrder && !obj.TableStatus)
            //{
            //    HomeViewModel.GetInstance().HandleCallBacChooseTable(obj.TableID.ToString());
            //    this.Hide();
            //    return;
            //}
            if (GlobalDef.IsChooseMoreTable && TablesViewModel.GetInstance().TablesAllList[obj.TableID - 1].IsCheckChoose == Visibility.Visible)
            {
                TablesViewModel.GetInstance().TablesAllList[obj.TableID - 1].IsCheckChoose = Visibility.Collapsed;
                TablesViewModel.GetInstance().getData();
                return;
            }
            else if(GlobalDef.IsChooseMoreTable && !obj.TableStatus)
            {
                TablesViewModel.GetInstance().TablesAllList[obj.TableID-1].IsCheckChoose = Visibility.Visible;
                TablesViewModel.GetInstance().getData();
                return;
            }
            
        }

        private void ConfirmChooseMoreBtn_Click(object sender, RoutedEventArgs e)
        {
            List<int> listTable =   new List<int>();
            SolidColorBrush colorCheck = new SolidColorBrush(Colors.Orange);
            foreach (var item in TablesViewModel.GetInstance().TablesAllList)
            {
                if(item.IsCheckChoose == Visibility.Visible)
                {
                    listTable.Add(item.TableID);
                }
            }  
            if(listTable.Count == 1)
            {
                HomeViewModel.GetInstance().HandleCallBacChooseTable(listTable[0].ToString());
                this.Hide();
            }
            else if(listTable.Count > 1)
            {
                HomeViewModel.GetInstance().HandleCallBacChooseMoreTable(listTable);
                this.Hide();
            }
            else
            {
                this.Hide();
            } 
                
                
            
        }

        private void DetailTableBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalDef.IsChooseTableToOrder)
            {
                return;
            }
            Table obj = ((FrameworkElement)sender).DataContext as Table;
            //TablesViewModel.GetInstance.btTableSelected_Click(obj);
            if(obj.TableStatus == true)
            {
                TablesViewModel.GetInstance().btTableSelected_Click(obj);
            }    
            else
            {
                if(GlobalDef.IsChooseTableToOrder)
                {
                    HomeViewModel.GetInstance().HandleCallBacChooseTable(obj.TableID.ToString());
                    this.Hide();
                }    
                else
                {

                }
                
            }    
            
        }
    }
}
