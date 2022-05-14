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
    /// Interaction logic for TableDetailView.xaml
    /// </summary>
    public partial class TableDetailView : Window
    {
        public TableDetailView()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        private void btnRemoveFood_Click(object sender, RoutedEventArgs e)
        {
            FoodOrder obj = ((FrameworkElement)sender).DataContext as FoodOrder;

        }

        private void AddMoreFood_Click(object sender, RoutedEventArgs e)
        {
            HomeViewModel.GetInstance()
                FoodOrderModel.GetInstance().FoodOrders 

        }
        private void btnComlpleteFood_Click(object sender, RoutedEventArgs e)
        {
            FoodOrder obj = ((FrameworkElement)sender).DataContext as FoodOrder;
            for(int i = 0; i < ReceiptModel.GetInstance().ListReceipt.Count(); i++)
            {
                if(ReceiptModel.GetInstance().ListReceipt[i] == GlobalDef.ReceiptDetail)
                {
                    for(int j = 0; j < ReceiptModel.GetInstance().ListReceipt[i].Foods.Count(); j++)
                    {
                        if(ReceiptModel.GetInstance().ListReceipt[i].Foods[j] == obj)
                        {
                            ReceiptModel.GetInstance().ListReceipt[i].Foods[j].IsDoneFood = true;
                        }
                    }
                }
            }
        }
    }
}
