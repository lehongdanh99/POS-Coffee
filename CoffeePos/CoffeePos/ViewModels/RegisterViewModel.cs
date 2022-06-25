using Caliburn.Micro;
using CoffeePos.Common;
using CoffeePos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CoffeePos.ViewModels
{
    internal class RegisterViewModel : Screen
    {
        private static RegisterViewModel _instance;
        public static RegisterViewModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new RegisterViewModel();
                }
            }
            return _instance;
        }
        public RegisterViewModel()
        {

            if (Properties.Settings.Default.languageCode.Equals ("en-US"))
            {
                Sex = new ObservableCollection<string>
                {
                    "Male",
                    "Female"
                };
            }
            else
            {
                Sex = new ObservableCollection<string>
                {
                    "Nam",
                    "Nữ"
                };
            }
            
            SexSelected = 0;
        }


        private Visibility errTxtVisible = Visibility.Collapsed;

        public Visibility ErrTxtVisible
        {
            get { return errTxtVisible; }
            set { errTxtVisible = value; NotifyOfPropertyChange(() => ErrTxtVisible); }
        }

        //Public Method

        private ObservableCollection<string> sex;
        public ObservableCollection<string> Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
                NotifyOfPropertyChange(() => Sex);
            }
        }

        private int sexSelected;
        public int SexSelected
        {
            get
            {
                return sexSelected;
            }
            set
            {
                sexSelected = value;
                NotifyOfPropertyChange(() => SexSelected);
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value;
                NotifyOfPropertyChange(() => Phone);
            }
        }


        public void RegistCustomer()
        {
            if(Name == null || Phone == null)
            {
                ErrTxtVisible = Visibility.Visible;
                return;
            }
                Customer customer = new Customer();
            customer.name = Name;
            customer.phone = Phone;
            bool result = RestAPIClient<Customer>.PostData(customer, GlobalDef.CUSTOMER_CREATE_API, GlobalDef.token);

            if (result)
            {
                MessageBoxViewModel messageBoxViewModel = new MessageBoxViewModel("Đăng ký thành công");
                //WindowManager windowManager = new WindowManager();
                GlobalDef.windowManager.ShowDialogAsync(messageBoxViewModel);
                this.TryCloseAsync();
            }
            else
            {
                MessageBoxViewModel messageBoxViewModel = new MessageBoxViewModel("Đăng kí thất bại");
                GlobalDef.windowManager.ShowDialogAsync(messageBoxViewModel);
            }    
        }
    }
}
