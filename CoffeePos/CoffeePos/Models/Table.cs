using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.Models
{
    internal class Table
    {
        public bool Status { get; set; }
        public int Floor { get; set; }

        public int Seat { get; set; }

        public Table(bool status, int floor, int seat)
        {
            Status = status;
            Floor = floor;
            Seat = seat;
        }
    }
}
