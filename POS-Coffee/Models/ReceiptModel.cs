using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class ReceiptModel
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
}