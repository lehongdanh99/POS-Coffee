using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos
{
    public class Foods
    {
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }

        public string FoodImage { get; set; }

        public Foods(string foodName, double foodPrice, string foodImage)
        {
            FoodName = foodName;
            FoodPrice = foodPrice;
            FoodImage = foodImage;
        }

    }

    public class FoodOrder
    {
        public string FoodOrderName { get; set; }

        public string FoodOrderMore { get; set; }

        public int FoodOrderCount { get; set; }
        public double FoodOrderPrice { get; set; }

        public string FoodOrderImage { get; set; }

        public FoodOrder(string foodOrderName, string foodOrderMore, int foodOrderCount, double foodOrderPrice, string foodOrderImage)
        {
            FoodOrderMore = foodOrderMore;
            FoodOrderCount = foodOrderCount;
            FoodOrderName = foodOrderName;
            FoodOrderPrice = foodOrderPrice;
            FoodOrderImage = foodOrderImage;
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
