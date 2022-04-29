using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;

namespace POS_Coffe.Controllers
{
    public class FoodManagementController : Controller
    {
        // GET: FoodManagement
        public ActionResult FoodManagement()
        {
            IQueryable<FoodModel> data = FoodAPIHandlerFakeData.GetInstance().ListFood.AsQueryable();
            foreach (FoodModel model in data)
            {
                if (model != null)
                    continue;
            }
            return View(data.ToList());
        }
        [HttpGet]
        public ActionResult AddFood()
        {
            FoodModel model = new FoodModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddFood(FoodModel data)
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditFood()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditFood(FoodModel data)
        {
            return View();
        }
        public ActionResult DeleteFood(int FoodID)
        {
            return View();
        }
    }
}