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
        private List<EmployeeModel> model = new List<EmployeeModel>();
        public List<EmployeeModel> readJsonFileConfig()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.EMPLOYEE_JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                model = JsonConvert.DeserializeObject<List<EmployeeModel>>(json);
            }
            return model;
        }
    }
}