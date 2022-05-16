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
            IQueryable<FoodModel> dataModel = FoodAPIHandlerFakeData.GetInstance().ListFood.AsQueryable();
            RecipeModel lstMaterial = new RecipeModel();
            foreach (var item in dataModel)
            {
                lstMaterial = RecipeAPIHandlerFakeData.GetInstance().ListRecipe.Where(s => s.FoodID == item.FoodID).FirstOrDefault();
            }
            System.Console.WriteLine(lstMaterial);
            foreach (FoodModel model in dataModel)
            {
                if (model != null)
                    continue;
            }
            return View(dataModel.ToList());
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
            FoodModel model = new FoodModel();
            model.Name = data.Name;
            model.Price = data.Price;
            model.Picture = data.Picture;

            return RedirectToAction("FoodManagement", "FoodManagement", model);
        }
        [HttpGet]
        public ActionResult EditFood(int FoodID)
        {
            var EditData = FoodAPIHandlerFakeData.GetInstance().ListFood.Where(s => s.FoodID == FoodID);
            FoodModel data = new FoodModel();
            data.FoodID = FoodID;
            data.Name = EditData.ToList().First().Name;
            data.Price= EditData.ToList().First().Price;
            data.Picture = EditData.ToList().First().Picture;
            return View(data);
        }
        [HttpPost]
        public ActionResult EditFood(FoodModel data)
        {
            var EditData = FoodAPIHandlerFakeData.GetInstance().ListFood.Where(s => s.FoodID == data.FoodID);
            FoodModel model = new FoodModel();
            EditData.ToList().First().Name = data.Name;
            EditData.ToList().First().Price = data.Price;
            EditData.ToList().First().Picture = data.Picture;
            return RedirectToAction("FoodManagement", "FoodManagement");
        }
        public ActionResult DeleteFood(int FoodID)
        {
            FoodAPIHandlerFakeData.GetInstance().ListFood.RemoveAt(FoodID - 1);
        
            return RedirectToAction("FoodManagement", "FoodManagement");
        }

        public ActionResult Details(int FoodID)
        {
            MaterialsModel frnds = new MaterialsModel();
            //var EditData = FoodAPIHandlerFakeData.GetInstance().ListFood.Where(s => s.FoodID == );
            return PartialView("_Details", frnds);
        }
    }
}