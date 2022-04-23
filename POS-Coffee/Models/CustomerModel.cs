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
}