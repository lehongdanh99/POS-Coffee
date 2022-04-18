using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;

namespace POS_Coffe.Controllers
{
    public class IngredientsController : Controller
    {
        // GET: Ingredients
        public ActionResult ViewIngredients()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddIngredients()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddIngredients(MaterialsModel NewData)
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditIngredients()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditIngredients(int ID)
        {
            return View();
        }
    }
}