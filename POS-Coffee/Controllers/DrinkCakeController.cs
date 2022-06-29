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
            DrinkCakeVariations dataDCL = new DrinkCakeVariations()
            {
                id = 0,
                name = data.nameL,
                description =  data.descriptionL,
                price = Convert.ToInt32(data.priceL),
            };
            DrinkCakeVariations dataDCM = new DrinkCakeVariations()
            {
                id = 0,
                name = data.nameM,
                description = data.descriptionM,
                price = Convert.ToInt32(data.priceM),
            };

            LstDC.Add(dataDCL);
            LstDC.Add(dataDCM);

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
        [HttpGet]
        public ActionResult EditDrinkCake(int id)
        {
            var data = DrinkCakeAPIHandlerData.GetInstance().ListDrinkCake.Where(s => s.id == id).FirstOrDefault();
            DrinkCakeDetail drinkCakeDetail = new DrinkCakeDetail();
            foreach(var item in data.DrinkCakeVariations)
            {
                if (item.name.Contains("L"))
                {
                    drinkCakeDetail.idL = item.id;
                    drinkCakeDetail.nameL = item.name;
                    drinkCakeDetail.descriptionL = item.description;
                    drinkCakeDetail.priceL = item.price.ToString();
                }
                else if (item.name.Contains("M"))
                {
                    drinkCakeDetail.idM = item.id;
                    drinkCakeDetail.nameM = item.name;
                    drinkCakeDetail.descriptionM = item.description;
                    drinkCakeDetail.priceM = item.price.ToString();
                }
            }

            drinkCakeDetail.name = data.name;
            drinkCakeDetail.id = data.id;
            drinkCakeDetail.type = data.type;
            
            return View(drinkCakeDetail);
        }

        [HttpPost]
        public ActionResult EditDrinkCake(DrinkCakeDetail editDrinkCake)
        {
            DrinkCakeModel PutDrinkCake = new DrinkCakeModel();

            List<DrinkCakeVariations> LstdrinkCakeVariationDetail = new List<DrinkCakeVariations>();

            DrinkCakeVariations drinkCakeVariationDetailL = new DrinkCakeVariations()
            {
                id = editDrinkCake.idL,
                name = editDrinkCake.nameL,
                description = editDrinkCake.descriptionL,
                price = Convert.ToInt32(editDrinkCake.priceL),
            };
            LstdrinkCakeVariationDetail.Add(drinkCakeVariationDetailL);

            DrinkCakeVariations drinkCakeVariationDetailM = new DrinkCakeVariations()
            {
                id = editDrinkCake.idM,
                name = editDrinkCake.nameM,
                description = editDrinkCake.descriptionM,
                price = Convert.ToInt32(editDrinkCake.priceM),
            };
            LstdrinkCakeVariationDetail.Add(drinkCakeVariationDetailM);

            PutDrinkCake.DrinkCakeVariations = LstdrinkCakeVariationDetail;

            PutDrinkCake.name = editDrinkCake.name;
            PutDrinkCake.id = editDrinkCake.id;
            PutDrinkCake.type = editDrinkCake.type;

            if (RestAPIHandler<DrinkCakeModel>.PutData(PutDrinkCake, "drinkcake"+@"/"+PutDrinkCake.id, GlobalDef.TOKEN) == true)
            {
                DrinkCakeAPIHandlerData.GetInstance().ListDrinkCake = RestAPIHandler<DrinkCakeModel>.parseJsonToModel(GlobalDef.DRINKCAKE_JSON_CONFIG_PATH);
            }
            return View();
        }

        public ActionResult DeleteDrinkCake() { return View(); }
    }
}