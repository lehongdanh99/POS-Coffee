using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class TableModel : BaseModel
    {
        public int UniqueID { get; set; }
        public string Status { get; set; }
        public int Floor { get; set; }
    }
}