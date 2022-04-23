using Caliburn.Micro;
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
using static CoffeePos.FoodOrderModel;

namespace CoffeePos.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Window
    {
        public HomeView()
        {
            InitializeComponent();
            
        }
        private void SelectCurrentItem(object sender, KeyboardFocusChangedEventArgs e)
        {
            //By this Code I got my `ListView` row Selected.
            ListViewItem item = (ListViewItem)sender;
            item.IsSelected = true;

        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OrderCustom_Click(object sender, RoutedEventArgs e)
        {

            FoodOrder obj = ((FrameworkElement)sender).DataContext as FoodOrder;
            HomeViewModel.GetInstance().btOrderCustom_Click(obj);
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {

            Foods obj = ((FrameworkElement)sender).DataContext as Foods;
            HomeViewModel.GetInstance().btOrderDetail_Click(obj);
        }

        private void DeleteFood_Click(object sender, RoutedEventArgs e)
        {
            FoodOrder obj = ((FrameworkElement)sender).DataContext as FoodOrder;
            HomeViewModel.GetInstance().DeleteFoodListOrder(obj);
        }

        private void ChooseType_Click(object sender, RoutedEventArgs e)
        {

            string obj = ((FrameworkElement)sender).DataContext as string;
            HomeViewModel.GetInstance().btTypeChoose(obj);
        }
    }
}
