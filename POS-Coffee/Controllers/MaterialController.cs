﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;
using PagedList;

namespace POS_Coffe.Controllers
{
    public class MaterialController : Controller
    {
        public int pageSize = 10;
        public ActionResult MaterialManagement(string StringSearch, int? pageNo, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            
            List<MaterialsModel> data = MaterialAPIHandlerData.GetInstance().ListMaterial.ToList();

            if (!String.IsNullOrWhiteSpace(StringSearch))
            {
                data = data.Where(s => s.Name.ToLower().Contains(StringSearch.ToLower()) || s.Type.ToLower().Contains(StringSearch.ToLower())).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    data = data.OrderBy(s => s.Name).ToList();
                    break;
            }

            foreach (MaterialsModel model in data)
            {
                if (model != null)
                    continue;
            }
            data.ToList();

            var Pagination = new PagedList<MaterialsModel>(data, pageNo ?? 1, pageSize);
            return View(Pagination);
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
            IQueryable countall = MaterialAPIHandlerData.GetInstance().ListMaterial.AsQueryable();
            var count = MaterialAPIHandlerData.GetInstance().ListMaterial.Count();

            MaterialsModel material = new MaterialsModel();
            //material.MaterialID = count + 1;
            //material.Name = data.Name;
            //material.Type = data.Type;
            //material.Amount = data.Amount;
            //material.Quantity = data.Quantity;
            MaterialAPIHandlerData.GetInstance().ListMaterial.Add(material);
            return RedirectToAction("MaterialManagement", "Material");
        }
        [HttpGet]
        public ActionResult EditMaterial(int MaterialID)
        {
            var EditData = MaterialAPIHandlerData.GetInstance().ListMaterial.Where(s => s.ID == MaterialID);
            MaterialsModel data = new MaterialsModel();
            //data.MaterialID = MaterialID; 
            //data.Name = EditData.ToList().First().Name;
            //data.Type = EditData.ToList().First().Type;
            //data.Amount = EditData.ToList().First().Amount;
            //data.Quantity = EditData.ToList().First().Quantity;
           
            return View(data);
        }
        [HttpPost]
        public ActionResult EditMaterial(MaterialsModel data)
        {
            var EditData = MaterialAPIHandlerData.GetInstance().ListMaterial.Where(s => s.ID == data.ID);
            MaterialsModel model = new MaterialsModel();
            //EditData.ToList().First().Name = data.Name;
            //EditData.ToList().First().Type = data.Type;
            //EditData.ToList().First().Amount = data.Amount;
            //EditData.ToList().First().Quantity = data.Quantity;
            return RedirectToAction("MaterialManagement", "Material");
        }
        public ActionResult DeleteMaterial(int ID)
        {
            var data = MaterialAPIHandlerData.GetInstance().ListMaterial.Where(s => s.ID == ID).FirstOrDefault();
            MaterialAPIHandlerData.GetInstance().ListMaterial.Remove(data);
            return RedirectToAction("MaterialManagement", "Material");
        }

        public ActionResult FilterMaterial()
        {
            return View();
        }

        public ActionResult SortMaterial()
        {
            return View();
        }
    }
}