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
    /// Interaction logic for ReceiptReportView.xaml
    /// </summary>
    public partial class ReceiptReportView : Window
    {
        public ReceiptReportView()
        {
            InitializeComponent();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
