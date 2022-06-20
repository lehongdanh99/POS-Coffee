using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string Name { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public Employee()
        {

        }
    }
}
