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
using System.Windows.Media;
using System.Windows.Threading;

namespace CoffeePos.ViewModels
{
    internal class HomeViewModel : Screen
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static HomeViewModel _instance;
        TablesViewModel tableViewModel;
        public static HomeViewModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new HomeViewModel();
                }
            }
            return _instance;
        }
        public HomeViewModel(Foods foodOrder = default)
        {
            bgLocally = new SolidColorBrush(Colors.Orange);
            bgDelivery = new SolidColorBrush(Colors.LightGray);
            VisibleLocally = Visibility.Hidden;
            Foods = GetFoods();
            AllFoods = GetFoods();
            TypeFoods = GetTypeFoods();
            if(foodOrders== null)
            {
                foodOrders = new ObservableCollection<FoodOrder>();
            }
            GetFoodOrderTotal();
            NotifyOfPropertyChange(() => FoodOrders);


        }

        private void GetFoodOrderTotal()
        {
            foodOrderTotalCount = foodOrders.Count;
            AmountFood = 0;
            for (int i = 0; i < foodOrders.Count; i++)
            {
                AmountFood += foodOrders[i].FoodOrderPrice;
            }
            TotalOrder = AmountFood - DiscountOrder;
            NotifyOfPropertyChange(() => FoodOrderTotalCount);
            NotifyOfPropertyChange(() => AmountFood);
            NotifyOfPropertyChange(() => TotalOrder);

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

        private Visibility visibleTable;
        public Visibility VisibleTable
        {

            get
            {
                return visibleTable;
            }
            set
            {
                visibleTable = value;
                NotifyOfPropertyChange(() => VisibleTable);
            }
        }

        private bool isOrderSelected = false;

        public Foods FoodSelected { get; set; }

        public FoodOrder FoodOrderSelected { get; set; }

        private int _selectedIndexFood = -1;
        public int SelectedIndexFood
        {
            get
            {
                return _selectedIndexFood;
            }

            set
            {
                if (_selectedIndexFood == value)
                {
                    return;
                }
                _selectedIndexFood = value;
                isOrderSelected = false;
                btOrderDetail_Click(_selectedIndexFood);
                NotifyOfPropertyChange(() => SelectedIndexFood);
            }
        }

        private string _selectedIndexTypeFood;
        public string SelectedIndexTypeFood
        {
            get
            {
                return _selectedIndexTypeFood;
            }

            set
            {
                if (_selectedIndexTypeFood == value)
                {
                    return;
                }
                _selectedIndexTypeFood = value;
                btTypeChoose(_selectedIndexTypeFood);
                NotifyOfPropertyChange(() => SelectedIndexTypeFood);
            }
        }

        private int _selectedIndexOrder;
        public int SelectedIndexOrder
        {
            get
            {
                return _selectedIndexOrder;
            }

            set
            {
                if (_selectedIndexOrder == value)
                {
                    return;
                }
                _selectedIndexOrder = value;
                isOrderSelected = true;
                if(_selectedIndexOrder >= 0)
                {
                    btOrderCustom_Click(_selectedIndexOrder);
                }
                
                NotifyOfPropertyChange(() => SelectedIndexOrder);
            }
        }

        private int foodOrderTotalCount = 0;

        public int FoodOrderTotalCount
        { 
            get { return foodOrderTotalCount; } 
            set { foodOrderTotalCount = value; NotifyOfPropertyChange(() => FoodOrderTotalCount); }
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

        private int tableNum = 0;

        public int TableNum
        {
            get { return tableNum; }
            set { tableNum = value; NotifyOfPropertyChange(() => TableNum);
                if (tableNum != 0)
                {
                    EnableOrder = true;
                } 
                else
                {
                    EnableOrder = false;
                }
                NotifyOfPropertyChange(() => EnableOrder);
            }
        }

        private bool enableOrder = false;

        public bool EnableOrder
        {
            get { return enableOrder; }
            set { enableOrder = value; NotifyOfPropertyChange(() => EnableOrder); }
        }

        private ObservableCollection<Foods> foods;

        public ObservableCollection<Foods> Foods
        {
            get { return foods; }
            set { foods = value; NotifyOfPropertyChange(() => Foods); }
        }

        private ObservableCollection<Foods> allFoods;
        public ObservableCollection<Foods> AllFoods
        {
            get { return allFoods; }
            set { allFoods = value; NotifyOfPropertyChange(() => AllFoods); }
        }

        private ObservableCollection<string> typeFoods;

        public ObservableCollection<string> TypeFoods
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


        private ObservableCollection<FoodOrder> foodOrders;

        public ObservableCollection<FoodOrder> FoodOrders
        {
            get { return foodOrders; }
            set { foodOrders = value; NotifyOfPropertyChange(() => FoodOrders); }
        }

        private ObservableCollection<string> GetTypeFoods()
        {
            ObservableCollection<string> typeFood = new ObservableCollection<string>();

            for(int i = 0; i < Foods.Count; i++)
            {
                if(typeFood.Count != 0)
                {
                    bool isTypeAdd = false;
                    for(int j = 0; j < typeFood.Count; j++)
                    {
                        if(Foods[i].FoodType == typeFood[j])
                            isTypeAdd = true;
                    }
                    if(!isTypeAdd)
                        typeFood.Add(Foods[i].FoodType);
                }
                else
                    typeFood.Add(Foods[i].FoodType);
            }    

            return typeFood;        
        }

        private ObservableCollection<Foods> GetFoodOrder()
        {
            return new ObservableCollection<Foods>()
            {
                new Foods("cafe sữa tươi", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Cafe"),
                new Foods("cafe swa da", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Cafe"),
                new Foods("nước cam", 12500,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Cafe"),
            };
        }

        private ObservableCollection<Foods> GetFoods()
        {
            return new ObservableCollection<Foods>()
            {
                new Foods("cafe sữa tươi", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Cafe"),
                new Foods("cafe sữa đá", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Cafe"),
                new Foods("nước cam", 10000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Nước ép"),
                new Foods("nước dừa", 10000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Nước ép"),
                new Foods("nước bưởi", 10000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Nước ép"),
                new Foods("nước táo", 10000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Nước ép"),
                new Foods("sữa chua", 10000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Món ăn kèm"),
                new Foods("trà sữa", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Trà"),
                new Foods("trà sữa trân châu", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Trà"),
                new Foods("trà xanh", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Trà"),
                new Foods("trà táo", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Trà"),
                new Foods("trà đào", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Trà"),
                new Foods("soda táo", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Soda"),
                new Foods("soda dứa", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Soda"),
                new Foods("bạc sỉu", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Cafe"),
                new Foods("nước mơ", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Nước ép"),
               
            };
        }

        private ObservableCollection<Foods> GetFoodByType(string foodType)
        {
            ObservableCollection<Foods> Listfoods = new ObservableCollection<Foods>();
            for(int i = 0; i < AllFoods.Count; i++)
            {
                if(AllFoods[i].FoodType == foodType)
                {
                    Listfoods.Add(AllFoods[i]);
                }
            }

            return Listfoods;
        }

        public void btTypeChoose(string SelectedTypeFood)
        {
            Foods = GetFoodByType(SelectedTypeFood);
            NotifyOfPropertyChange(() => Foods);
        }
        
        public void btOrderDetail_Click(int SelectedListFood)
        {
            
                FoodSelected = Foods[SelectedListFood];
            
                
                OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel(FoodSelected);
                orderDetailViewModel.eventChange += HandleCallBack;

                WindowManager windowManager = new WindowManager();
                windowManager.ShowWindowAsync(orderDetailViewModel);
        }

        public void HandleCallBack(FoodOrder food)
        {
            if(_selectedIndexFood >= 0)
            {
                FoodOrders.Add(food);
            }
            
            
            
            GetFoodOrderTotal();
        }

        public void btOrderCustom_Click(int SelectedListFood)
        {
            if(SelectedListFood >= 0)
            {
                FoodOrderSelected = FoodOrders[SelectedListFood];
            }
            

            OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel(default,FoodOrderSelected);
            orderDetailViewModel.eventCustomChange += HandleCallBackCustom;

            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(orderDetailViewModel);
        }

        public void HandleCallBackCustom(FoodOrder food)
        {
            if (_selectedIndexOrder >= 0)
            {
                FoodOrders[SelectedIndexOrder] = food;
            }

            NotifyOfPropertyChange(() => FoodOrders);
            GetFoodOrderTotal();
        }

        public void btTable_Click()
        {
            TablesViewModel tableViewModel = new TablesViewModel(false);

            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(tableViewModel);

        }

        public void btTableChoose_Click()
        {
            if(tableViewModel == null)
            {
                tableViewModel = new TablesViewModel(true);
            }
            tableViewModel.eventChooseTableToOrder += HandleCallBacChooseTable;
            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(tableViewModel);

        }

        public void btOrderLocally_Click()
        {

        }

        public void btOrderDelivery_Click()
        {

        }

        public void HandleCallBacChooseTable(int TableChoose)
        {
            TableNum = TableChoose;
            NotifyOfPropertyChange(() => TableNum);
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
                VisibleTable = Visibility.Visible;
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
                VisibleTable = Visibility.Hidden;
            }

        }
    }
}
