using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class CustomerModel : BaseModel
    {
        public int ID { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public int Point { get; set; }
    }
    public class CustomerAPIHandlerFakeData
    {

        private static CustomerAPIHandlerFakeData _instance;
        public static CustomerAPIHandlerFakeData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new CustomerAPIHandlerFakeData();
                }
            }
            return _instance;
        }
        private List<CustomerModel> listCustomer = RestAPIHandler<CustomerModel>.parseJsonToModel(GlobalDef.CUSTOMER_JSON_CONFIG_PATH);
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