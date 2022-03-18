using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.Models
{
    internal class Oder
    {
        public string Food { get; set; }
        public int Table { get; set; }

        public string Size { get; set; }

        public double Price { get; set; }

        public string Note { get; set; }

        public string Voucher { get; set; }

        public string Discount { get; set; }

        public Oder(string food, int table, string size, double price, string note, string voucher, string discount)
        {
            food = Food;
            table = Table;
            size = Size;
            price = Price;
            note = Note;
            voucher = Voucher;
            discount = Discount;
        }
    }
}
