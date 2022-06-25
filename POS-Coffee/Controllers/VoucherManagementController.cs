using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;
using PagedList;

namespace POS_Coffe.Controllers
{
    public class VoucherManagementController : Controller
    {
        public int pageSize = 10;
        // GET: VoucherManagement
        public ActionResult VoucherManagement(int? pageNo, string StringSearch, string sortOrder)
        {
            ViewBag.ValueSortParm = String.IsNullOrEmpty(sortOrder) ? "Value_desc" : "";

            IQueryable<VoucherModel> data = VoucherAPIHandlerFakeData.GetInstance().ListVoucher.AsQueryable();
            if (!String.IsNullOrWhiteSpace(StringSearch))
            {
                data = data.Where(s => s.Name.ToLower().Contains(StringSearch.ToLower()));
            }

            
            //foreach(var item in data)
            //{
            //    FoodModel foodModel = FoodAPIHandlerData.GetInstance().ListFood.Where(s => s.FoodID == item.IDFood).FirstOrDefault();
            //    item.StrIDFood = foodModel.FoodName;
            //}

            System.Console.WriteLine(data);

            switch (sortOrder)
            {
                case "Value_desc":
                    data = data.OrderByDescending(s => s.Value);
                    break;
            }


            foreach (VoucherModel model in data)
            {
                if (model != null)
                    continue;
            }
            data.ToList();

            var Pagination = new PagedList<VoucherModel>(data, pageNo ?? 1, pageSize);

            return View(Pagination);
        }
        [HttpGet]
        public ActionResult AddVoucher()
        {
            List<string> dataIDFood = new List<string>();
            dataIDFood.Add("--none--");
            List<FoodModel> foodModel = FoodAPIHandlerData.GetInstance().ListFood.ToList();
            foreach(var item in foodModel)
            {
                dataIDFood.Add(item.FoodName);
            }
            dataIDFood.Distinct();
            ViewBag.StrIDFood = new SelectList(dataIDFood, "");
            VoucherModel model = new VoucherModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult AddVoucher(VoucherModel data)
        {
            //if (data.StrIDFood == "--none--")
            //{
            //    ViewBag.error = GlobalDef.ERROR_MESSAGE_VOUCHER_VALUE_AND_IDFOOD;
            //    List<string> dataIDFood = new List<string>();
            //    dataIDFood.Add("--none--");
            //    List<FoodModel> foodModel1 = FoodAPIHandlerData.GetInstance().ListFood.ToList();
            //    foreach (var item in foodModel1)
            //    {
            //        dataIDFood.Add(item.FoodName);
            //    }
            //    dataIDFood.Distinct();
            //    ViewBag.StrIDFood = new SelectList(dataIDFood, "");
            //    return View(data);
            //}

            //int count = VoucherAPIHandlerFakeData.GetInstance().ListVoucher.Count();
            //VoucherModel model = new VoucherModel();
            //model.Id = count + 1;
            //model.Name = data.Name;
            //model.Value = data.Value;

            //FoodModel foodModel = FoodAPIHandlerData.GetInstance().ListFood.Where(s => s.FoodName.Equals(data.StrIDFood)).FirstOrDefault();

            //model.Id = foodModel.FoodID;

            ////EmployeeModel.GetInstance().LstEmpl.Add(model);
            ////return View(model);
            //VoucherAPIHandlerFakeData.GetInstance().ListVoucher.Add(model);
            //return RedirectToAction("VoucherManagement", "VoucherManagement");
            return View();
        }
        [HttpGet]
        public ActionResult EditVoucher(int id)
        {
            //List<string> dataIDFood = new List<string>();
            //dataIDFood.Add("--none--");
            //List<FoodModel> foodModel = FoodAPIHandlerData.GetInstance().ListFood.ToList();
            //foreach (var item in foodModel)
            //{
            //    dataIDFood.Add(item.FoodName);
            //}
            //dataIDFood.Distinct();
            //ViewBag.StrIDFood = new SelectList(dataIDFood, "");

            //var EditData = VoucherAPIHandlerFakeData.GetInstance().ListVoucher.Where(s => s.VoucherID == VoucherID);
            //VoucherModel data = new VoucherModel();
            //data.Id = VoucherID;
            //data.Name = EditData.ToList().First().Name;
            //data.Value = EditData.ToList().First().Value;
            ////data.IDFood = EditData.ToList().First().IDFood;
            ////data.isValue = EditData.ToList().First().isValue;
            //return View(data);
            return View();
        }
        [HttpPost]
        public ActionResult EditVoucher(VoucherModel data)
        {
            //FoodModel foodModel = FoodAPIHandlerData.GetInstance().ListFood.Where(s => s.FoodName.Equals(data.StrIDFood)).FirstOrDefault();

            //var EditData = VoucherAPIHandlerFakeData.GetInstance().ListVoucher.Where(s => s.VoucherID == data.VoucherID);
            //VoucherModel model = new VoucherModel();
            //EditData.ToList().First().Name = data.Name;
            //EditData.ToList().First().Value = data.Value;
            //EditData.ToList().First().IDFood = foodModel.FoodID;
            ////EditData.ToList().First().isValue = data.isValue;
            //return RedirectToAction("VoucherManagement", "VoucherManagement");
            return View();
        }
        public ActionResult DeleteVoucher(int id)
        {
            //var data = VoucherAPIHandlerFakeData.GetInstance().ListVoucher.Where(s => s.Id == VoucherID).FirstOrDefault();
            //VoucherAPIHandlerFakeData.GetInstance().ListVoucher.Remove(data);
            //return RedirectToAction("VoucherManagement", "VoucherManagement");
            return RedirectToAction("VoucherManagement", "VoucherManagement");
        }
        public ActionResult FilterVoucher()
        {
            return View();
        }

        public ActionResult SortVoucher()
        {
            return View();
        }
    }
}