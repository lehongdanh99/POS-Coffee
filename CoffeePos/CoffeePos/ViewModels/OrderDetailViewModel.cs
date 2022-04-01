using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using Caliburn.Micro;

namespace CoffeePos.ViewModels
{
    internal class OrderDetailViewModel : Screen
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public OrderDetailViewModel(Foods foodSelected)
        {
            FoodSelected = foodSelected;
            GetFoodOrderDetail(FoodSelected);

            

            BgSmallSize = new SolidColorBrush(Colors.Orange);
            bgMediumSize = new SolidColorBrush(Colors.LightGray);
            this.orderCount = 1;
        }

        private void GetFoodOrderDetail(Foods foodSelected)
        {
            FoodName = foodSelected.FoodName.ToString();
            FoodImage = foodSelected.FoodImage;
            FoodPrice = foodSelected.FoodPrice;
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
                this.orderCount--;
            }
            FoodPrice = FoodSelected.FoodPrice * orderCount;
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
                FoodPrice = FoodSelected.FoodPrice;
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
                FoodPrice = FoodSelected.FoodPrice + 10000;
                NotifyOfPropertyChange(() => FoodPrice);
            }
        }

        public void btnAdd_Click()
        {
            this.orderCount++;
            FoodPrice = FoodSelected.FoodPrice * orderCount;
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
            FoodSelected.FoodOrderPrice = FoodPrice;
            if(isSizeSmall)
            {
                FoodSelected.FoodSize = "S";
            }
            else
            {
                FoodSelected.FoodSize = "M";
            }
            FoodSelected.FoodOrderCount = OrderCount;
            FoodSelected.FoodOrderMore = Note;
            
            HomeViewModel homeViewModel = new HomeViewModel(FoodSelected);
            WindowManager windowManager = new WindowManager();
            windowManager.ShowDialogAsync(homeViewModel);
            Dispatcher.CurrentDispatcher.BeginInvoke(new System.Action(() =>
            {
                TryCloseAsync();
            }));
        }
    }
}
