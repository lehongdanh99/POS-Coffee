using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class DrinkCakeModel
    {
        public int FoodID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public byte[] Picture { get; set; }
        public string Type { get; set; }
    }
}