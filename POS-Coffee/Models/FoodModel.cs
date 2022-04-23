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

        private List<FoodModel> lstEmpl;

        public List<FoodModel> LstEmpl
        {
            get
            {
                if (lstEmpl == null)
                    lstEmpl = new List<FoodModel>();
                return lstEmpl;
            }
            set
            {
                lstEmpl = value;
            }
        }
    }
}
    