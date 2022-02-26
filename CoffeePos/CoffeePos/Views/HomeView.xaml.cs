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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Window
    {
        public HomeView()
        {
            InitializeComponent();
            var foods = GetFoods();
            var typeFoods = GetTypeFoods();
            ListTypeFoods.ItemsSource = typeFoods;
            var foodOrder = GetFoodOrder();
            if (foodOrder.Count > 0)
            {
                ListViewFoodOrder.ItemsSource = foodOrder;
            }
            if (foods.Count > 0)
            {
                ListViewFoods.ItemsSource = foods;
            }
        }
        private List<TypeFoods> GetTypeFoods()
        {
            return new List<TypeFoods>()
            {
                new TypeFoods("Ăn chính"),
                new TypeFoods("Ăn kèm"),
                new TypeFoods("Đồ uống"),
                new TypeFoods("Tráng miệng"),
                new TypeFoods("Bánh"),
                new TypeFoods("Bia"),
                new TypeFoods("Nước ngọt")
            };
        }

        private List<FoodOrder> GetFoodOrder()
        {
            return new List<FoodOrder>()
            {
                new FoodOrder("cafe sua","Không có phần thêm", 1, 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new FoodOrder("cafe sua","Không có phần thêm", 1, 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new FoodOrder("cafe sua","Không có phần thêm", 1, 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new FoodOrder("cafe sua","Không có phần thêm", 1, 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),

            };
        }

        private List<Foods> GetFoods()
        {
            return new List<Foods>()
            {
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),

            };
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);
        }

        private void MoveCursorMenu(int index)
        {
            TransitionMenuContent.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (0 + 60 * index), 0, 0);
        }
    }
}
