using CoffeePos.Common;
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
    /// Interaction logic for OrderDetailView.xaml
    /// </summary>
    public partial class OrderDetailView : Window
    {
        public OrderDetailView()
        {
            InitializeComponent();

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SugarClick(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(RadioBtnSugar100.IsChecked))
            {
                GlobalDef.SugarPercent = "";
            }
            else if(Convert.ToBoolean(RadioBtnSugar70.IsChecked))
            {
                GlobalDef.SugarPercent = "Đường 70";
            }
            else if (Convert.ToBoolean(RadioBtnSugar50.IsChecked))
            {
                GlobalDef.SugarPercent = "Đường 50";
            }
        }
        private void IceClick(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(RadioBtnIce100.IsChecked))
            {
                GlobalDef.IcePercent = "";
            }
            else if (Convert.ToBoolean(RadioBtnIce70.IsChecked))
            {
                GlobalDef.IcePercent = "Đá 70";
            }
            else if (Convert.ToBoolean(RadioBtnIce50.IsChecked))
            {
                GlobalDef.IcePercent = "Đá 50";
            }
        }
    }
}
