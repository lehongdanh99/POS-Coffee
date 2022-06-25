using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class EmployeeModel : BaseModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string permission { get; set; }
        public string birthday { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Token { get; set; }
    }

    public class EmployeeAPIHandlerData
    {

        private static EmployeeAPIHandlerData _instance;
        public static EmployeeAPIHandlerData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new EmployeeAPIHandlerData();
                }
            }
            return _instance;
        }
        private List<EmployeeModel> listEmployee = RestAPIHandler<EmployeeModel>.parseJsonToModel(GlobalDef.EMPLOYEE_JSON_CONFIG_PATH);
        public List<EmployeeModel> ListEmployee
        {
            get { return listEmployee; }
            set
            {
                listEmployee = value;
            }
        }
    }

    public class EmployeeData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string permission { get; set; }
        public string birthday { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}