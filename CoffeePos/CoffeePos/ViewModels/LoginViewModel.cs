using Caliburn.Micro;
using CoffeePos.Common;
using CoffeePos.Models;
using System;
using System.Collections.ObjectModel;
using System.Security;
using System.Windows;
using System.Windows.Threading;

namespace CoffeePos.ViewModels
{
    public class LoginViewModel : Screen
    {
        //Properties
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //Constructor
        public LoginViewModel()
        {
            Employee = getEmployees();
            if (Properties.Settings.Default.languageCode.Equals("en-US"))
            {
                Properties.Settings.Default.languageCode = "vi-VN";
                Properties.Settings.Default.Save();
                LanguageSelected = 0;
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

        private string password = "";
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        private string userName = "";

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

        public Visibility ErrorVisible { get; set; }

        private string errorValidate;

        public string ErrorValidate
        {
            get { return errorValidate; }
            set { errorValidate = value;
                NotifyOfPropertyChange(() => ErrorValidate);
            }
        }
        public ObservableCollection<Employee> getEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            foreach (Employee em in CommonMethod.GetInstance().readEmployeeJsonFileConfig())
            {
                employees.Add(em);
            }
            return employees;
        }

        private ObservableCollection<Employee> employee;

        public ObservableCollection<Employee> Employee
        {
            get { return employee; }
            set { employee = value; NotifyOfPropertyChange(() => Employee); }
        }
        public void btLogin_Click()
        {
            char[] newPass = Password.ToCharArray();
            Array.Reverse(newPass);
            string revertPass = new string(newPass);
            if (Password.Equals(string.Empty) || UserName.Equals(string.Empty))
            {
                ErrorVisible = Visibility.Visible;
                ErrorValidate = "Vui lòng nhập tên đăng nhập và mật khẩu";
            }

            else
            {
                string token = CommonMethod.Login(UserName.ToString(), revertPass);
                if(token != string.Empty)
                {
                    GlobalDef.token = token;
                    ErrorVisible = Visibility.Hidden;
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
                    log.Debug("Btn login click");
                    GlobalDef.windowManager.ShowDialogAsync(HomeViewModel.GetInstance());
                    Dispatcher.CurrentDispatcher.BeginInvoke(new System.Action(() =>
                    {
                        TryCloseAsync();
                    }));
                    return;
                }
                GlobalDef.windowManager.ShowDialogAsync(HomeViewModel.GetInstance());
                Dispatcher.CurrentDispatcher.BeginInvoke(new System.Action(() =>
                {
                    TryCloseAsync();
                }));
                ErrorVisible = Visibility.Visible;
                ErrorValidate = "Sai mật khẩu hoặc tên đăng nhập";
            }

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
            Dispatcher.CurrentDispatcher.BeginInvoke(new System.Action(() =>
            {
                TryCloseAsync();
            }));
        }

        
    }
}
