using Newtonsoft.Json;
using POS_Coffe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;

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
        //Get list voucher
        //private List<VoucherModel> modelVoucher = new List<VoucherModel>();
        //public List<VoucherModel> ReadJsonFileConfigVoucher()
        //{
        //    string json = String.Empty;
        //    using (StreamReader r = new StreamReader(GlobalDef.VOUCHER_JSON_CONFIG_PATH))
        //    {
        //        json = r.ReadToEnd();
        //        modelVoucher = JsonConvert.DeserializeObject<List<VoucherModel>>(json);
        //    }
        //    return modelVoucher;
        //}

        private List<VoucherModel> modelVoucher = new List<VoucherModel>();
        public List<VoucherModel> ReadJsonFileConfigVoucher()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.VOUCHER_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                modelVoucher = JsonConvert.DeserializeObject<List<VoucherModel>>(json);
            }
            return modelVoucher;
        }

        //Get list Food
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
        //Get list Recipe
        private List<RecipeModel> modelRecipe = new List<RecipeModel>();
        public List<RecipeModel> ReadJsonFileConfigRecipe()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.RECIPE_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                modelRecipe = JsonConvert.DeserializeObject<List<RecipeModel>>(json);
            }
            return modelRecipe;
        }

        //Get list Customer
        private List<CustomerModel> modelCustomer = new List<CustomerModel>();
        public List<CustomerModel> ReadJsonFileConfigCustomer()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.CUSTOMER_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                modelCustomer = JsonConvert.DeserializeObject<List<CustomerModel>>(json);
            }
            return modelCustomer;
        }

        //Get list Material
        private List<MaterialsModel> modelMaterial = new List<MaterialsModel>();
        public List<MaterialsModel> ReadJsonFileConfigMaterial()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.MATERIAL_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                modelMaterial = JsonConvert.DeserializeObject<List<MaterialsModel>>(json);
            }
            return modelMaterial;
        }
        //Get list Statistic
        private List<StatisticModel> modelStatistic = new List<StatisticModel>();
        public List<StatisticModel> ReadJsonFileConfigStatistic()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.STATISTIC_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                modelStatistic = JsonConvert.DeserializeObject<List<StatisticModel>>(json);
            }
            return modelStatistic;
        }

        //Get list HistoryTracking
        private List<HistoryTrackingModel> modelHistoryTracking = new List<HistoryTrackingModel>();
        public List<HistoryTrackingModel> ReadJsonFileConfigHistoryTracking()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.HISTORYTRACKING_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                modelHistoryTracking = JsonConvert.DeserializeObject<List<HistoryTrackingModel>>(json);
            }
            return modelHistoryTracking;
        }

        public static string Login(string usr, string pwd)
        {
            string token = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalDef.BASE_URI);
                    //TODO:
                    //Employee employee = new Employee()
                    //{
                    //    username = usr,
                    //    password = pwd
                    //};
                    //var json = JsonConvert.SerializeObject(employee);
                    //var payload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    //var response = client.PostAsync(client.BaseAddress + "employee/login", payload).Result;
                    //if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    //{
                    //    token = response.Content.ReadAsStringAsync().Result;
                    //    Employee emp = JsonConvert.DeserializeObject<Employee>(token);
                    //    token = emp.token;
                    //}
                }
            }
            catch (Exception ex)
            {
            }
            return token;
        }

    }
}