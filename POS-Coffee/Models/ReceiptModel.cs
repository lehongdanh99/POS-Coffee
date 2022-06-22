using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class ReceiptModel : BaseModel
    {
        public int ReceiptID { get; set; }
        public int EmpID { get; set; }
        public int CusID { get; set; }
        public int TotalPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int CustomerPay { get; set; }
        public int TypePayment { get; set; }
        public int TypeService { get; set; }
        public int Table { get; set; }
        public string VoucherName { get; set; }
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