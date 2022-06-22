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
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        //private void BtnRegist_Click(object sender, RoutedEventArgs e)
        //{
        //    Customer customer = new Customer();
        //    //if(nameTxb.ToString() != null || phoneTxb != null)
        //    //{
        //    //    errTxt.Visibility = Visibility.Visible;
        //    //}    
        //    //else
        //    //{
        //    //    customer.name = nameTxb.ToString();
        //    //    customer.phone = phoneTxb.ToString();
        //    //    errTxt.Visibility = Visibility.Collapsed;
        //    //}    
        //    RegisterViewModel.GetInstance().RegistCustomer(customer);
        //    this.Hide();

        //}
    }
}
