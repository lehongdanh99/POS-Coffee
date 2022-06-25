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



            IQueryable<FoodModel> dataModel = FoodAPIHandlerData.GetInstance().ListFood.AsQueryable();

            if (!String.IsNullOrWhiteSpace(StringSearch))
            {
                dataModel = dataModel.Where(s => (s.FoodName).ToLower().Contains(StringSearch.ToLower()) || s.FoodType.ToLower().Contains(StringSearch.ToLower()) /*|| s.Price == Convert.ToInt32(StringSearch)*/);
            }

            List<AllFood> allFoodList = new List<AllFood>();

            foreach (var item in dataModel)
            {
                AllFood allFood = new AllFood();
                //Insert data of Food to AllFood Model
                allFood.FoodName = item.FoodName;
                allFood.FoodType = item.FoodType;
                allFood.FoodID = item.FoodID;
                allFood.FoodImage = item.FoodImage;
                allFood.FoodPrice = item.FoodPrice;

                //Insert Materials of each Food

                int idfood = item.FoodID;

                List<RecipeModel> dataReceip = RecipeAPIHandlereData.GetInstance().ListRecipe.Where(s => s.id == idfood).ToList();

                List<FoodDetail> lstfood = new List<FoodDetail>();

                foreach (var receip in dataReceip)
                {
                    int iditem = receip.id;

                    FoodDetail foodDetail = new FoodDetail();

                    MaterialsModel model = MaterialAPIHandlerData.GetInstance().ListMaterial.Where(s => s.id == iditem).FirstOrDefault();
                    if (model != null)
                    {
                        foodDetail.MaterialName = model.name;
                        //foodDetail.Quantity = model.Quantity;
                        foodDetail.Amount = model.amount;
                        foodDetail.Type = model.type;
                        foodDetail.Foodname = item.FoodName;
                        lstfood.Add(foodDetail);
                    }
                    else
                    {
                        continue;
                    }
                }
                allFood.LstFoods = lstfood;
                allFoodList.Add(allFood);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    dataModel = dataModel.OrderBy(s => s.FoodName);
                    break;
                case "Price_desc":
                    dataModel = dataModel.OrderBy(s => s.FoodPrice);
                    break;
            }

            foreach (AllFood model in allFoodList)
            {
                if (model != null)
                    continue;
            }
            allFoodList.ToList();

            var Pagination = new PagedList<AllFood>(allFoodList, pageNo ?? 1, pageSize);

            return View(Pagination);
        }
        [HttpGet]
        public ActionResult AddFood()
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

            FoodModel model = new FoodModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddFood(FoodModel data, HttpPostedFileWrapper Picture)
        {
            var test = Path.Combine(Server.MapPath("~/Content/images"), Picture.FileName);
            System.Console.WriteLine(data.FoodImage);
            int count = FoodAPIHandlerData.GetInstance().ListFood.Count();
            FoodModel model = new FoodModel();
            model.FoodID = count + 1;
            model.FoodName = data.FoodName;
            model.FoodPrice = data.FoodPrice;
            model.FoodType = data.FoodType;
            model.FoodImage = test;
            //model.Picture = ;
            FoodAPIHandlerData.GetInstance().ListFood.Add(model);
            return RedirectToAction("FoodManagement", "FoodManagement", model);
        }

        [HttpGet]
        public ActionResult EditFood(int FoodID)
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

            var EditData = FoodAPIHandlerData.GetInstance().ListFood.Where(s => s.FoodID == FoodID);
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
            var EditData = FoodAPIHandlerData.GetInstance().ListFood.Where(s => s.FoodID == data.FoodID);
            FoodModel model = new FoodModel();
            EditData.ToList().First().FoodName = data.FoodName;
            EditData.ToList().First().FoodPrice = data.FoodPrice;
            EditData.ToList().First().FoodImage = data.FoodImage;
            EditData.ToList().First().FoodType = data.FoodType;
            return RedirectToAction("FoodManagement", "FoodManagement");
        }
        public ActionResult DeleteFood(int FoodID)
        {
            var data = FoodAPIHandlerData.GetInstance().ListFood.Where(s => s.FoodID == FoodID).FirstOrDefault();
            FoodAPIHandlerData.GetInstance().ListFood.Remove(data);
            return RedirectToAction("FoodManagement", "FoodManagement");
        }

        [HttpGet]
        public PartialViewResult Details(int FoodID)
        {
            FoodModel dataFood = FoodAPIHandlerData.GetInstance().ListFood.Where((s) => s.FoodID == FoodID).FirstOrDefault();
            int idfood = dataFood.FoodID;

            var dataReceip = RecipeAPIHandlereData.GetInstance().ListRecipe.Where(s => s.id == idfood);

            List<FoodDetail> lstfood = new List<FoodDetail>();

            foreach (var item in dataReceip)
            {
                FoodDetail foodDetail = new FoodDetail();
                int iditem = item.id;
                MaterialsModel model = MaterialAPIHandlerData.GetInstance().ListMaterial.Where(s => s.id == iditem).FirstOrDefault();
                foodDetail.MaterialName = model.name;
                //foodDetail.Quantity = model.Quantity;
                foodDetail.Amount = model.amount;
                foodDetail.Type = model.type;
                foodDetail.Foodname = dataFood.FoodName;
                lstfood.Add(foodDetail);
            }
            return PartialView(lstfood);
        }
        public ActionResult FilterFood()
        {
            return View();
        }

        public ActionResult SortFood()
        {
            return View();
        }
    }
}