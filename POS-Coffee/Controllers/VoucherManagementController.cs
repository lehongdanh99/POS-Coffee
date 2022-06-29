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

            IQueryable<VoucherModel> data = VoucherAPIHandlerData.GetInstance().ListVoucher.AsQueryable();
            if (!String.IsNullOrWhiteSpace(StringSearch))
            {
                data = data.Where(s => s.name.ToLower().Contains(StringSearch.ToLower()));
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
                    data = data.OrderByDescending(s => s.value);
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
            VoucherModel model = new VoucherModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult AddVoucher(VoucherModel data)
        {
            VoucherModel postVoucher = new VoucherModel()
            {
                id = 0,
                name = data.name,
                value = data.value,
                publishedDate = data.publishedDate,
                endDate = data.endDate,
            };

            if (RestAPIHandler<VoucherModel>.PostData(postVoucher, "voucher", GlobalDef.TOKEN) == true)
            {
                VoucherAPIHandlerData.GetInstance().ListVoucher = RestAPIHandler<VoucherModel>.parseJsonToModel(GlobalDef.VOUCHER_JSON_CONFIG_PATH); 
            }
            return RedirectToAction("VoucherManagement", "Voucher");
        }
        [HttpGet]
        public ActionResult EditVoucher(int id)
        {
            VoucherModel voucher = VoucherAPIHandlerData.GetInstance().ListVoucher.Where(s => s.id == id).FirstOrDefault();
            return View(voucher);
        }
        [HttpPost]
        public ActionResult EditVoucher(VoucherModel data)
        {
            VoucherModel postVoucher = new VoucherModel()
            {
                id = 0,
                name = data.name,
                value = data.value,
                publishedDate = data.publishedDate,
                endDate = data.endDate,
            };

            if (RestAPIHandler<VoucherModel>.PutData(postVoucher, "voucher"+@"/"+data.id, GlobalDef.TOKEN) == true)
            {
                VoucherAPIHandlerData.GetInstance().ListVoucher = RestAPIHandler<VoucherModel>.parseJsonToModel(GlobalDef.VOUCHER_JSON_CONFIG_PATH);
            }
            return RedirectToAction("VoucherManagement", "Voucher");
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