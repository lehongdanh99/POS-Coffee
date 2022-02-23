using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos
{
    internal class Food
    {
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        
        public string FoodImage { get; set; }

        public Food(string foodName, double foodPrice, string foodImage)
        {
            FoodName = foodName;
            FoodPrice = foodPrice;
            FoodImage = foodImage;
        }

    }

    internal class FoodOrder
    {
        public string FoodOrderName { get; set; }

        public string FoodOrderMore { get; set; }

        public int FoodOrderCount { get; set; }
        public double FoodOrderPrice { get; set; }

        public string FoodOrderImage { get; set; }

        public FoodOrder(string foodOrderName,string foodOrderMore, int foodOrderCount, double foodOrderPrice, string foodOrderImage)
        {
            FoodOrderMore = foodOrderMore;
            FoodOrderCount = foodOrderCount;
            FoodOrderName = foodOrderName;
            FoodOrderPrice = foodOrderPrice;
            FoodOrderImage = foodOrderImage;
        }

    }

    internal class TypeFood
    {
        public string TypeName { get; set; }

        public  TypeFood(string typeName)
        {
            TypeName = typeName;
        }
    }
}
