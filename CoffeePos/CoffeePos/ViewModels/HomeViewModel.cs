using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace CoffeePos.ViewModels
{
    internal class HomeViewModel : Screen
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public HomeViewModel(Foods foodOrder = default)
        {
            
            bgLocally = new SolidColorBrush(Colors.Orange);
            bgDelivery = new SolidColorBrush(Colors.LightGray);
            VisibleLocally = Visibility.Hidden;
            Foods = GetFoods();
            
            TypeFoods = GetTypeFoods();
            if(foodOrders== null)
            {
                foodOrders = new List<Foods>();
            }
            if(foodOrder != null)
            {
                foodOrders.Add(foodOrder);
            }
            GetFoodOrderTotal();
            NotifyOfPropertyChange(() => FoodOrders);


        }

        private void GetFoodOrderTotal()
        {
            FoodOrderCount = foodOrders.Count;
            for(int i = 0; i < foodOrders.Count; i++)
            {
                AmountFood += foodOrders[i].FoodOrderPrice;
            }
        }

        private bool isBgLocally = true;

        private Visibility visibleLocally;
        public Visibility VisibleLocally 
        {

            get
            {
                return visibleLocally;
            }
            set
            {
                visibleLocally = value;
                NotifyOfPropertyChange(() => VisibleLocally);
            }
        }

        public Foods FoodSelected { get; set; }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }

            set
            {
                if (_selectedIndex == value)
                {
                    return;
                }


                _selectedIndex = value;

                
                NotifyOfPropertyChange(() => SelectedIndex);
                
                    btOrderDetail_Click();
                
                
            }
        }

        private int foodOrderCount = 0;

        public int FoodOrderCount
        { 
            get { return foodOrderCount; } 
            set { foodOrderCount = value; NotifyOfPropertyChange(() => FoodOrderCount); }
        }

        private double discountOrder = 0;

        public double DiscountOrder
        {
            get { return discountOrder; }
            set { discountOrder = value; NotifyOfPropertyChange(() => DiscountOrder); }
        }

        private double totalOrder = 0;

        public double TotalOrder
        {
            get { return totalOrder; }
            set { totalOrder = value; NotifyOfPropertyChange(() => TotalOrder); }
        }


        private double amountFood = 0;

        public double AmountFood
        {
            get { return amountFood; }
            set { amountFood = value; NotifyOfPropertyChange(() => AmountFood); }
        }

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

        private SolidColorBrush bgLocally;
        public SolidColorBrush BgLocally
        {
            get
            {
                return bgLocally;
            }
            set
            {
                bgLocally = value;
                NotifyOfPropertyChange(() => BgLocally);
            }
        }

        private SolidColorBrush bgDelivery;
        public SolidColorBrush BgDelivery 
        {
            get
            {
                return bgDelivery;
            }
            set
            {
                bgDelivery = value;
                NotifyOfPropertyChange(() => BgDelivery);
            }
        }


        private List<Foods> foodOrders;

        public List<Foods> FoodOrders
        {
            get { return foodOrders; }
            set { foodOrders = value; NotifyOfPropertyChange(() => FoodOrders); }
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
                new Foods("cafe swa da da da", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg"),
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
                FoodSelected = Foods[SelectedIndex];
                OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel(FoodSelected);
                WindowManager windowManager = new WindowManager();
                windowManager.ShowDialogAsync(orderDetailViewModel);
                



        }
        public void btTable_Click()
        {
            TablesViewModel tableViewModel = new TablesViewModel(false);
            WindowManager windowManager = new WindowManager();
            windowManager.ShowDialogAsync(tableViewModel);

        }

        public void btTableChoose_Click()
        {
            TablesViewModel tableViewModel = new TablesViewModel(true);
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

        public void LocallyClick()
        {

            if(isBgLocally != true)
            {
                BgLocally = new SolidColorBrush(Colors.Orange);
                BgDelivery = new SolidColorBrush(Colors.LightGray);
                isBgLocally = true;
                VisibleLocally = Visibility.Hidden;
            }

        }

        public void DeliveryClick()
        {
            if (isBgLocally == true)
            {
                BgLocally = new SolidColorBrush(Colors.LightGray);
                BgDelivery = new SolidColorBrush(Colors.Orange);
                isBgLocally = false;
                VisibleLocally = Visibility.Visible;
            }

        }
    }
}
