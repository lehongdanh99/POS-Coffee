using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.ViewModels
{
    internal class MessageBoxViewModel : Screen
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static MessageBoxViewModel _instance;
        //public static MessageBoxViewModel GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new MessageBoxViewModel();
        //        }
        //    }
        //    return _instance;
        //}
        public MessageBoxViewModel(string message)
        {
            Message = message;
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        //public void BacktoHomeView()
        //{
        //    WindowManager windowManager = new WindowManager();
        //    windowManager.ShowWindowAsync(HomeViewModel.GetInstance());
        //}
    }
}
