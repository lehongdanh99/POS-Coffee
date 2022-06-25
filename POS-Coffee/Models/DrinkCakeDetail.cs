using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class DrinkCakeDetail
    {
        public List<DrinkCakeVariations> drinkCakeVariations { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string name1 { get; set; }
        public string description { get; set; }
        public string price { get; set; }
    }
}