﻿using System;
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

        public static Receipt ReceiptDetail = new Receipt();
        public static Visibility DetailFromHome = Visibility.Collapsed;
        //public static ObservableCollection<Receipt> ListReceipt = new ObservableCollection<Receipt>();
    }
}