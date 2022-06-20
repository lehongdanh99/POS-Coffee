using CoffeePos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows;
using static CoffeePos.Common.Enums;

namespace CoffeePos.Common
{
    public class RestAPIClient<T> where T : class
    {
        internal static HttpClient client = new HttpClient();
        internal static List<T> model = new List<T>();
        public static List<T> parseJsonToModel(string path)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://34.126.139.165:8080/api/");
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
                MessageBox.Show(ex.Message);
            }
            return model;
        }
    }
}
