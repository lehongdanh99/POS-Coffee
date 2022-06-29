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
        public int idL { get; set; }
        public int idM { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string nameL { get; set; }
        public string descriptionL { get; set; }
        public string priceL { get; set; }
        public string nameM { get; set; }
        public string descriptionM { get; set; }
        public string priceM { get; set; }
    }
}