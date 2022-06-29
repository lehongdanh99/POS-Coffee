using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class RecipeModel : BaseModel
    {
        public int id { get; set; }
        public int drinkCakeVariationId { get; set; }
        public DrinkCakeVariation drinkCakeVariation { get; set; }
        public List<recipeDetails> recipeDetails { get; set; }
        public List<recipeDetailRequest> recipeDetailRequest { get; set; }
    }
    public class recipeDetails
    {
        public int id { get; set; }
        public MaterialsModel material { get; set; }
    }
    public class recipeDetailRequest
    {
        public int amountForOne { get; set; }
        public int materialID { get; set; }
    }
    public class RecipeAPIHandlereData
    {

        private static RecipeAPIHandlereData _instance;
        public static RecipeAPIHandlereData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new RecipeAPIHandlereData();
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