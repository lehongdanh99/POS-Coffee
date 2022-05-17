using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class RecipeModel
    {
        public int RecipeID { get; set; }
        public int drink_cake_id { get; set; }
        public int Amount_For_One { get; set; }
        public string Size { get; set; }
        public int material_id { get; set; }
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