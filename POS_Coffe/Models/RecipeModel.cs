using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class RecipeModel
    {
        public int MaterialID { get; set; }
        public int FoodID { get; set; }
        public int AmountForOne { get; set; }
        public string Size { get; set; }
    }
}