﻿using System.Collections.Generic;
namespace POS_Coffe
{
    public static class GlobalDef
    {
        public static string EMPLOYEE_JSON_CONFIG_PATH = "employee";
        public static string FOOD_JSON_CONFIG_PATH = System.AppDomain.CurrentDomain.BaseDirectory + "Food.json";
        public static string MATERIALS_JSON_CONFIG_PATH = "material";
        public static List<string> EMPLOYEE_ROLE = new List<string>() { "ADMIN", "EMPLOYEE", "MANAGER" };
        public static string CUSTOMER_JSON_CONFIG_PATH = "customer";
        public static string MATERIAL_JSON_CONFIG_PATH = "material";
        public static string RECIPE_JSON_CONFIG_PATH = "recipe";
        public static string VOUCHER_JSON_CONFIG_PATH = "voucher/getList";
        public static string HISTORYTRACKING_JSON_CONFIG_PATH = "history";
        public static string STATISTIC_JSON_CONFIG_PATH = "statistic";
        public static string RECEIPT_JSON_CONFIG_PATH = "receipt";
        public static string DRINKCAKE_JSON_CONFIG_PATH = "drink-cake";
        public static string BRANCH_JSON_CONFIG_PATH = "branch";
        public static string ERROR_MESSAGE_VOUCHER_VALUE_AND_IDFOOD = "Please Fill in IdFood";
        public static string ERROR_MESSAGE_LOGIN = "Error Username or Password!";
        public static string BASE_URI = "http://34.126.139.165:8080/api/";
        public static string TOKEN = "";
        public static int IDEMP = 0;
        public static int DAY = 0;
        public static int MONTH = 0;
        public static int YEAR = 0;
        public static string NAME = "";
        //public static string PATHGETDATE = @"?day=" + GlobalDef.DAY + @"month=" + GlobalDef.MONTH + @"&year=" + GlobalDef.YEAR;
        public static string PATHGETDATE = @"?month=" + 6 + @"&year=" + 2022;
    }
}