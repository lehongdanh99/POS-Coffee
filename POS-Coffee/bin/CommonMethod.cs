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

        //Get list Receipt
        private List<ReceiptModel> modelReceipt = new List<ReceiptModel>();
        public List<ReceiptModel> ReadJsonFileConfigReceipt()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.RECEIPT_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                modelReceipt = JsonConvert.DeserializeObject<List<ReceiptModel>>(json);
            }
            return modelReceipt;
        }

        //Get list DrinkCake
        private List<DrinkCakeModel> modelDrinkCake = new List<DrinkCakeModel>();
        public List<DrinkCakeModel> ReadJsonFileConfigDrinkCake()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.RECEIPT_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                modelDrinkCake = JsonConvert.DeserializeObject<List<DrinkCakeModel>>(json);
            }
            return modelDrinkCake;
        }

        public static string Login(string usr, string pwd)
        {
            string token = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://34.126.139.165:8080/api/");
                    EmployeeModel employee = new EmployeeModel()
                    {
                        username = usr,
                        password = pwd
                    };
                    var json = JsonConvert.SerializeObject(employee);
                    var payload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var response = client.PostAsync(client.BaseAddress + "employee/login", payload).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        token = response.Content.ReadAsStringAsync().Result;
                        EmployeeModel emp = JsonConvert.DeserializeObject<EmployeeModel>(token);
                        GlobalDef.IDEMP = emp.id;
                        GlobalDef.NAME = emp.name;
                        token = emp.Token;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return token;
        }

    }
}



