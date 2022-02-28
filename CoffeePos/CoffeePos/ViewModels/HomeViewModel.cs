using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.ViewModels
{
    internal class HomeViewModel : Screen
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public HomeViewModel()
        {

        }

        public void btOrderDetail_Click()
        {
            OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel();  
            WindowManager windowManager = new WindowManager();
            windowManager.ShowDialogAsync(orderDetailViewModel);
            
        }
    }
}
