using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class ReceiptModel : BaseModel
    {
        public int id { get; set; }
        public EmployeeModel employee { get; set; }
        public CustomerModel customer { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public int Point { get; set; }
        public int TotalPrice { get; set; }
        public int OriginalPrice { get; set; }
        public string PaymentType { get; set; }
        public string ServiceType { get; set; }
        public int CustomerPay { get; set; }
        public string Voucher { get; set; }
        public int DiscountPrice { get; set; }
        public string Branch { get; set; }
        public List<ReceiptDetails> receiptDetails { get; set; }

    }
    public class ReceiptDetails
    {
        public int id { get; set; }
        public string receipt { get; set; }
        public DrinkCakeVariation drinkCakeVariation { get; set; }
        public int amount { get; set; }
        public int price { get; set; }
        public string note { get; set; }
        public string name { get; set; }
        public int drinkCakeId { get; set; }
    }

    public class DrinkCakeVariation
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { set; get; }
    }

    public class ReceiptAPIHandler
    {
        private static ReceiptAPIHandler _instance;
        public static ReceiptAPIHandler GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new ReceiptAPIHandler();
                }
            }
            return _instance;
        }
        private List<ReceiptModel> listReceipt = RestAPIHandler<ReceiptModel>.parseJsonToModel(GlobalDef.RECEIPT_JSON_CONFIG_PATH);
        public List<ReceiptModel> ListReipt
        {
            get { return listReceipt; }
            set
            {
                listReceipt = value;
            }
        }
    }
}