using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.Models
{
    internal class Customer
    {
        public string Name { get; set; }
        public double Point { get; set; }

        public Customer(string name, double point)
        {
            name = Name;
            point = Point;
        }
    }
}
