using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;

namespace POS_Coffe.Controllers
{
    public class MaterialController : Controller
    {
        public ActionResult MaterialManagement(string StringSearch)
        {
            IQueryable<MaterialsModel> data = MaterialAPIHandlerFakeData.GetInstance().ListMaterial.AsQueryable();

            if (!String.IsNullOrWhiteSpace(StringSearch))
            {
                data = data.Where(s => s.Name.ToLower().Contains(StringSearch.ToLower()) || s.Type.ToLower().Contains(StringSearch.ToLower()));
            }

            foreach (MaterialsModel model in data)
            {
                if (model != null)
                    continue;
            }
            return View(data.ToList());
        }
        [HttpGet]
        public ActionResult AddMaterial()
        {
            MaterialsModel model = new MaterialsModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddMaterial(MaterialsModel data)
        {
            IQueryable countall = MaterialAPIHandlerFakeData.GetInstance().ListMaterial.AsQueryable();
            var count = MaterialAPIHandlerFakeData.GetInstance().ListMaterial.Count();

            MaterialsModel material = new MaterialsModel();
            material.MaterialID = count + 1;
            material.Name = data.Name;
            material.Type = data.Type;
            material.Amount = data.Amount;
            material.Quantity = data.Quantity;
            MaterialAPIHandlerFakeData.GetInstance().ListMaterial.Add(material);
            return RedirectToAction("MaterialManagement", "Material");
        }
        [HttpGet]
        public ActionResult EditMaterial(int MaterialID)
        {
            var EditData = MaterialAPIHandlerFakeData.GetInstance().ListMaterial.Where(s => s.MaterialID == MaterialID);
            MaterialsModel data = new MaterialsModel();
            data.MaterialID = MaterialID; 
            data.Name = EditData.ToList().First().Name;
            data.Type = EditData.ToList().First().Type;
            data.Amount = EditData.ToList().First().Amount;
            data.Quantity = EditData.ToList().First().Quantity;
           
            return View(data);
        }
        [HttpPost]
        public ActionResult EditMaterial(MaterialsModel data)
        {
            var EditData = MaterialAPIHandlerFakeData.GetInstance().ListMaterial.Where(s => s.MaterialID == data.MaterialID);
            MaterialsModel model = new MaterialsModel();
            EditData.ToList().First().Name = data.Name;
            EditData.ToList().First().Type = data.Type;
            EditData.ToList().First().Amount = data.Amount;
            EditData.ToList().First().Quantity = data.Quantity;
            return RedirectToAction("MaterialManagement", "Material");
        }
        public ActionResult DeleteMaterial(int MaterialID)
        {
            MaterialAPIHandlerFakeData.GetInstance().ListMaterial.RemoveAt(MaterialID - 1);
            return RedirectToAction("MaterialManagement", "Material");
        }
    }
}