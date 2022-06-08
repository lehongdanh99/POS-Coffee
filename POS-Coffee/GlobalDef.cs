using System.Collections.Generic;
namespace POS_Coffe
{
    public static class GlobalDef
    {
        public static string EMPLOYEE_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\Employee.json";
        public static string FOOD_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\Food.json";
        public static string MATERIALS_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\Material.json";
        public static List<string> EMPLOYEE_ROLE = new List<string>() { "ADMIN", "EMPLOYEE", "MANAGER" };
        public static string CUSTOMER_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\Customer.json";
        public static string MATERIAL_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\material.json";
        public static string RECIPE_JSON_CONFIG_PATH  = "F:\\POS-Coffee\\POS-Coffee\\Recipe.json";
        public static string VOUCHER_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\Voucher.json";
        public static string STATISTIC_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\Statistic.json";
        public static string ERROR_MESSAGE_VOUCHER_VALUE_AND_IDFOOD = "Please choose only Value or IdFood";
        public static string ERROR_MESSAGE_LOGIN = "Error Username or Password!";
    }
}