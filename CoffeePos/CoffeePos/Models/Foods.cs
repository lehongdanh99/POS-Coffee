using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
namespace CoffeePos
{
    public class Foods : PropertyChangedBase
    {
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }

        public string FoodImage { get; set; }

        public string FoodType { get; set; }

        public Foods(string foodName, double foodPrice, string foodImage, string foodType)
        {
            FoodName = foodName;
            FoodPrice = foodPrice;
            FoodImage = foodImage;
            FoodType = foodType;
        }

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



        public class FoodOrder : PropertyChangedBase
        {
            public string FoodOrderName { get; set; }

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

            public FoodOrder(string foodOrderName = default, string foodOrderMore = default, int foodOrderCount = default, double foodOrderPrice = default, string foodOrderImage = default, string foodSize = default)
            {
                FoodOrderMore = foodOrderMore;
                FoodOrderCount = foodOrderCount;
                FoodOrderName = foodOrderName;
                FoodOrderPrice = foodOrderPrice;
                FoodOrderImage = foodOrderImage;
                FoodSize = foodSize;
            }

        }

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
