using CoffeePos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CoffeePos.Models
{
    public class TableModel
    {
        private static TableModel _instance;
        public static TableModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new TableModel();
                }
            }
            return _instance;
        }
        public Dictionary<int, Table> TableNumber { get; set; }
        public class Table
        {
            public int TableID  { get; set; }
            public bool TableStatus { get; set; }
            public int TableFloor { get; set; }
            public int TableSeat { get; set; }

            private SolidColorBrush defaulColor = new SolidColorBrush(Colors.Green);

            private SolidColorBrush bgStatusTable;
            public SolidColorBrush BgStatusTable
            {
                get
                {
                    if (TableStatus == true)
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
                }
            }
            public Table(bool status, int floor, int seat, SolidColorBrush bgStatusTable = default)
            {
                TableStatus = status;
                TableFloor = floor;
                TableSeat = seat;
                BgStatusTable = bgStatusTable;
            }

        }
    }
}
