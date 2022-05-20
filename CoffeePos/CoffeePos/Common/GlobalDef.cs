using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static CoffeePos.Models.ReceiptModel;

namespace CoffeePos.Common
{
    class GlobalDef
    {
        public static string USERNAME = "";
        public static int ID_USERNAME = 0;
        public static string JSON_CONFIG_PATH = "TableConfig.json";
        public static string END_POINT = "";

        public static bool IsChooseTableToOrder = false;
        public static bool IsChooseVoucerToOrder = false;
        public static bool IsChooseVoucerToPayment = false;
        public static bool IsChooseVoucerToDetail = false;
        public static Receipt ReceiptDetail = new Receipt();
        public static Receipt ReceiptPayment = new Receipt();
        public static Visibility DetailFromHome = Visibility.Collapsed;
        //public static ObservableCollection<Receipt> ListReceipt = new ObservableCollection<Receipt>();
        //

        public static WindowManager windowManager = new WindowManager();

        public static Visibility DetailTable = Visibility.Collapsed;
        public static string Password = "";
        public static string JSON_FOOD_CONFIG_PATH = "Food.json";
    }
}