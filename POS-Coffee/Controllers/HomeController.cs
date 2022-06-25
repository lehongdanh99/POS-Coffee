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
            if(dataLogin.username == null || dataLogin.password == null)
            {
                ViewBag.error = "Please fill in Username and Password!";
                return View(dataLogin);
            }
            string username = "";
            string password = "";
            try
            {
                username = dataLogin.username.Trim();
                password = dataLogin.password.Trim();
            }
            catch (Exception ex)
            {
                return View();
            }
            //string username = dataLogin.Username;
            //string password = dataLogin.Password;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && password != "PASSWORD")
            {
                try
                {
                    //EmployeeModel data = EmployeeAPIHandlerData.GetInstance().ListEmployee.Where(s => s.Username.ToUpper().Trim().Equals(username) && s.Password.Trim().ToUpper().Equals(password)).FirstOrDefault();
                    EmployeeModel model = new EmployeeModel();

                    if(!String.IsNullOrEmpty(CommonMethod.Login(username, password)))
                    {
                        GlobalDef.TOKEN = CommonMethod.Login(username, password);
                        //RestAPIHandler<EmployeeModel>.parseJsonToModel(GlobalDef.) 
                    }
                    else
                    {
                        ViewBag.error = GlobalDef.ERROR_MESSAGE_LOGIN;
                        return View(dataLogin);
                    }

                    Session["Name"] = GlobalDef.NAME;
                    //Session["Name"] = data.Name;
                    //Session["Permission"] = data.Permission;
                    //Session["Birthday"] = data.Birthday;
                    //Session["Phone"] = data.Phone;
                    //Session["Username"] = data.Username;
                    //Session["Password"] = data.Password;
                    return RedirectToAction("Index", "Statistic");
                }
                catch (Exception ex)
                {
                    ViewBag.error = GlobalDef.ERROR_MESSAGE_LOGIN;
                    return View(dataLogin);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string username, string password, string Name)
        {
            int count = EmployeeAPIHandlerData.GetInstance().ListEmployee.Count();
            EmployeeModel data = new EmployeeModel();
            data.id = count + 1;    
            data.username = username;
            data.name = Name;
            data.password = password;
            EmployeeAPIHandlerData.GetInstance().ListEmployee.Add(data);
            return RedirectToAction("Login", "Home");
        }
        public ActionResult ForgotPassWord()
        {
            return View();
        }
        public ActionResult Validation(string source)
        {
            ViewBag.source = source;
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}