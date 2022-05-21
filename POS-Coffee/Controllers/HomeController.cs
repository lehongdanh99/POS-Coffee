using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using POS_Coffe.Models;


namespace POS_Coffe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult EmployeeManagement()
        {
            return View();
        }

        public ActionResult CustomerManagement()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";
            
            return View(); 
        }
        [HttpPost]
        public ActionResult Login(EmployeeModel dataLogin)
        {
            string username = "";
            string password = "";
            try
            {
                username = dataLogin.Username.ToUpper().Trim();
                password = dataLogin.Password.ToUpper().Trim();
            }
            catch (Exception ex)
            {
                return View();
            }
            //string username = dataLogin.Username;
            //string password = dataLogin.Password;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && password != "PASSWORD")
            {
                EmployeeModel data = EmployeeAPIHandlerFakeData.GetInstance().ListEmployee.Where(s => s.Username.ToUpper().Trim().Equals(username) && s.Password.Trim().ToUpper().Equals(password)).FirstOrDefault();
                if (data == null)
                {
                    ViewBag.Login_Fail = "Error Username or Password!";
                }
                else
                {
                    Session["EmployeeID"] = data.EmployeeID;
                    Session["Name"] = data.Name;
                    Session["Permission"] = data.Permission;
                    Session["Birthday"] = data.Birthday;
                    Session["Phone"] = data.Phone;
                    Session["Username"] = data.Username;
                    Session["Password"] = data.Password;
                    return RedirectToAction("EmployeeManagement", "Home", data);
                }
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult ForgotPassWord()
        {
            return View();
        }
        public ActionResult Login(string source)
        {
            ViewBag.source = source;
            return View();
        }
    }
}