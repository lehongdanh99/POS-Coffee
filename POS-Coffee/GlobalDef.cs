﻿using System.Collections.Generic;
namespace POS_Coffe
{
    public static class GlobalDef
    {
        public static string EMPLOYEE_JSON_CONFIG_PATH =  System.AppDomain.CurrentDomain.BaseDirectory + "Employee.json";
        public static string FOOD_JSON_CONFIG_PATH = System.AppDomain.CurrentDomain.BaseDirectory + "Food.json";
        public static string MATERIALS_JSON_CONFIG_PATH = System.AppDomain.CurrentDomain.BaseDirectory + "Material.json";
        public static List<string> EMPLOYEE_ROLE = new List<string>() { "ADMIN", "EMPLOYEE", "MANAGER" };
        public static string CUSTOMER_JSON_CONFIG_PATH = "customer";
        public static string MATERIAL_JSON_CONFIG_PATH = System.AppDomain.CurrentDomain.BaseDirectory + "material.json";
        public static string RECIPE_JSON_CONFIG_PATH  = System.AppDomain.CurrentDomain.BaseDirectory + "Recipe.json";
        public static string VOUCHER_JSON_CONFIG_PATH = System.AppDomain.CurrentDomain.BaseDirectory + "Voucher.json";
        public static string HISTORYTRACKING_JSON_CONFIG_PATH = System.AppDomain.CurrentDomain.BaseDirectory + "HistoryTracking.json";
        public static string STATISTIC_JSON_CONFIG_PATH = System.AppDomain.CurrentDomain.BaseDirectory + "Statistic.json";
        public static string RECEIPT_JSON_CONFIG_PATH = "";
        public static string ERROR_MESSAGE_VOUCHER_VALUE_AND_IDFOOD = "Please Fill in IdFood";
        public static string ERROR_MESSAGE_LOGIN = "Error Username or Password!";
        public static string BASE_URI = "http://34.126.139.165:8080/api/";
        
    }
}