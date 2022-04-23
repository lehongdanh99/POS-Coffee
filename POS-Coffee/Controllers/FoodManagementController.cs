using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_Coffe.Controllers
{
    public class FoodManagementController : Controller
    {
        // GET: FoodManagement
        public ActionResult FoodManagement()
        {
            return View();
        }
        public ActionResult AddFood()
        {
            return View();
        }
        public ActionResult EditFood()
        {
            return View();
        }
        public ActionResult DeleteFood()
        {
            return View();
        }
    }
}