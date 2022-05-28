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
        public int VoucherID { get; set; }
        public string Name { get; set; }
        public int IDFood { get; set; }

        public int Percent { get; set; }
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
