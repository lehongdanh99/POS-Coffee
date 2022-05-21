using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.Models
{
    public class Voucher
    {

        public string Name { get; set; }
        public string NameFood { get; set; }

        public int Percent { get; set; }

        private bool isCanChoose;
        public bool IsCanChoose 
        {
            get { return isCanChoose; }
            set { isCanChoose = value; 
            }
        }
        
        public Voucher(string name , int percent = 0, string nameFood = default)
        {
            Name = name;
            NameFood = nameFood;
            Percent = percent;
        }
    }
}
