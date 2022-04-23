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
        public JsonResult Login(EmployeeModel dataLogin)
        {
            return Json("",JsonRequestBehavior.AllowGet);
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult ForgotPassWord()
        {
            return View();
        }
    }
}