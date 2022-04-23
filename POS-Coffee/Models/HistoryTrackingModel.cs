using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class HistoryTrackingModel
    {
        public int HistoryID { get; set; }
        public int EmpID { get; set; }
        public string TableEffect { get; set; }
        public string OccurTime { get; set; }
    }
}