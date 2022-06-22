using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class RecipeModel : BaseModel
    {
        public int RecipeID { get; set; }
        public int Drink_Cake_ID { get; set; }
        public int Amount_For_One { get; set; }
        public string Size { get; set; }
        public int MaterialID { get; set; }
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
        private List<RecipeModel> listRecipe = RestAPIHandler<RecipeModel>.parseJsonToModel(GlobalDef.RECIPE_JSON_CONFIG_PATH);
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