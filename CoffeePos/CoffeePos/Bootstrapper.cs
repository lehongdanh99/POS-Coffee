using Caliburn.Micro;
using CoffeePos.ViewModels;
using System.Windows;

namespace CoffeePos
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<HomeViewModel>();
        }
    }
}
