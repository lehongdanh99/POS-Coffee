using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class DrinkCakeModel :BaseModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
        public string type { get; set; }
        public List<DrinkCakeVariations> DrinkCakeVariations { get; set; }
    }

    public class DrinkCakeVariations
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
    }

    public class DrinkCakeAPIHandlerData
    {

        private static DrinkCakeAPIHandlerData _instance;
        public static DrinkCakeAPIHandlerData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new DrinkCakeAPIHandlerData();
                }
            }
            return _instance;
        }
        private List<DrinkCakeModel> listDrinkCake = RestAPIHandler<DrinkCakeModel>.parseJsonToModel(GlobalDef.DRINKCAKE_JSON_CONFIG_PATH);
        public List<DrinkCakeModel> ListDrinkCake
        {
            get { return listDrinkCake; }
            set
            {
                listDrinkCake = value;
            }
        }
    }
}