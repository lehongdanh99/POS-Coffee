using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace POS_Coffe
{
    public class RestAPIHandler<T> where T : class
    {
        internal static HttpClient client = new HttpClient();
        internal static List<T> model = new List<T>();
        public static List<T> parseJsonToModel(string path)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalDef.BASE_URI);
                    var result = client.GetAsync(client.BaseAddress + path).Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var json = result.Content.ReadAsStringAsync().Result;
                        model = JsonConvert.DeserializeObject<List<T>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return model;
        }
        public static string Login(string usr, string pwd)
        {
            string token = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalDef.BASE_URI);
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