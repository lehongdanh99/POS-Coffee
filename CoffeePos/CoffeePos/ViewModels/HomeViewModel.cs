using Caliburn.Micro;
using CoffeePos.Common;
using CoffeePos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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
            getDataHome();
            getCustomer();
        }

        public void getDataHome()
        {
            bgLocally = new SolidColorBrush(Colors.DarkSlateGray);
            bgDelivery = new SolidColorBrush(Colors.White);
            VisibleLocally = Visibility.Hidden;
            VisibleDelivery = Visibility.Visible;
            FoodsMenu = GetFoods();
            AllFoods = GetFoods();
            Customer = getCustomer();
            TypeFoods = GetTypeFoods();
            if (listViewFoodOrders == null)
            {
                listViewFoodOrders = new ObservableCollection<FoodOrder>();
            }
            ListViewFoodOrders = FoodOrderModel.GetInstance().FoodOrders;
            GetFoodOrderTotal();
            foreach (var foodOrder in FoodsMenu)
            {
                SearchFood.Add(foodOrder.name);
            }
            foreach (var customer in Customer)
            {
                SearchCustomer.Add(customer.phone);
            }
        }

        public ObservableCollection<Customer> getCustomer()
        {
            ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
            foreach (var cus in RestAPIClient<Customer>.parseJsonToModel(GlobalDef.CUSTOMER_API))
            {
                customers.Add(cus);
            }
            return customers;
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
            if (tableNum != "0" && foodOrderTotalCount != 0)
            {
                EnableOrder = true;
            }
            else
            {
                EnableOrder = false;
            }
            DiscountOrder = 0;
            NotifyOfPropertyChange(() => EnableOrder);
            NotifyOfPropertyChange(() => DiscountOrder);
            TotalOrder = HomePayment - (HomePayment*DiscountOrder/100);
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

        private Visibility visibleDelivery;
        public Visibility VisibleDelivery
        {

            get
            {
                return visibleDelivery;
            }
            set
            {
                visibleDelivery = value;
                NotifyOfPropertyChange(() => VisibleDelivery);
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

        private List<string> searchFood = new List<string>();

        public List<string> SearchFood
        {
            get { return searchFood; }
            set { searchFood = value; NotifyOfPropertyChange(() => SearchFood); }
        }

        private List<string> searchCustomer = new List<string>();

        public List<string> SearchCustomer
        {
            get { return searchCustomer; }
            set { searchCustomer = value; NotifyOfPropertyChange(() => SearchCustomer); }
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

        private int discountOrder = 0;

        public int DiscountOrder
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

        public int ReceiptIdtoEdit = 0;

        private string tableNum = "0";

        public string TableNum
        {
            get { return tableNum; }
            set { 
                tableNum = value; 
                NotifyOfPropertyChange(() => TableNum);
                
            }
        }

        private string typeChoose;

        public string TypeChoose
        {
            get { return typeChoose; }
            set { typeChoose = value; }
        }


        private bool enableOrder = false;

        public bool EnableOrder
        {
            get { return enableOrder; }
            set { enableOrder = value; NotifyOfPropertyChange(() => EnableOrder); }
        }

        private ObservableCollection<Customer> customer;

        public ObservableCollection<Customer> Customer
        {
            get { return customer; }
            set { customer = value; NotifyOfPropertyChange(() => Customer); }
        }

        private ObservableCollection<Foods> foods;

        public ObservableCollection<Foods> FoodsMenu
        {
            get { return foods; }
            set { foods = value; NotifyOfPropertyChange(() => FoodsMenu); }
        }

        private ObservableCollection<Foods> foodsHooby = new ObservableCollection<Foods>();

        public ObservableCollection<Foods> FoodsHooby
        {
            get { return foodsHooby; }
            set { foodsHooby = value; NotifyOfPropertyChange(() => FoodsHooby); }
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
            typeFood.Add("Tất cả");
            for (int i = 0; i < FoodsMenu.Count; i++)
            {
                if(typeFood.Count != 0)
                {
                    bool isTypeAdd = false;
                    for(int j = 0; j < typeFood.Count; j++)
                    {
                        if(FoodsMenu[i].type == typeFood[j])
                            isTypeAdd = true;
                    }
                    if(!isTypeAdd)
                        typeFood.Add(FoodsMenu[i].type);
                }
                else
                    typeFood.Add(FoodsMenu[i].type);
            }
            typeFood.Add("Sở thích");

            return typeFood;        
        }


        private ObservableCollection<Foods> GetFoods()
        {
            ObservableCollection<Foods> getFood = new ObservableCollection<Foods>();

            foreach (Foods food in RestAPIClient<Foods>.parseJsonToModel(GlobalDef.FOOD_API))
            {
                food.FoodPrice = food.drinkCakeVariations[0].price;
                getFood.Add(food);
            }
            return getFood;
        }

        private ObservableCollection<Foods> GetFoodByType(string foodType)
        {
            TypeChoose = foodType;
            ObservableCollection<Foods> Listfoods = new ObservableCollection<Foods>();
            if(foodType == "Sở thích")
            {
                if(CustomerSearch != null)
                {

                    foreach (Foods food in RestAPIClient<Foods>.parseJsonToModel(GlobalDef.FOODHOBBY_API + CustomerSearch.Id))
                    {
                        Foods foodAdd = RestAPIClient<Foods>.GetDataById(GlobalDef.FOOD_API+ @"/"+ food.drinkCakeId, GlobalDef.token);

                        foodAdd.FoodPrice = foodAdd.drinkCakeVariations[0].price;
                        foodAdd.note = food.note;
                        Listfoods.Add(foodAdd);
                        FoodsHooby.Add(food);
                    }
                }    
                
            }    
            for(int i = 0; i < AllFoods.Count; i++)
            {
                if(AllFoods[i].type == foodType)
                {
                    Listfoods.Add(AllFoods[i]);
                }
            }

            return Listfoods;
        }

        private bool isEditting = true;

        public bool IsEditting
        {
            get { return isEditting; }
            set { isEditting = value; NotifyOfPropertyChange(() => IsEditting); }
        }

        public void btTypeChoose(string SelectedTypeFood)
        {
            if (SelectedTypeFood == "Tất cả")
            {
                FoodsMenu = GetFoods();
                return;
            }
            FoodsMenu = GetFoodByType(SelectedTypeFood);
            NotifyOfPropertyChange(() => FoodsMenu);
        }
        public void SearchFoodChange(string search)
        {
            if (search == string.Empty)
            {
                FoodsMenu = GetFoods();
            }
            else
            {
                foreach (var food in FoodsMenu)
                {
                    if (search == food.name)
                    {
                        FoodsMenu.Clear();
                        FoodsMenu.Add(food);
                        return;
                    }
                }
            }


        }

        private Customer customerSearch;

        public Customer CustomerSearch
        {
            get { return customerSearch; }
            set { customerSearch = value; }
        }

        public void SearchCustomerChange(string search)
        {
            //if (search == string.Empty)
            //{
            //    FoodsMenu = GetFoods();
            //}
            //else
            //{
                foreach (var customer in Customer)
                {
                    if (search == customer.phone)
                    {
                        CustomerSearch = customer;
                        return;
                    }
                }
            //}


        }

        public void btListOrder_Click()
        {

            //orderDetailViewModel.eventChange += HandleCallBack;

            //ListOrderViewModel listOrderViewModel = new ListOrderViewModel();

            //WindowManager windowManager = new WindowManager();
            ListOrderViewModel.GetInstance().getDataListOrder();
            GlobalDef.windowManager.ShowDialogAsync(ListOrderViewModel.GetInstance());
            
        }


        public void btOrderDetail_Click(Foods SelectedListFood)
        {
             
            FoodSelected = SelectedListFood;
            if(SelectedListFood.type == "Bánh")
            {
                GlobalDef.IsCakeChoose = Visibility.Collapsed;
            }    
            else
            {
                GlobalDef.IsCakeChoose = Visibility.Visible;
            }    
            OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel(FoodSelected);
            orderDetailViewModel.eventChange += HandleCallBack;

            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowDialogAsync(orderDetailViewModel);


        }

        public void HandleCallBack(FoodOrder food)
        {
            food.FoodOrderID = FoodOrderModel.GetInstance().FoodOrders.Count() + 1;
            FoodOrderModel.GetInstance().FoodOrders.Add(food);
            
            
            
            
            GetFoodOrderTotal();
        }


        public void btOrderCustom_Click(FoodOrder foodOrder)
        {
            
            FoodOrderSelected = foodOrder;
            if (foodOrder.FoodType == "Bánh")
            {
                GlobalDef.IsCakeChoose = Visibility.Collapsed;
            }
            else
            {
                GlobalDef.IsCakeChoose = Visibility.Visible;
            }
            OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel(default,FoodOrderSelected);
            orderDetailViewModel.eventCustomChange += HandleCallBackCustom;

            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowDialogAsync(orderDetailViewModel);
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
                if(food.FoodOrderID == ListViewFoodOrders[i].FoodOrderID)
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
            GlobalDef.IsChooseMoreTable = false;
            TablesViewModel.GetInstance().getData();
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowDialogAsync(TablesViewModel.GetInstance());

        }

        public void btTableChoose_Click()
        {
            //TablesViewModel tableViewModel = new TablesViewModel(true);
            //tableViewModel.eventChooseTableToOrder += HandleCallBacChooseTable;
            GlobalDef.IsChooseTableToOrder = true;
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowDialogAsync(TablesViewModel.GetInstance());

        }

        public void btMoreTableChoose_Click()
        {
            GlobalDef.IsChooseTableToOrder = true;
            GlobalDef.IsChooseMoreTable = true;
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowDialogAsync(TablesViewModel.GetInstance());

        }

        public void btOrderLocally_Click()
        {
            var numbersTable = TableNum.Split(',').Select(Int32.Parse).ToList();
            Receipt receipt = new Receipt();
            receipt.Foods = FoodOrderModel.GetInstance().FoodOrders.ToList();
            receipt.Table = TableNum;
            receipt.TotalPrice = TotalOrder;
            receipt.Payment = HomePayment;
            receipt.DiscountPrice = voucherToOrder;
            if(ReceiptIdtoEdit != 0)
            {
                receipt.Id = ReceiptIdtoEdit;
            }    
            GlobalDef.ReceiptDetail = receipt;
            GlobalDef.canEditDetail = false;
            GlobalDef.IsDeliveryPayment = false;
            TableDetailViewModel.GetInstance().getdataTableDetail();
            //TableDetailViewModel tableDetailViewModel = new TableDetailViewModel(receipt, false);
            //tableDetailViewModel.eventChange += HandleCallBack;
            GlobalDef.DetailFromHome = Visibility.Collapsed;
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowDialogAsync(TableDetailViewModel.GetInstance());
        }

        public void btOrderDelivery_Click()
        {
            Receipt receipt = new Receipt();
            receipt.Foods = FoodOrderModel.GetInstance().FoodOrders.ToList();
            receipt.TotalPrice = TotalOrder;
            receipt.DiscountPrice = voucherToOrder;
            receipt.Payment = HomePayment;
            receipt.CheckOut = DateTime.Now.ToString("HH:mm");
            receipt.Note = string.Empty;
            GlobalDef.IsDeliveryPayment = true;
            GlobalDef.ReceiptPayment = receipt;
            ListOrderViewModel.GetInstance().PaymentReceipt(receipt);
            //FoodOrderModel.GetInstance().FoodOrders.Clear();
            TableNum = "0";
            ListViewFoodOrders.Clear();
            GetFoodOrderTotal();
            DiscountOrder = 0;
        }

        public void btListVoucher_Click()
        {
            ListVouchersViewModel.GetInstance().GetEnableVoucher();
            //ListVouchersViewModel listVouchersViewModel = new ListVouchersViewModel();
            //listVouchersViewModel.eventChooseVoucher = HandleCallBackChooseVoucher;
            GlobalDef.IsChooseVoucerToOrder = false;
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowDialogAsync(ListVouchersViewModel.GetInstance());
            
        }

        public void btChooseVoucher_Click()
        {
            ListVouchersViewModel.GetInstance().GetEnableVoucher();
            //listVouchersViewModel.eventChooseVoucher = HandleCallBackChooseVoucher;
            GlobalDef.IsChooseVoucerToOrder = true;
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowDialogAsync(ListVouchersViewModel.GetInstance());
        }

        public Voucher voucherToOrder = new Voucher();
        public void HandleCallBackChooseVoucher(Voucher selectedVoucher)
        {
            if (selectedVoucher.value == 0)
            {
                foreach (var food in FoodOrderModel.GetInstance().FoodOrders)
                {
                    if (selectedVoucher.IDFood == food.FoodID)
                    {
                        DiscountOrder = 1;
                        if(food.FoodOrderCount > 1)
                        {
                            TotalOrder = HomePayment - food.FoodOrderPrice;
                            GlobalDef.IsChooseVoucerToOrder = false;

                            return;
                        }
                    }
                }
            }
            voucherToOrder = selectedVoucher;
            DiscountOrder = selectedVoucher.value;
            GetFoodOrderTotal();
            GlobalDef.IsChooseVoucerToOrder = false;
        }

        public void HandleCallBacChooseTable(string TableChoose)
        {
            tableNum = TableChoose;
            NotifyOfPropertyChange(() => TableNum);
            if (tableNum != "0")
            {
                EnableOrder = true;
            }
            else
            {
                EnableOrder = false;
            }
            NotifyOfPropertyChange(() => EnableOrder);
        }

        public void HandleCallBacChooseMoreTable(List<int> TableChoose)
        {
            TableNum = string.Join(", ", TableChoose);
            NotifyOfPropertyChange(() => TableNum);
            if (TableChoose.Count > 0)
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
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowDialogAsync(registerViewModel);

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
                BgLocally = new SolidColorBrush(Colors.DarkSlateGray);
                BgDelivery = new SolidColorBrush(Colors.White);
                isBgLocally = true;
                VisibleLocally = Visibility.Hidden;
                VisibleDelivery = Visibility.Visible;
                VisibleTable = Visibility.Visible;
            }

        }

        public void DeliveryClick()
        {
            if (isBgLocally == true)
            {
                BgLocally = new SolidColorBrush(Colors.White);
                BgDelivery = new SolidColorBrush(Colors.DarkSlateGray);
                isBgLocally = false;
                VisibleLocally = Visibility.Visible;
                VisibleDelivery = Visibility.Hidden;
                VisibleTable = Visibility.Hidden;
            }

        }
    }
}
