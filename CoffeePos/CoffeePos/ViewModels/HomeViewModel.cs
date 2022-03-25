using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace CoffeePos.ViewModels
{
    internal class HomeViewModel : Screen
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public HomeViewModel()
        {
            
            Foods = GetFoods();

            TypeFoods = GetTypeFoods();

            FoodOrders = GetFoodOrder();

        }

        public Visibility VisibleLocally { get; set; }

        private List<Foods> foods;

        public List<Foods> Foods
        {
            get { return foods; }
            set { foods = value; }
        }

        private List<TypeFoods> typeFoods;

        public List<TypeFoods> TypeFoods
        {
            get { return typeFoods; }
            set { typeFoods = value; }
        }

        private List<FoodOrder> foodOrders;

        public List<FoodOrder> FoodOrders
        {
            get { return foodOrders; }
            set { foodOrders = value; }
        }

        private List<TypeFoods> GetTypeFoods()
        {
            return new List<TypeFoods>()
            {
                new TypeFoods("Ăn chính"),
                new TypeFoods("Ăn kèm"),
                new TypeFoods("Đồ uống"),
                new TypeFoods("Tráng miệng"),
                new TypeFoods("Bánh"),
                new TypeFoods("Bia"),
                new TypeFoods("Nước ngọt")
            };
        }

        private List<FoodOrder> GetFoodOrder()
        {
            return new List<FoodOrder>()
            {
                
            };
        }

        private List<Foods> GetFoods()
        {
            return new List<Foods>()
            {
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
                new Foods("cafe sua", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
            };
        }

        public void btOrderDetail_Click()
        {
            
            OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel();  
            WindowManager windowManager = new WindowManager();
            windowManager.ShowDialogAsync(orderDetailViewModel);
            
        }
        public void btTable_Click()
        {
            TablesViewModel tableViewModel = new TablesViewModel();
            WindowManager windowManager = new WindowManager();
            windowManager.ShowDialogAsync(tableViewModel);

        }
        public void btRegister_Click()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            WindowManager windowManager = new WindowManager();
            windowManager.ShowDialogAsync(registerViewModel);

        }

        public void btExit_Click()
        {
           
            Dispatcher.CurrentDispatcher.BeginInvoke(new System.Action(() =>
            {
                TryCloseAsync();
            }));
        }
    }
}
