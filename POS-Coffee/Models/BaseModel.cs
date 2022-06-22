using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public abstract class BaseModel
    {
        public createBy CreateBy { get; set; }
        public updateBy UpdateBy { get; set; }

        public class createBy
        {
            public string createdBy { get; set; }
            public string updatedBy { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public DateTime createdAtFormatVN { get; set; }
            public DateTime updatedAtFormatVN { get; set; }
        }
        public class updateBy
        {
            public string createdBy { get; set; }
            public string updatedBy { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public DateTime createdAtFormatVN { get; set; }
            public DateTime updatedAtFormatVN { get; set; }
        }
    }

}