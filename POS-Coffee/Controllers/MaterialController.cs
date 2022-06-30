using System;
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
                data = data.Where(s => s.name.ToLower().Contains(StringSearch.ToLower()) || s.type.ToLower().Contains(StringSearch.ToLower())).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    data = data.OrderBy(s => s.name).ToList();
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
            var EditData = MaterialAPIHandlerData.GetInstance().ListMaterial.Where(s => s.id == data.id).FirstOrDefault();
            MaterialsModel postMaterial = new MaterialsModel()
            {
                amount = EditData.amount,
                name = EditData.name,
                id = 0,
                type = EditData.type,
                unit = EditData.unit
            };
            if (RestAPIHandler<MaterialsModel>.PostData(postMaterial, "material" + @"/" + data.id, GlobalDef.TOKEN) == true)
            {
                MaterialAPIHandlerData.GetInstance().ListMaterial = RestAPIHandler<MaterialsModel>.parseJsonToModel(GlobalDef.MATERIAL_JSON_CONFIG_PATH);
            }
            return RedirectToAction("MaterialManagement", "Material");
        }
        [HttpGet]
        public ActionResult EditMaterial(int id)
        {
            var EditData = MaterialAPIHandlerData.GetInstance().ListMaterial.Where(s => s.id == id).FirstOrDefault();
           
            return View(EditData);
        }
        [HttpPost]
        public ActionResult EditMaterial(MaterialsModel data)
        {
            var EditData = MaterialAPIHandlerData.GetInstance().ListMaterial.Where(s => s.id == data.id).FirstOrDefault();
            MaterialsModel postMaterial = new MaterialsModel()
            {
                amount = EditData.amount,
                name = EditData.name,
                id = EditData.id,
                type = EditData.type,
                unit = EditData.unit
            };
            if (RestAPIHandler<MaterialsModel>.PutData(postMaterial, "material" + @"/" + data.id, GlobalDef.TOKEN) == true)
            {
                MaterialAPIHandlerData.GetInstance().ListMaterial = RestAPIHandler<MaterialsModel>.parseJsonToModel(GlobalDef.MATERIAL_JSON_CONFIG_PATH);
            }
            return RedirectToAction("MaterialManagement", "Material");
        }
        public ActionResult DeleteMaterial(int id)
        {
            if (RestAPIHandler<MaterialsModel>.DeleteData(id, "material" + @"/" + id, GlobalDef.TOKEN) == true)
            {
                MaterialAPIHandlerData.GetInstance().ListMaterial = RestAPIHandler<MaterialsModel>.parseJsonToModel(GlobalDef.MATERIAL_JSON_CONFIG_PATH);
            }
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