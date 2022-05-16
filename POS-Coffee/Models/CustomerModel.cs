using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class CustomerModel
    {
        public int CusID { get; set; }
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
        private List<CustomerModel> listCustomer = CommonMethod.GetInstance().ReadJsonFileConfigCustomer();
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