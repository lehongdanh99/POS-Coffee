using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;

namespace POS_Coffe.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult AccountManagement(EmployeeModel datalogin)
        {
            string role = "Employee";
            if (datalogin.Permission == "ROLE_ADMIN")
            {
                role = "Admin";
            }
            else if (datalogin.Permission == "ROLE_MANAGER")
            {
                role = "Manager";
            }
            datalogin.Permission = role;

            Session["EmployeeID"] = datalogin.EmployeeID;
            Session["Name"] = datalogin.Name;
            Session["Permission"] = role;
            Session["Birthday"] = datalogin.Birthday;
            Session["Phone"] = datalogin.Phone;
            Session["Username"] = datalogin.Username;
            Session["Password"] = datalogin.Password;
                
            return View(datalogin);
        }
        [HttpGet]
        public ActionResult EditAccount(int EmployeeID) 
        {
            EmployeeModel model = EmployeeAPIHandlerFakeData.GetInstance().ListEmployee.Where(e => e.EmployeeID == EmployeeID).FirstOrDefault();
            return View(model); 
        }
        [HttpPost]
        public ActionResult EditAccount(EmployeeModel dataEdit)
        {
            return View();
        }
    }
}