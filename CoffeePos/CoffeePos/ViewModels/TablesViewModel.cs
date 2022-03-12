using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.ViewModels
{
    internal class TablesViewModel : Screen
    {
        public void btDetail_Click()
        {
            TableDetailViewModel registerViewModel = new TableDetailViewModel();
            WindowManager windowManager = new WindowManager();
            windowManager.ShowDialogAsync(registerViewModel);

        }
    }

    
}
