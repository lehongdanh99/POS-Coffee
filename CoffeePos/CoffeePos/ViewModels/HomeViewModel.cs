using Caliburn.Micro;
using CoffeePos.Common;
using CoffeePos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using static CoffeePos.FoodOrderModel;
using static CoffeePos.Models.ReceiptModel;

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
        public HomeViewModel()
        {
            bgLocally = new SolidColorBrush(Colors.Orange);
            bgDelivery = new SolidColorBrush(Colors.LightGray);
            VisibleLocally = Visibility.Hidden;
            FoodsMenu = GetFoods();
            AllFoods = GetFoods();
            TypeFoods = GetTypeFoods();
            if(listViewFoodOrders == null)
            {
                listViewFoodOrders = new ObservableCollection<FoodOrder>();
            }
            ListViewFoodOrders = FoodOrderModel.GetInstance().FoodOrders;
            GetFoodOrderTotal();

            
        }

        public void GetFoodOrderTotal()
        {
            if (listViewFoodOrders == null)
            {
                return;
            }
            foodOrderTotalCount = ListViewFoodOrders.Count;
            HomePayment = 0;
            for (int i = 0; i < ListViewFoodOrders.Count; i++)
            {
                HomePayment += ListViewFoodOrders[i].FoodOrderPrice;
            }
            if (tableNum != 0 && foodOrderTotalCount != 0)
            {
                EnableOrder = true;
            }
            else
            {
                EnableOrder = false;
            }
            NotifyOfPropertyChange(() => EnableOrder);
            TotalOrder = HomePayment - DiscountOrder;
            NotifyOfPropertyChange(() => FoodOrderTotalCount);
            NotifyOfPropertyChange(() => HomePayment);
            NotifyOfPropertyChange(() => TotalOrder);
            NotifyOfPropertyChange(() => TableNum);
        }

        ListOrderViewModel listOrderViewModel;

        private bool isBgLocally = true;

        private bool canSwitchTable = false;

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
                //btOrderDetail_Click(_selectedIndexFood);
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

        private int _selectedIndexOrder = -1;
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
                //if(_selectedIndexOrder >= 0)
                //{
                //    btOrderCustom_Click();
                //}
                
                NotifyOfPropertyChange(() => SelectedIndexOrder);
            }
        }


        private ObservableCollection<FoodOrder> listViewFoodOrders;

        public ObservableCollection<FoodOrder> ListViewFoodOrders
        {
            get { return listViewFoodOrders; }
            set { listViewFoodOrders = value; NotifyOfPropertyChange(() => ListViewFoodOrders); }
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


        private double homePayment = 0;

        public double HomePayment
        {
            get { return homePayment; }
            set { homePayment = value; NotifyOfPropertyChange(() => HomePayment); }
        }

        private int tableNum = 0;

        public int TableNum
        {
            get { return tableNum; }
            set { 
                tableNum = value; 
                NotifyOfPropertyChange(() => TableNum);
                
            }
        }

        private bool enableOrder = false;

        public bool EnableOrder
        {
            get { return enableOrder; }
            set { enableOrder = value; NotifyOfPropertyChange(() => EnableOrder); }
        }

        private ObservableCollection<Foods> foods;

        public ObservableCollection<Foods> FoodsMenu
        {
            get { return foods; }
            set { foods = value; NotifyOfPropertyChange(() => FoodsMenu); }
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


        

        private ObservableCollection<string> GetTypeFoods()
        {
            ObservableCollection<string> typeFood = new ObservableCollection<string>();

            for(int i = 0; i < FoodsMenu.Count; i++)
            {
                if(typeFood.Count != 0)
                {
                    bool isTypeAdd = false;
                    for(int j = 0; j < typeFood.Count; j++)
                    {
                        if(FoodsMenu[i].FoodType == typeFood[j])
                            isTypeAdd = true;
                    }
                    if(!isTypeAdd)
                        typeFood.Add(FoodsMenu[i].FoodType);
                }
                else
                    typeFood.Add(FoodsMenu[i].FoodType);
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
            ObservableCollection<Foods> getFood = new ObservableCollection<Foods>();
            //return new ObservableCollection<Foods>()
            //{
            //    new Foods("cafe sữa tươi", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Cafe"),
            //    new Foods("cafe sữa đá", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Cafe"),
            //    new Foods("nước cam", 10000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Nước ép"),
            //    new Foods("nước dừa", 10000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Nước ép"),
            //    new Foods("nước bưởi", 10000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Nước ép"),
            //    new Foods("nước táo", 10000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Nước ép"),
            //    new Foods("sữa chua", 10000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Món ăn kèm"),
            //    new Foods("trà sữa", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Trà"),
            //    new Foods("trà sữa trân châu", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Trà"),
            //    new Foods("trà xanh", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Trà"),
            //    new Foods("trà táo", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Trà"),
            //    new Foods("trà đào", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Trà"),
            //    new Foods("soda táo", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Soda"),
            //    new Foods("soda dứa", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Soda"),
            //    new Foods("bạc sỉu", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Cafe"),
            //    new Foods("nước mơ", 15000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Nước ép"),
            //    new Foods("Sườn bì chả trứng", 30000,"/Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg", "Món ăn kèm"),
            //};
            foreach (Foods food in CommonMethod.GetInstance().readFoodJsonFileConfig())
            {
                getFood.Add(food);
            }
            return getFood;
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
            FoodsMenu = GetFoodByType(SelectedTypeFood);
            NotifyOfPropertyChange(() => FoodsMenu);
        }

        public void btListOrder_Click()
        {

            //orderDetailViewModel.eventChange += HandleCallBack;

                ListOrderViewModel listOrderViewModel = new ListOrderViewModel();
            
            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(listOrderViewModel);
        }


        public void btOrderDetail_Click(Foods SelectedListFood)
        {

            FoodSelected = SelectedListFood;

            OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel(FoodSelected);
            orderDetailViewModel.eventChange += HandleCallBack;

            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(orderDetailViewModel);


        }

        public void HandleCallBack(FoodOrder food)
        {
            
            FoodOrderModel.GetInstance().FoodOrders.Add(food);
            
            
            
            
            GetFoodOrderTotal();
        }


        public void btOrderCustom_Click(FoodOrder foodOrder)
        {
            
            FoodOrderSelected = foodOrder;

            OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel(default,FoodOrderSelected);
            orderDetailViewModel.eventCustomChange += HandleCallBackCustom;

            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(orderDetailViewModel);
        }

        public void DeleteFoodListOrder(FoodOrder foodorder)
        {
            FoodOrderModel.GetInstance().FoodOrders.Remove(foodorder);
            GetFoodOrderTotal();
        }

        public void HandleCallBackCustom(FoodOrder food)
        {
            for(int i = 0; i < ListViewFoodOrders.Count; i++)
            {
                if(food.FoodOrderName == ListViewFoodOrders[i].FoodOrderName)
                {
                    ListViewFoodOrders[i]  = food;
                    
                    
                }
            }
            //ListViewFoodOrders[food] = food;

            GetFoodOrderTotal();
        }

        public void btTable_Click()
        {
            //this.TryCloseAsync();
            //TablesViewModel tableViewModel = new TablesViewModel(false);
            GlobalDef.IsChooseTableToOrder = false;
            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(TablesViewModel.GetInstance());

        }

        public void btTableChoose_Click()
        {
            //TablesViewModel tableViewModel = new TablesViewModel(true);
            //tableViewModel.eventChooseTableToOrder += HandleCallBacChooseTable;
            GlobalDef.IsChooseTableToOrder = true;
            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(TablesViewModel.GetInstance());

        }
        
        public void btOrderLocally_Click()
        {
            Receipt receipt = new Receipt();
            receipt.Foods = FoodOrderModel.GetInstance().FoodOrders.ToList();
            receipt.Table = TableNum.ToString();
            receipt.Total = TotalOrder;
            receipt.Payment = HomePayment;
            TableDetailViewModel tableDetailViewModel = new TableDetailViewModel(receipt, false);
            //tableDetailViewModel.eventChange += HandleCallBack;
            GlobalDef.DetailFromHome = Visibility.Collapsed;
            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(tableDetailViewModel);
        }

        public void btOrderDelivery_Click()
        {

        }

        public void btListVoucher_Click()
        {
            ListVouchersViewModel listVouchersViewModel = new ListVouchersViewModel();
            //tableDetailViewModel.eventChange += HandleCallBack;
            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(listVouchersViewModel);
        }

        public void HandleCallBacChooseTable(int TableChoose)
        {
            tableNum = TableChoose;
            NotifyOfPropertyChange(() => TableNum);
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
