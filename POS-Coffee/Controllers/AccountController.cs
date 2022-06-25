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
            if (datalogin.permission == "ROLE_ADMIN")
            {
                role = "Admin";
            }
            else if (datalogin.permission == "ROLE_MANAGER")
            {
                role = "Manager";
            }
            datalogin.permission = role;

            Session["EmployeeID"] = datalogin.id;
            Session["Name"] = datalogin.name;
            Session["Permission"] = role;
            Session["Birthday"] = datalogin.birthday;
            Session["Phone"] = datalogin.phone;
            Session["Username"] = datalogin.username;
            Session["Password"] = datalogin.password;
                
            return View(datalogin);
        }
        [HttpGet]
        public ActionResult EditAccount(int EmployeeID) 
        {
            EmployeeModel model = EmployeeAPIHandlerData.GetInstance().ListEmployee.Where(e => e.id == EmployeeID).FirstOrDefault();
            return View(model); 
        }
        [HttpPost]
        public ActionResult EditAccount(EmployeeModel dataEdit)
        {
            var data = EmployeeAPIHandlerData.GetInstance().ListEmployee.Where(s => s.id == dataEdit.id);
            //MaterialsModel model = new MaterialsModel();
            //data.ToList().First().Name = data.First().Name;
            //data.ToList().First().Phone = data.First().Phone;
            //data.ToList().First().Permission = data.First().Permission;
            //data.ToList().First().Birthday = data.First().Birthday;
            //return RedirectToAction("AccountManagement", "Account");
            return View();
        }

        public ActionResult DeleteAccount()
        {
            return View();
        }

        public ActionResult CloneAccount() 
        { 
            return View(); 
        }
    }
}