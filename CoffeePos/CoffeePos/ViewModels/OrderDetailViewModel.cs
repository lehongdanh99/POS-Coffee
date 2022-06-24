using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Caliburn.Micro;
using CoffeePos.Common;
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

            isCakeChoose = GlobalDef.IsCakeChoose;
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

        private bool radSugar50;

        public bool RadSugar50
        {
            get { return radSugar50; }
            set { radSugar50 = value; }
        }

        private bool radSugar70;

        public bool RadSugar70
        {
            get { return radSugar70; }
            set { radSugar70 = value; }
        }

        private bool radIce50;

        public bool RadIce50
        {
            get { return radIce50; }
            set { radIce50 = value; }
        }

        private bool radIce70;

        public bool RadIce70
        {
            get { return radIce70; }
            set { radIce70 = value; }
        }


        private void GetFoodOrderDetail(Foods foodSelected = default, FoodOrder foodOrderSelected = default)
        {

            


            if (foodOrderSelected == default)
            {
                if (!string.IsNullOrEmpty(foodSelected.note))
                {
                    if(!foodSelected.note.Equals("string"))
                    {
                        string[] notes = foodSelected.note.Split(' ');
                        if (notes[1].Equals("50"))
                        {
                            RadSugar50 = true;
                        }
                        else if (notes[1].Equals(70))
                        {
                            RadSugar70 = true;
                        }

                        if (notes[3].Equals("50"))
                        {
                            RadIce50 = true;
                        }
                        else if (notes[3].Equals(70))
                        {
                            RadIce70 = true;
                        }
                    }
                    
                }
                FoodName = foodSelected.name.ToString();
                FoodImage = foodSelected.picture;
                FoodVariations = foodSelected.drinkCakeVariations;
                this.orderCount = 1;
                FoodID = foodSelected.id;
                FoodType = foodSelected.type;
                FoodPrice = foodSelected.FoodPrice;
                
                BgSmallSize = new SolidColorBrush(Colors.Orange);
                bgMediumSize = new SolidColorBrush(Colors.LightGray);
                isSizeSmall = true;

                
            }
            else
            {
                FoodName = foodOrderSelected.FoodOrderName.ToString();
                FoodVariations = foodOrderSelected.foodOrderVariations;
                FoodImage = foodOrderSelected.FoodOrderImage;
                this.orderCount = foodOrderSelected.FoodOrderCount;
                FoodID = foodOrderSelected.FoodID;
                FoodType = foodOrderSelected.FoodType;
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

        private Visibility isCakeChoose;
        public Visibility IsCakeChoose
        {
            get
            {
                return isCakeChoose;
            }
            set
            {
                isCakeChoose = value;
                NotifyOfPropertyChange(() => IsCakeChoose);
            }
        }

        private Foods FoodSelected;

        private int FoodID;

        private string FoodType;

        private FoodOrder FoodSelectedOrder;
        public String FoodName { get; set; }

        public List<FoodVariations> FoodVariations { get; set; }

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
                    FoodPrice = FoodSelectedOrder.FoodOrderPrice * OrderCount;
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
                    FoodPrice = (FoodSelected.drinkCakeVariations[1].price) * OrderCount;
                }
                else
                {
                    FoodPrice = FoodSelectedOrder.foodOrderVariations[1].price * OrderCount;
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

            this.TryCloseAsync();
        }

        public void btnOrder_Click()
        {
            FoodSelectedOrder.FoodOrderPrice = FoodPrice;
            if (isSizeSmall)
            {
                FoodSelectedOrder.FoodSize = "M";
            }
            else
            {
                FoodSelectedOrder.FoodSize = "L";
            }
            FoodSelectedOrder.FoodOrderCount = OrderCount;
            FoodSelectedOrder.FoodOrderMore = Note;
            FoodSelectedOrder.foodOrderVariations = FoodVariations;
            FoodSelectedOrder.FoodOrderImage = FoodImage;
            FoodSelectedOrder.FoodOrderName = FoodName;
            FoodSelectedOrder.FoodID = FoodID;
            FoodSelectedOrder.FoodType = FoodType;
            FoodSelectedOrder.FoodOrderMore = GlobalDef.SugarPercent + " " + GlobalDef.IcePercent + " " + Note;
            eventCustomChange?.Invoke(FoodSelectedOrder);

            eventChange?.Invoke(FoodSelectedOrder);



            this.TryCloseAsync();


        }
    }
}
