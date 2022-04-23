using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_Coffe.Models
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult AccountManagement()
        {
            return View();
        }
        public ActionResult EditAccount() { return View(); }
    }
}