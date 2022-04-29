using System.Collections.Generic;
namespace POS_Coffe
{
    public static class GlobalDef
    {
        public static string EMPLOYEE_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\Employee.json";
        public static string FOOD_JSON_CONFIG_PATH = "F:\\POS-Coffee\\POS-Coffee\\Food.json";
        public static List<string> EMPLOYEE_ROLE = new List<string>() { "ROLE_ADMIN", "ROLE_EMPLOYEE", "ROLE_MANAGER" };
    }
}