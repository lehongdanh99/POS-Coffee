using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.ViewModels
{
    internal class RegisterViewModel : Screen
    {
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
    }
}
