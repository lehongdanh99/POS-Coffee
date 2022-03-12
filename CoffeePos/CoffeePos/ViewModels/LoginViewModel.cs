using Caliburn.Micro;
using CoffeePos.Common;
using System.Collections.ObjectModel;
using System.Security;
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
            if (Properties.Settings.Default.languageCode.Equals("en-US"))
            {
                LanguageSelected = 1;
            }
            else
            {
                LanguageSelected = 0;
            }
            
            Language = new ObservableCollection<string>
            {
                "Viet Nam",
                "English"
            };
            
        }

        //Public Method

        private ObservableCollection<string> language;
        public ObservableCollection<string> Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
                NotifyOfPropertyChange(() => Language);
            }
        }

        private int languageSelected;
        public int LanguageSelected
        {
            get
            {
                return languageSelected;
            }
            set
            {
                languageSelected = value;
                NotifyOfPropertyChange(() => LanguageSelected);
            }
        }
        public string Password { get; set; }

        
        public void btLogin_Click()
        {
            /*Code change language (Create new change language button and put it in)*/
            if (language[LanguageSelected].ToString() == "English")
            {
                Properties.Settings.Default.languageCode = "en-US";
            }
            else
            {
                Properties.Settings.Default.languageCode = "vi-VN";
            }
                
            Properties.Settings.Default.Save();
            //string response = restAPI.makeGetRequest();
            log.Debug("Btn login click");
            //Password.ToString();

            HomeViewModel homeViewModel = new HomeViewModel();
            WindowManager windowManager = new WindowManager();
            windowManager.ShowDialogAsync(homeViewModel);
            //MessageBox.Show("Login success");
        }

        public void btExit_Click()
        {
            if (language[LanguageSelected] == "English")
            {
                Properties.Settings.Default.languageCode = "en-US";
            }
            else
            {
                Properties.Settings.Default.languageCode = "vi-VN";
            }

        }

        
    }
}
