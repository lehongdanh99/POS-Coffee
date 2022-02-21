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
using CoffeePos.page;

namespace CoffeePos
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            var foods = GetFoods();
            if(foods.Count > 0)
            {
                ListViewFoods.ItemsSource = foods;
            }
        }

        private List<Food> GetFoods()
        {
            return new List<Food>()
            {
                new Food("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Food("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Food("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Food("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),

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
