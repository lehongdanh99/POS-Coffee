using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.Models
{
    public class Voucher
    {
        public int id { get; set; }
        public string name { get; set; }
        public int IDFood { get; set; }

        public DateTime endDate { get; set; }

        public int value { get; set; }
        public bool isValid { get; set; }
        private bool isCanChoose;
        public bool IsCanChoose
        {
            get { return isCanChoose; }
            set { isCanChoose = value;  
            }
        }
        public Voucher()
        {

        }
    }
}
