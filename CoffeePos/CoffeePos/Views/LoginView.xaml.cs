using CoffeePos.Common;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CoffeePos.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public static readonly DependencyProperty SecurePasswordProperty = DependencyProperty.Register(
           "SecurePassword", typeof(SecureString), typeof(LoginView), new PropertyMetadata(default(SecureString)));

        public SecureString SecurePassword
        {
            get { return (SecureString)GetValue(SecurePasswordProperty); }
            set { SetValue(SecurePasswordProperty, value); }
        }
        public LoginView()
        {
            InitializeComponent();
            
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            SecurePassword = ((PasswordBox)sender).SecurePassword;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }
    }
}
