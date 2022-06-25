using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;
using PagedList;

namespace POS_Coffe.Controllers
{
    public class DrinkCakeController : Controller
    {
        public int pageSize = 10;
        public ActionResult DrinkCakeManagement(string StringSearch, int? pageNo, string sortOrder)
        {
            List<DrinkCakeModel> LstDrinkCake = DrinkCakeAPIHandlerData.GetInstance().ListDrinkCake.ToList();
            var Pagination = new PagedList<DrinkCakeModel>(LstDrinkCake, pageNo ?? 1, pageSize);
            return View(Pagination);
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
        public ActionResult AddDrinkCake(DrinkCakeDetail data/*, HttpPostedFileWrapper Picture*/)
        {
            List<DrinkCakeVariations> LstDC = new List<DrinkCakeVariations>();
            DrinkCakeVariations dataDC = new DrinkCakeVariations()
            {
                id = 0,
                name = data.name1,
                description =  data.description,
                price = Convert.ToInt32(data.price),
            };
            LstDC.Add(dataDC);
            DrinkCakeModel DrinkCakeData = new DrinkCakeModel()
            {
                id = 0,
                name = data.name,
                type = data.type,
                DrinkCakeVariations = LstDC,
            };
            if (RestAPIHandler<DrinkCakeModel>.PostData(DrinkCakeData, "drinkcake", GlobalDef.TOKEN) == true)
            {
                DrinkCakeAPIHandlerData.GetInstance().ListDrinkCake = RestAPIHandler<DrinkCakeModel>.parseJsonToModel(GlobalDef.DRINKCAKE_JSON_CONFIG_PATH);
            }
            return RedirectToAction("DrinkCakeManagement", "DrinkCake");
        }

        public ActionResult EditDrinkCake(int id)
        {
            var data = DrinkCakeAPIHandlerData.GetInstance().ListDrinkCake.Where(s => s.id == id).FirstOrDefault();
            DrinkCakeAPIHandlerData.GetInstance().ListDrinkCake.Remove(data);
            return RedirectToAction("DrinkCakeManagement", "DrinkCake");
        }
    }
}