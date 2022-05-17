using System.Collections.Generic;
namespace POS_Coffe
{
    public static class GlobalDef
    {
        public static string EMPLOYEE_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\Employee.json";
        public static string FOOD_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\Food.json";
        //public static string MATERIALS_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\Material.json";
        public static List<string> EMPLOYEE_ROLE = new List<string>() { "ROLE_ADMIN", "ROLE_EMPLOYEE", "ROLE_MANAGER" };

        public static string CUSTOMER_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\Customer.json";
        public static string MATERIAL_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\material.json";
        public static string RECIPE_JSON_CONFIG_PATH  = "F:\\POS-Coffee\\POS-Coffee\\Recipe.json";
        public static string VOUCHER_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\Voucher.json";
    }
}