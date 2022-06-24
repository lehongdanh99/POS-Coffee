using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;
using CoffeePos.Common;

namespace CoffeePos
{
    public class Foods
    {
        public int id { get; set; }
        public string name { get; set; }
        public double FoodPrice { get; set; }

        public List<FoodVariations> drinkCakeVariations { get; set; }

        public FoodVariations drinkCakeVariation { get; set; }

        public string picture { get; set; }

        public string type { get; set; }

        public string drinkCakeId { get; set; }

        public string note { get; set; }

        public Foods(string foodName, double foodPrice, string foodImage, string foodType)
        {
            name = foodName;
            FoodPrice = foodPrice;
            picture = foodImage;
            type = foodType;
        }

    }

    public class FoodVariations
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }

    public class FoodOrderModel : PropertyChangedBase
    {
        private static FoodOrderModel _instance;
        public static FoodOrderModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new FoodOrderModel();
                }
            }
            return _instance;
        }

        private ObservableCollection<FoodOrder> foodOrders = new ObservableCollection<FoodOrder>();

        public ObservableCollection<FoodOrder> FoodOrders
        {
            get { return foodOrders; }
            set { foodOrders = value; NotifyOfPropertyChange(() => FoodOrders); }
        }



        

    }

    public class FoodOrder : PropertyChangedBase
    {

        public int FoodOrderID { get; set; }

        private bool servedFood = false;
        public bool ServedFood 
        {
            get { return servedFood; }
            set
            {
                servedFood = value;
                NotifyOfPropertyChange(() => ServedFood);
            }
        }

        private bool isEnable = false;
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                NotifyOfPropertyChange(() => IsEnable);
            }
        }
        public string FoodOrderName { get; set; }

        private Visibility visibleCheckBox;

        public Visibility VisibleCheckBox
        {
            get { return visibleCheckBox; }
            set
            {
                visibleCheckBox = value;
                if(GlobalDef.DetailTable == Visibility.Visible)
                {
                    visibleCheckBox = Visibility.Visible;
                }
                else
                {
                    visibleCheckBox = Visibility.Collapsed;
                }
                
            }
        }

        public List<FoodVariations> foodOrderVariations { get; set; }

        public string FoodType { get; set; }

        public int FoodID { get; set; }

        public string FoodOrderImage { get; set; }

        private string foodSize = "S";
        public string FoodSize
        {
            get { return foodSize; }
            set
            {
                foodSize = value;
                NotifyOfPropertyChange(() => FoodSize);
            }
        }


        private string foodOrderMore;
        public string FoodOrderMore
        {
            get { return foodOrderMore; }
            set
            {
                foodOrderMore = value;
                NotifyOfPropertyChange(() => FoodOrderMore);
            }
        }

        private int foodOrderCount = 1;
        public int FoodOrderCount
        {
            get { return foodOrderCount; }
            set
            {
                foodOrderCount = value;
                NotifyOfPropertyChange(() => FoodOrderCount);
            }
        }

        private double foodOrderPrice;
        public double FoodOrderPrice
        {
            get { return foodOrderPrice; }
            set
            {
                foodOrderPrice = value;
                NotifyOfPropertyChange(() => FoodOrderPrice);
            }
        }

        public FoodOrder(bool isDoneFood = default, bool isEnable = default, string foodOrderName = default, string foodOrderMore = default, int foodOrderCount = default, double foodOrderPrice = default, string foodOrderImage = default, string foodSize = default)
        {
            IsEnable = isEnable;
            ServedFood = isDoneFood;
            FoodOrderMore = foodOrderMore;
            FoodOrderCount = foodOrderCount;
            FoodOrderName = foodOrderName;
            FoodOrderPrice = foodOrderPrice;
            FoodOrderImage = foodOrderImage;
            FoodSize = foodSize;
        }

    }

    public class FoodHooby
    {
        public int id { get; set; }
        public string name { get; set; }
        public double FoodPrice { get; set; }

        public FoodVariations drinkCakeVariations { get; set; }

        public string picture { get; set; }

        public string type { get; set; }

      

    }    

    public class TypeFoods
    {
        public string TypeName { get; set; }

        public TypeFoods(string typeName)
        {
            TypeName = typeName;
        }
    }
}
