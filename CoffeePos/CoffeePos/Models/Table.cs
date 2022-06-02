using Caliburn.Micro;
using CoffeePos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CoffeePos.Models
{
    //public class ListTable
    //{
    //    private static ListTable _instance;
    //    public static ListTable GetInstance()
    //    {
    //        if (_instance == null)
    //        {
    //            if (_instance == null)
    //            {
    //                _instance = new ListTable();
    //            }
    //        }
    //        return _instance;
    //    }
    //    private TableModel listTable = CommonMethod.GetInstance().readJsonFileConfig();
    //    public TableModel ListTables
    //    {
    //        get { return listTable; }
    //        set
    //        {
    //            listTable = value;
    //        }
    //    }
    //}
    //public class TableModel : PropertyChangedBase
    //{
    //    private static TableModel _instance;
    //    public static TableModel GetInstance()
    //    {
    //        if (_instance == null)
    //        {
    //            if (_instance == null)
    //            {
    //                _instance = new TableModel();
    //            }
    //        }
    //        return _instance;
    //    }
    //    public Dictionary<int, Table> TableNumber { get; set; }
        
    //}
    public class Table 
    {
        public int TableID { get; set; }
        public bool TableStatus { get; set; }
        public int TableFloor { get; set; }
        public int TableSeat { get; set; }

        private SolidColorBrush bgStatusTable;
        public SolidColorBrush BgStatusTable
        {
            get
            {
                if (TableStatus)
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
        private Visibility visibleChoose;
        public Visibility VisibleChoose
        {
            get
            {
                if (TableStatus)
                    visibleChoose = Visibility.Visible;
                else
                    visibleChoose = Visibility.Collapsed;
                return visibleChoose;
            }
            set
            {
                visibleChoose = value;
            }
        }

        private Visibility isCheckChoose = Visibility.Collapsed;
        public Visibility IsCheckChoose
        {
            get
            {
                return isCheckChoose;
            }
            set
            {
                isCheckChoose = value;
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
