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
        public static List<T> GetDatabyId(string path, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalDef.BASE_URI);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
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

        public static List<T> GetDate(string path, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalDef.BASE_URI);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
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
                string ErrorMessages = ex.Message;
            }
            return model;
        }


        internal static T data;
        //get 1 model
        public static T GetData(string path, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalDef.BASE_URI);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    var result = client.GetAsync(client.BaseAddress + path).Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var json = result.Content.ReadAsStringAsync().Result;
                        data = JsonConvert.DeserializeObject<T>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                string ErrorMessages = ex.Message;
            }
            return data;
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
                Console.WriteLine(ex.Message);
            }
            return true;
        }
        public static bool PutData(T data, string path, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://34.126.139.165:8080/api/");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    var json = JsonConvert.SerializeObject(data);
                    var payload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var response = client.PutAsync(client.BaseAddress + path, payload).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var resul = response.Content.ReadAsStringAsync().Result;
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
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        //public static bool DeleteData(int data, string path, string token)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("http://34.126.139.165:8080/api/");
        //            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        //            var json = JsonConvert.SerializeObject(data);
        //            var payload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        //            //var response = client.DeleteAsync(client.BaseAddress + path, payload).Result;
        //            var response = client.DeleteAsync(client.BaseAddress + path, payload).Result;
        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                var resul = response.Content.ReadAsStringAsync().Result;
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return true;
        //}
    }
}