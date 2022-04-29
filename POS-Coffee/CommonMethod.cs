using Newtonsoft.Json;
using POS_Coffe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
namespace POS_Coffe
{
    public class CommonMethod
    {
        private static CommonMethod _instance;
        public static CommonMethod GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new CommonMethod();
                }
            }
            return _instance;
        }
        private List<EmployeeModel> modelEmployee = new List<EmployeeModel>();
        public List<EmployeeModel> ReadJsonFileConfigEmployee()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.EMPLOYEE_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                modelEmployee = JsonConvert.DeserializeObject<List<EmployeeModel>>(json);
            }
            return modelEmployee;
        }

        private List<VoucherModel> modelVoucher = new List<VoucherModel>();
        public List<VoucherModel> ReadJsonFileConfigVoucher()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.EMPLOYEE_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                modelVoucher = JsonConvert.DeserializeObject<List<VoucherModel>>(json);
            }
            return modelVoucher;
        }

        private List<FoodModel> modelFood = new List<FoodModel>();
        public List<FoodModel> ReadJsonFileConfigFood()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.FOOD_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                modelFood = JsonConvert.DeserializeObject<List<FoodModel>>(json);
            }
            return modelFood;
        }
    }
}