using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CoffeePos.Models
{
    internal class Table
    {
        private SolidColorBrush defaulColor = new SolidColorBrush(Colors.Green);
        public bool Status { get; set; }
        public int Floor { get; set; }

        public int Seat { get; set; }

        private SolidColorBrush bgStatusTable;
        public SolidColorBrush BgStatusTable {
            get {
                if (Status)
                {
                    bgStatusTable = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    bgStatusTable = new SolidColorBrush(Colors.Green);
                }
                return bgStatusTable;
            } 
            set
            {
                bgStatusTable = value;
            } }

        public Table(bool status, int floor, int seat, SolidColorBrush bgStatusTable = default )
        {
            Status = status;
            Floor = floor;
            Seat = seat;
            BgStatusTable = bgStatusTable;
        }
    }
}
