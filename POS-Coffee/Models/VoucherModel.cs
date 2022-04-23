using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class VoucherModel
    {
        public int VoucherID { get; set; }
        public string Name { get; set; }
        public int IDFood { get; set; }
        public int Value { get; set; }
    }
}