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
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Permission { get; set; }
        public string Birthday { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

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
    