using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class DrinkCakeDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Type { get; set; }
        public List<DrinkCakeVariations> DrinkCakeVariations { get; set; }
    }
}