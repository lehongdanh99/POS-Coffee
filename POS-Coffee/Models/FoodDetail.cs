﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class FoodDetail :BaseModel
    {
        public string Foodname { get; set; }
        public int Foodid { get; set; }
        public int RecipeID { get; set; }
        public string MaterialName { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public string Quantity { get; set; }

    }

    public class AllFood
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public int FoodPrice { get; set; }
        public string FoodImage { get; set; }
        public string FoodType { get; set; }
        public List<FoodDetail> LstFoods { get; set; }
    }
}