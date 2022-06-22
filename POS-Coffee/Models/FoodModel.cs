using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class FoodModel : BaseModel
    {
        private static FoodModel _instance;
        public static FoodModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new FoodModel();
                }
            }
            return _instance;
        }
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public int FoodPrice { get; set; }
        public string FoodImage { get; set; }
        public string FoodType { get; set; }      
    }
    public class FoodAPIHandlerFakeData
    {

        private static FoodAPIHandlerFakeData _instance;
        public static FoodAPIHandlerFakeData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new FoodAPIHandlerFakeData();
                }
            }
            return _instance;
        }
        private List<FoodModel> listFood = RestAPIHandler<FoodModel>.parseJsonToModel(GlobalDef.FOOD_JSON_CONFIG_PATH);
        public List<FoodModel> ListFood
        {
            get { return listFood; }
            set
            {
                listFood = value;
            }
        }
    }
}
    