using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public abstract class BaseModel
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; } 

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}