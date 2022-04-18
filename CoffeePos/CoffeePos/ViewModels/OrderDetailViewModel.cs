using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using Caliburn.Micro;
using static CoffeePos.FoodOrderModel;

namespace CoffeePos.ViewModels
{
    internal class OrderDetailViewModel : Screen
    {
        public SelectedFoodThis eventChange;
        public delegate void SelectedFoodThis(FoodOrder selected);

        public SelectedFoodCustom eventCustomChange;
        public delegate void SelectedFoodCustom(FoodOrder selectedCustom);

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public OrderDetailViewModel(Foods foodSelected = default, FoodOrder foodOrderSelected = default)
        {
            
            
            GetFoodOrderDetail(foodSelected , foodOrderSelected);
            if(foodSelected == default)
            {
                FoodSelectedOrder = foodOrderSelected;
            }
            else
            {
                FoodSelected = foodSelected;
                FoodSelectedOrder = new FoodOrder();
            }
            

            
            
        }

        private void GetFoodOrderDetail(Foods foodSelected = default, FoodOrder foodOrderSelected = default)
        {
            
            
            if(foodOrderSelected == default)
            {
                FoodName = foodSelected.FoodName.ToString();
                FoodImage = foodSelected.FoodImage;
                this.orderCount = 1;
                FoodPrice = foodSelected.FoodPrice;
                BgSmallSize = new SolidColorBrush(Colors.Orange);
                bgMediumSize = new SolidColorBrush(Colors.LightGray);
                isSizeSmall = true;
            }
            else
            {
                FoodName = foodOrderSelected.FoodOrderName.ToString();
                FoodImage = foodOrderSelected.FoodOrderImage;
                this.orderCount = foodOrderSelected.FoodOrderCount;
                FoodPrice = foodOrderSelected.FoodOrderPrice;
                Note = foodOrderSelected.FoodOrderMore;

                if (foodOrderSelected.FoodSize == "S")
                {
                    BgSmallSize = new SolidColorBrush(Colors.Orange);
                    bgMediumSize = new SolidColorBrush(Colors.LightGray);
                    isSizeSmall = true;
                }
                else
                {
                    BgSmallSize = new SolidColorBrush(Colors.LightGray);
                    bgMediumSize = new SolidColorBrush(Colors.Orange);
                    isSizeSmall = false;
                }
            }
            
            
            
        }

        private string note;
        public string Note
        {
            get
            {
                return note;
            }
            set
            {
                note = value;
                NotifyOfPropertyChange(() => Note);
            }
        }

        private Foods FoodSelected;

        private FoodOrder FoodSelectedOrder;
        public String FoodName { get; set; }

        private double foodPrice;
        public double FoodPrice
        {
            get
            {
                return foodPrice;
            }
            set
            {
                foodPrice = value;
                NotifyOfPropertyChange(() => FoodPrice);
            }
        }

        public string FoodImage { get; set; }

        private bool isSizeSmall= true;

        private bool isOrderSelected = false;

        private SolidColorBrush bgSmallSize;
        public SolidColorBrush BgSmallSize
        {
            get
            {
                return bgSmallSize;
            }
            set
            {
                bgSmallSize = value;
                NotifyOfPropertyChange(() => BgSmallSize);
            }
        }

        private SolidColorBrush bgMediumSize;
        public SolidColorBrush BgMediumSize
        {
            get
            {
                return bgMediumSize;
            }
            set
            {
                bgMediumSize = value;
                NotifyOfPropertyChange(() => BgMediumSize);
            }
        }
        private int orderCount;

        public int OrderCount
        {
            get 
            { 
                return this.orderCount; 
            }
            set 
            { 
                this.orderCount = value;
                NotifyOfPropertyChange(() => this.orderCount);
            }
        }
        
        public void btnLess_Click()
        {

            if(this.orderCount > 1)
            {
                if (FoodSelected != default)
                {
                    FoodPrice = (FoodPrice / OrderCount) * (orderCount - 1);
                }
                else
                {
                    FoodPrice = FoodPrice / OrderCount * (orderCount - 1);
                }
                this.orderCount--;
            }
            NotifyOfPropertyChange(() => this.orderCount);
            NotifyOfPropertyChange(() => FoodPrice);

        }

        public void btnSmall_Click()
        {
            if (!isSizeSmall)
            {
                BgSmallSize = new SolidColorBrush(Colors.Orange);
                BgMediumSize = new SolidColorBrush(Colors.LightGray);
                isSizeSmall = true;
                if (FoodSelected != default)
                {
                    FoodPrice = FoodSelected.FoodPrice * OrderCount;
                }
                else
                {
                    FoodPrice = FoodPrice / (1 + 0.1);
                }

                NotifyOfPropertyChange(() => FoodPrice);
            }
        }

        public void btnMedium_Click()
        {
            if (isSizeSmall)
            {
                BgSmallSize = new SolidColorBrush(Colors.LightGray);
                BgMediumSize = new SolidColorBrush(Colors.Orange);
                isSizeSmall = false;
                if(FoodSelected != default)
                {
                    FoodPrice = (FoodSelected.FoodPrice + FoodSelected.FoodPrice * 0.1) * OrderCount;
                }
                else
                {
                    FoodPrice = FoodPrice * 0.1 + FoodPrice;
                }
                
                NotifyOfPropertyChange(() => FoodPrice);
            }
        }

        public void btnAdd_Click()
        {
            
            if(isSizeSmall)
            {
                if (FoodSelected != default)
                {
                    FoodPrice = (FoodPrice / OrderCount) * (orderCount + 1);
                }
                else
                {
                    FoodPrice = FoodPrice / OrderCount * (orderCount + 1);
                }
            }
            else
            {
                if (FoodSelected != default)
                {
                    FoodPrice = (FoodPrice / OrderCount) * (orderCount + 1);
                }
                else
                {
                    FoodPrice = FoodPrice / OrderCount * (orderCount + 1);
                }
            }
            this.orderCount++;
            NotifyOfPropertyChange(() => this.orderCount);
            NotifyOfPropertyChange(() => FoodPrice);
        }

        public void btBack_Click()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            WindowManager windowManager = new WindowManager();
            windowManager.ShowDialogAsync(homeViewModel);
            Dispatcher.CurrentDispatcher.BeginInvoke(new System.Action(() =>
            {
                TryCloseAsync();
            }));
        }

        public void btnOrder_Click()
        {

            
                FoodSelectedOrder.FoodOrderPrice = FoodPrice;
                if (isSizeSmall)
                {
                    FoodSelectedOrder.FoodSize = "S";
                }
                else
                {
                    FoodSelectedOrder.FoodSize = "M";
                }
                FoodSelectedOrder.FoodOrderCount = OrderCount;
                FoodSelectedOrder.FoodOrderMore = Note;
            FoodSelectedOrder.FoodOrderImage = FoodImage;
            FoodSelectedOrder.FoodOrderName = FoodName;
            eventCustomChange?.Invoke(FoodSelectedOrder);

            eventChange?.Invoke(FoodSelectedOrder);



            this.TryCloseAsync();
            //WindowManager windowManager = new WindowManager();
            //windowManager.ShowDialogAsync(HomeViewModel.GetInstance());


        }
    }
}
