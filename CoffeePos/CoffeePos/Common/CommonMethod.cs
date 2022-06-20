using CoffeePos.Models;
using DocumentFormat.OpenXml.Office.CustomUI;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CoffeePos.Common
{
    public class CommonMethod
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CommonMethod _instance;     
        private List<Foods> foodModel;
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

        public static void getFoodData()
        {
            var client = new RestClient("http://34.126.139.165:8080/api/");
            
            var request = new RestRequest("drink-cake");
            var response = client.Get(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string raw = response.Content;
                List<Foods> result = JsonConvert.DeserializeObject<List<Foods>>(raw);
            }

        }    
        public List<Foods> readFoodJsonFileConfig()
        {
            var client = new RestClient("http://34.126.139.165:8080/api/");
            var request = new RestRequest("drink-cake");
            var response = client.Get(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string raw = response.Content;
                List<Foods> result = JsonConvert.DeserializeObject<List<Foods>>(raw);
  
                foodModel = result;
            }
            //string json = String.Empty;
            //using (StreamReader r = new StreamReader(GlobalDef.JSON_TEST))
            //{
            //    json = r.ReadToEnd();
            //    foodModel = JsonConvert.DeserializeObject<List<Foods>>(json);
            //}
            //log.Info($"Read file Table config to Table model {json.ToString()} ");
            return foodModel;
        }
        private List<Table> model;
        public List<Table> readTableJsonFileConfig()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                model = JsonConvert.DeserializeObject<List<Table>>(json);
            }
            log.Info($"Read file Table config to Table model {json.ToString()} ");
            return model;
        }
        private List<Voucher> vouchermodel = new List<Voucher>();
        public List<Voucher> readVoucherJsonFileConfig()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.VOUCHER_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                vouchermodel = JsonConvert.DeserializeObject<List<Voucher>>(json);
            }
            log.Info($"Read file Table config to Table model {json.ToString()} ");
            return vouchermodel;
        }
        private List<Customer> customermodel = new List<Customer>();
        public List<Customer> readCustomerJsonFileConfig()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.CUSTOMER_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                customermodel = JsonConvert.DeserializeObject<List<Customer>>(json);
            }
            log.Info($"Read file Table config to Table model {json.ToString()} ");
            return customermodel;
        }
        private List<Employee> employeemodel = new List<Employee>();
        public List<Employee> readEmployeeJsonFileConfig()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.EMPLOYEE_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                employeemodel = JsonConvert.DeserializeObject<List<Employee>>(json);
            }
            log.Info($"Read file Table config to Table model {json.ToString()} ");
            return employeemodel;
        }

        public ImageSource convertByte(byte[] byteImage)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(byteImage);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();
            return biImg as ImageSource;
        }
    }
}


