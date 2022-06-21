using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class ReceipDetail
    {
        public int RecipeID { get; set; }
        public int Drink_Cake_ID { get; set; }
        public int Amount_For_One { get; set; }
        public string Size { get; set; }
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
        public string FoodName { get; set; }
    }
}