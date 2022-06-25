using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;

namespace POS_Coffe.Controllers
{
    public class DrinkCakeController : Controller
    {
        public int pageSize = 10;
        public ActionResult DrinkCakeManagement(string StringSearch, int? pageNo, string sortOrder)
        {
            List<DrinkCakeModel> LstDrinkCake = DrinkCakeAPIHandlerData.GetInstance().ListDrinkCake.ToList();
            return View(LstDrinkCake);
        }
        [HttpGet]
        public ActionResult AddDrinkCake()
        {
            List<string> foodtype = new List<string>();
            List<MaterialsModel> materialdata = MaterialAPIHandlerData.GetInstance().ListMaterial.ToList();
            foreach (var item in materialdata)
            {
                string foodtypename = item.type;
                foodtype.Add(foodtypename);
            }
            foodtype = foodtype.Distinct().ToList();
            ViewBag.foodtype = new SelectList(foodtype, "");

            DrinkCakeModel model = new DrinkCakeModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddDrinkCake(FoodModel data/*, HttpPostedFileWrapper Picture*/)
        {
            //var test = Path.Combine(Server.MapPath("~/Content/images"), Picture.FileName);
            int count = DrinkCakeAPIHandlerData.GetInstance().ListDrinkCake.Count();
            DrinkCakeModel model = new DrinkCakeModel();
            //model. = count + 1;
            //model.FoodName = data.FoodName;
            //model.FoodPrice = data.FoodPrice;
            //model.FoodType = data.FoodType;
            //model.FoodImage = test;
            //model.Picture = ;
            DrinkCakeAPIHandlerData.GetInstance().ListDrinkCake.Add(model);
            return RedirectToAction("DrinkCakeManagement", "DrinkCake", model);
        }

        public ActionResult EditDrinkCake(int id)
        {
            return View();
        }
    }
}