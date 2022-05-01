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
    public class RecipeAPIHandlerFakeData
    {

        private static RecipeAPIHandlerFakeData _instance;
        public static RecipeAPIHandlerFakeData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new RecipeAPIHandlerFakeData();
                }
            }
            return _instance;
        }
        private List<RecipeModel> listRecipe = CommonMethod.GetInstance().ReadJsonFileConfigRecipe();
        public List<RecipeModel> ListRecipe
        {
            get { return listRecipe; }
            set
            {
                listRecipe = value;
            }
        }
    }
}