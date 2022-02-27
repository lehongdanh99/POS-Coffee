using Caliburn.Micro;
using CoffeePos.Common;
using System.Windows;


namespace CoffeePos.ViewModels
{
    public class LoginViewModel : Screen
    {
        //Properties
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        RestAPIClient restAPI;
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
            string response = restAPI.makeGetRequest();
            log.Debug("Btn login click");
            MessageBox.Show("Login success");
        }
    }
}
