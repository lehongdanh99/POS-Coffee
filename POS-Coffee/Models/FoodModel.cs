using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class FoodModel
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
        public string Name { get; set; }
        public int Price { get; set; }
        public byte[] Picture { get; set; }
        public string Type { get; set; }      
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
        private List<FoodModel> listFood = CommonMethod.GetInstance().ReadJsonFileConfigFood();
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
    