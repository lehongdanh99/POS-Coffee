using CoffeePos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows;
using static CoffeePos.Common.Enums;
using static CoffeePos.Models.ReceiptModel;

namespace CoffeePos.Common
{
    public class RestAPIClient<T> where T : class
    {
        internal static HttpClient client = new HttpClient();
        internal static List<T> models = new List<T>();
        internal static T model;
        public T data;

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
                        models = JsonConvert.DeserializeObject<List<T>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return models;
        }

        public static T GetDataById(string path, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://34.126.139.165:8080/api/");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    var result = client.GetAsync(client.BaseAddress + path).Result;
                    if(result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var json = result.Content.ReadAsStringAsync().Result;
                        model = JsonConvert.DeserializeObject<T>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return model;
        }

        public static bool PostData(T data, string path, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://34.126.139.165:8080/api/");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    var json = JsonConvert.SerializeObject(data);
                    var payload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var response = client.PostAsync(client.BaseAddress + path, payload).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var resul = response.Content.ReadAsStringAsync().Result;
                        if (path == GlobalDef.ZALOPAY_API)
                        {
                            
                            GlobalDef.zaloPayResult = JsonConvert.DeserializeObject<ZaloPayResult>(resul);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
    }
    
}
