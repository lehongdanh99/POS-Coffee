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
}
