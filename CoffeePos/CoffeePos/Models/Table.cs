using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.Models
{
    internal class Table
    {
        public string Status { get; set; }
        public int Floor { get; set; }

        public Table(string status, int floor)
        {
            status = Status;
            floor = Floor;
        }
    }
}
