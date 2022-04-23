using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POS_Coffe.Models;

 namespace POS_Coffe.Models
{
    public class EmployeeModel
    {
        private static EmployeeModel _instance;
        public static EmployeeModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new EmployeeModel();
                }
            }
            return _instance;
        }
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Permission { get; set; }
        public string Birthday { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private List<EmployeeModel> lstEmpl;

        public List<EmployeeModel> LstEmpl
        {
            get
            {
                if (lstEmpl == null)
                    lstEmpl = new List<EmployeeModel>();
                return lstEmpl;
            }
            set
            {
                lstEmpl = value;
            }
        }

    }

}