using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;

namespace POS_Coffe.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult RecipeManagement()
        {
            //List<RecipeModel> recipes = RecipeAPIHandlerFakeData.GetInstance().ListRecipe.ToList();
            //List<FoodModel> lstFood = FoodAPIHandlerData.GetInstance().ListFood.ToList();
            //List<MaterialsModel> lstMaterial = MaterialAPIHandlerData.GetInstance().ListMaterial.ToList();

            //List<ReceipDetail> LstReceipDetail = new List<ReceipDetail>();
            //foreach (var recipe in recipes)
            //{
            //    FoodModel fooddata = lstFood.Where(s => s.FoodID == recipe.Drink_Cake_ID).FirstOrDefault(); 
            //    MaterialsModel materialdata = lstMaterial.Where(s => s.id == recipe.MaterialID).FirstOrDefault();

            //    var recipeDe = new ReceipDetail();
            //    recipeDe.RecipeID = recipe.RecipeID;
            //    recipeDe.MaterialID = recipe.MaterialID;
            //    recipeDe.Drink_Cake_ID = recipe.Drink_Cake_ID;
            //    if(fooddata == null)
            //    {
            //        recipeDe.FoodName = "";
            //    }
            //    else
            //    {
            //        recipeDe.FoodName = fooddata.FoodName;
            //    }
            //    if (materialdata == null)
            //    {
            //        recipeDe.MaterialName = "";
            //    }
            //    else
            //    {
            //        recipeDe.MaterialName = materialdata.name;
            //    }

            //    LstReceipDetail.Add(recipeDe);
            //}

            //return View(LstReceipDetail);
            List<RecipeModel> LstRecipe = RecipeAPIHandlereData.GetInstance().ListRecipe.ToList();
            return View(LstRecipe);
        }

        [HttpGet]
        public ActionResult AddRecipe()
        {
            RecipeModel model = new RecipeModel();

            List<FoodModel> foods = FoodAPIHandlerData.GetInstance().ListFood.ToList();
            ViewBag.Food = foods;

            List<MaterialsModel> materials = MaterialAPIHandlerData.GetInstance().ListMaterial.ToList();
            materials.ForEach(material => material.name.Distinct());
            ViewBag.Materials = materials;

            return View(model);
        }

        [HttpPost]
        public ActionResult AddRecipe(int Food, List<int> Material)
        {
            //List<FoodModel> foods = FoodAPIHandlerData.GetInstance().ListFood.Where(s => s.FoodID.ToString().Equals(Food)).ToList();

            //List<RecipeModel> recipes = RecipeAPIHandlerFakeData.GetInstance().ListRecipe.ToList();
            //int ID = recipes.Count;


            //List<RecipeModel> LstRecipe = new List<RecipeModel>();
            //int Count = 0, temp = 1;
            //foreach(var item in Material)
            //{
            //    RecipeModel dataRecipe = new RecipeModel();
            //    dataRecipe.RecipeID = ID + temp;
            //    dataRecipe.MaterialID = item;
            //    dataRecipe.Drink_Cake_ID = Food;
            //    RecipeAPIHandlerFakeData.GetInstance().ListRecipe.Add(dataRecipe);
            //    Count++;
            //    temp++;
            //}
    
            return RedirectToAction("RecipeManagement", "Recipe");
        }

        public ActionResult EditRecipe() { return View(); }
        public ActionResult DeleteRecipe() { return View(); }
    }
}