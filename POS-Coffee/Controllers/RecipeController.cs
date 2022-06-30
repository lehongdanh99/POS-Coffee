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
            List<RecipeModel> LstRecipe = RecipeAPIHandlereData.GetInstance().ListRecipe.ToList();
            return View(LstRecipe);
        }

        [HttpGet]
        public ActionResult AddRecipe()
        {
            List<DrinkCakeModel> LstDrinkCake = DrinkCakeAPIHandlerData.GetInstance().ListDrinkCake.ToList();

            ViewBag.LstDrinkCake = LstDrinkCake;

            List<MaterialsModel> LstMaterial = MaterialAPIHandlerData.GetInstance().ListMaterial.ToList();
            ViewBag.LstMaterial = LstMaterial;

            RecipeModel model = new RecipeModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddRecipe(RecipeModel data, string amountForOneM,string amountForOneL, string MaterialM,string MaterialL)
        {    
            return RedirectToAction("RecipeManagement", "Recipe");
        }
        [HttpGet]
        public ActionResult EditRecipe(int id) { return View(); }
        [HttpPost]
        public ActionResult EditRecipe() { return View(); }
        public ActionResult DeleteRecipe(
            
            ) { return View(); }

        public JsonResult getDrinkVariation(string DrinkCakeDropdown)
        {
            List<DrinkCakeDetail> Lst = new List<DrinkCakeDetail>();
            DrinkCakeModel LstDrinkCake = DrinkCakeAPIHandlerData.GetInstance().ListDrinkCake.Where(s => s.name.Equals(DrinkCakeDropdown)).FirstOrDefault();
            foreach (var item in LstDrinkCake.DrinkCakeVariations)
            {
                DrinkCakeDetail drinkCakeDetail = new DrinkCakeDetail()
                {
                    name = item.name,
                    id = item.id,
                    
                };
                Lst.Add(drinkCakeDetail);
            }
            ViewBag.DrinkCakeVarID = Lst;
            return Json(Lst, JsonRequestBehavior.AllowGet);

        }

        public ActionResult DeleteRecipe(int id) {
            if (RestAPIHandler<RecipeModel>.DeleteData(id, "recipe" + @"/" + id, GlobalDef.TOKEN) == true)
            {
                RecipeAPIHandlereData.GetInstance().ListRecipe = RestAPIHandler<RecipeModel>.parseJsonToModel(GlobalDef.RECIPE_JSON_CONFIG_PATH);
            }
            return RedirectToAction("RecipeManagement", "Recipe");
        }

        public class DrinkCakeDetail
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public PartialViewResult Details(int id) 
        {
            RecipeModel LstRecipe = RecipeAPIHandlereData.GetInstance().ListRecipe.Where(s => s.id == id).FirstOrDefault();
            return PartialView(LstRecipe); 
        }
    }
}