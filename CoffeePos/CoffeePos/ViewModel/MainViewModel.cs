using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CoffeePos.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        private BaseViewModel selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; }
        }
    }

}
