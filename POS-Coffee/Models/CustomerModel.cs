using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class CustomerModel : BaseModel
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public int point { get; set; }
    }
    public class CustomerAPIHandlerData
    {

        private static CustomerAPIHandlerData _instance;
        public static CustomerAPIHandlerData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new CustomerAPIHandlerData();
                }
            }
            return _instance;
        }
        private List<CustomerModel> listCustomer = RestAPIHandler<CustomerModel>.parseJsonToModel(GlobalDef.CUSTOMER_JSON_CONFIG_PATH);
        //private List<CustomerModel> listCustomer = RestAPIHandler<CustomerModel>.GetDatabyId(GlobalDef.CUSTOMER_JSON_CONFIG_PATH+ @"/" + id);
        public List<CustomerModel> ListCustomer
        {
            get { return listCustomer; }
            set
            {
                listCustomer = value;
            }
        }
    }
}