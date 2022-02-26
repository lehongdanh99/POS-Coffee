using Caliburn.Micro;
using System.Windows;


namespace CoffeePos.ViewModels
{
    public class LoginViewModel : Screen
    {
        //Properties

        //Constructor
        public LoginViewModel()
        {

        }

        //Public Method
        public void btLogin_Click()
        {
            /*Code change language (Create new change language button and put it in)*/
            //if(string == items[0]){
            //Properties.Settings.Default.languageCode = "en-US";
            //}
            //else
            //Properties.Settings.Default.languageCode = "vi-VN";
            //Properties.Settings.Default.Save();
            MessageBox.Show("Login success");
        }
    }
}
