using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;
using PagedList;
using System.IO;

namespace POS_Coffe.Controllers
{
    public class FoodManagementController : Controller
    {
        public int pageSize = 10;
        public ActionResult FoodManagement(string StringSearch, int? pageNo, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = String.IsNullOrEmpty(sortOrder) ? "Price_desc" : "";


            IQueryable<FoodModel> dataModel = FoodAPIHandlerFakeData.GetInstance().ListFood.AsQueryable();

            if (!String.IsNullOrWhiteSpace(StringSearch))
            {
                dataModel = dataModel.Where(s => (s.FoodName).ToLower().Contains(StringSearch.ToLower()) || s.FoodType.ToLower().Contains(StringSearch.ToLower()) /*|| s.Price == Convert.ToInt32(StringSearch)*/);
            }
            System.Console.WriteLine(dataModel);
            //if(dataModel == null)
            //{
            //    dataModel = FoodAPIHandlerFakeData.GetInstance().ListFood.AsQueryable();
            //}

            //RecipeModel lstMaterial = new RecipeModel();
            //foreach (var item in dataModel)
            //{
            //    lstMaterial = RecipeAPIHandlerFakeData.GetInstance().ListRecipe.Where(s => s.RecipeID == item.FoodID).FirstOrDefault();
            //}
            //System.Console.WriteLine(lstMaterial);

            switch (sortOrder)
            {
                case "name_desc":
                    dataModel = dataModel.OrderBy(s => s.FoodName);
                    break;
                case "Price_desc":
                    dataModel = dataModel.OrderBy(s => s.FoodPrice);
                    break;
            }

            foreach (FoodModel model in dataModel)
            {
                if (model != null)
                    continue;
            }
            dataModel.ToList();

            var Pagination = new PagedList<FoodModel>(dataModel, pageNo ?? 1, pageSize);

            return View(Pagination);
        }
        [HttpGet]
        public ActionResult AddFood()
        {
            List<string> foodtype = new List<string>();
            List<MaterialsModel> materialdata = MaterialAPIHandlerFakeData.GetInstance().ListMaterial.ToList();
            foreach (var item in materialdata)
            {
                string foodtypename = item.Type;
                foodtype.Add(foodtypename);
            }
            foodtype = foodtype.Distinct().ToList();
            ViewBag.foodtype = new SelectList(foodtype, "");

            FoodModel model = new FoodModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddFood(FoodModel data, HttpPostedFileWrapper Picture)
        {
            var test = Path.Combine(Server.MapPath("~/Content/images"), Picture.FileName);
            System.Console.WriteLine(data.FoodImage);
            int count = FoodAPIHandlerFakeData.GetInstance().ListFood.Count();
            FoodModel model = new FoodModel();
            model.FoodID = count + 1;
            model.FoodName = data.FoodName;
            model.FoodPrice = data.FoodPrice;
            model.FoodType = data.FoodType;
            model.FoodImage = test;
            //model.Picture = ;
            FoodAPIHandlerFakeData.GetInstance().ListFood.Add(model);
            return RedirectToAction("FoodManagement", "FoodManagement", model);
        }

        [HttpGet]
        public ActionResult EditFood(int FoodID)
        {
            List<string> foodtype = new List<string>();
            List<MaterialsModel> materialdata = MaterialAPIHandlerFakeData.GetInstance().ListMaterial.ToList();
            foreach (var item in materialdata)
            {
                string foodtypename = item.Type;
                foodtype.Add(foodtypename);
            }
            foodtype = foodtype.Distinct().ToList();
            ViewBag.foodtype = new SelectList(foodtype, "");

            var EditData = FoodAPIHandlerFakeData.GetInstance().ListFood.Where(s => s.FoodID == FoodID);
            FoodModel data = new FoodModel();
            data.FoodID = FoodID;
            data.FoodName = EditData.ToList().First().FoodName;
            data.FoodPrice= EditData.ToList().First().FoodPrice;
            data.FoodImage = EditData.ToList().First().FoodImage;
            data.FoodType = EditData.ToList().First().FoodType;
            return View(data);
        }
        [HttpPost]
        public ActionResult EditFood(FoodModel data)
        {
            var EditData = FoodAPIHandlerFakeData.GetInstance().ListFood.Where(s => s.FoodID == data.FoodID);
            FoodModel model = new FoodModel();
            EditData.ToList().First().FoodName = data.FoodName;
            EditData.ToList().First().FoodPrice = data.FoodPrice;
            EditData.ToList().First().FoodImage = data.FoodImage;
            EditData.ToList().First().FoodType = data.FoodType;
            return RedirectToAction("FoodManagement", "FoodManagement");
        }
        public ActionResult DeleteFood(int FoodID)
        {
            var data = FoodAPIHandlerFakeData.GetInstance().ListFood.Where(s => s.FoodID == FoodID).FirstOrDefault();
            FoodAPIHandlerFakeData.GetInstance().ListFood.Remove(data);
            return RedirectToAction("FoodManagement", "FoodManagement");
        }

        [HttpGet]
        public PartialViewResult Details(int FoodID)
        {
            FoodModel dataFood = FoodAPIHandlerFakeData.GetInstance().ListFood.Where((s) => s.FoodID == FoodID).FirstOrDefault();
            int idfood = dataFood.FoodID;

            var dataReceip = RecipeAPIHandlerFakeData.GetInstance().ListRecipe.Where(s => s.Drink_Cake_ID == idfood);

            List<FoodDetail> lstfood = new List<FoodDetail>();

            foreach (var item in dataReceip)
            {
                FoodDetail foodDetail = new FoodDetail();
                int iditem = item.RecipeID;
                MaterialsModel model = MaterialAPIHandlerFakeData.GetInstance().ListMaterial.Where(s => s.MaterialID == iditem).FirstOrDefault();
                foodDetail.MaterialName = model.Name;
                foodDetail.Quantity = model.Quantity;
                foodDetail.Amount = model.Amount;
                foodDetail.Type = model.Type;
                foodDetail.Foodname = dataFood.FoodName;
                lstfood.Add(foodDetail);
            }
            return PartialView(lstfood);
        }
    }
}