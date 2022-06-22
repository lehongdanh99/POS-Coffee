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
        public static string JSON_CONFIG_PATH = AppDomain.CurrentDomain.BaseDirectory + "TableConfig.json";
        public static string VOUCHER_JSON_CONFIG_PATH = AppDomain.CurrentDomain.BaseDirectory + "Voucher.json";
        public static string CUSTOMER_JSON_CONFIG_PATH = AppDomain.CurrentDomain.BaseDirectory + "Customer.json";
        public static string EMPLOYEE_JSON_CONFIG_PATH = AppDomain.CurrentDomain.BaseDirectory + "Employee.json";

        public static string END_POINT = "";

        public static bool IsChooseMoreTable = false;
        public static bool IsChooseTableToOrder = false;
        public static bool IsChooseVoucerToOrder = false;
        public static bool IsChooseVoucerToPayment = false;
        public static bool IsChooseVoucerToDetail = false;
        public static Receipt ReceiptDetail = new Receipt();
        public static Receipt ReceiptPayment = new Receipt();
        public static Visibility DetailFromHome = Visibility.Collapsed;

        public static bool IsDeliveryPayment = false;
        //public static ObservableCollection<Receipt> ListReceipt = new ObservableCollection<Receipt>();
        //
        public static bool IsEditing = false;

        public static string token = string.Empty;

        public static Visibility IsCakeChoose = Visibility.Collapsed; 
        public static bool canEditDetail = false;

        public static string SugarPercent = "0";
        public static string IcePercent = "0";

        public static WindowManager windowManager = new WindowManager();

        public static Visibility DetailTable = Visibility.Collapsed;
        public static string Password = "";
        public static string JSON_FOOD_CONFIG_PATH = "Food.json";
        public static string FOOD_API = "drink-cake";
        public static string RECEIPTDONE_API = "receipt";
        public static string CUSTOMER_API = "customer";
        public static string VOUCHER_API = "voucher/getList";
    }
}