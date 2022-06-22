using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class DetailReceiptModel : BaseModel
    {
        public int DetailReceiptID { get; set; }
        public int ReceiptID { get; set; }
        public string FoodName {get ;set;}
        public int Amount { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public string NOTE { get; set; }
    }
}