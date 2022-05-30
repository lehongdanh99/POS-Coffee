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
        public int pageSize = 15;
        // GET: VoucherManagement
        public ActionResult VoucherManagement(int? pageNo, string StringSearch)
        {
            IQueryable<VoucherModel> data = VoucherAPIHandlerFakeData.GetInstance().ListVoucher.AsQueryable();
            if (!String.IsNullOrWhiteSpace(StringSearch))
            {
                data = data.Where(s => s.Name.ToLower().Contains(StringSearch.ToLower()));
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
            int count = VoucherAPIHandlerFakeData.GetInstance().ListVoucher.Count();
            VoucherModel model = new VoucherModel();
            model.VoucherID = count + 1;
            model.Name = data.Name;
            model.Value = data.Value;
            
            model.IDFood = data.IDFood;

            //EmployeeModel.GetInstance().LstEmpl.Add(model);
            //return View(model);
            VoucherAPIHandlerFakeData.GetInstance().ListVoucher.Add(model);
            return RedirectToAction("VoucherManagement", "VoucherManagement");
        }
        [HttpGet]
        public ActionResult EditVoucher(int VoucherID)
        {
            var EditData = VoucherAPIHandlerFakeData.GetInstance().ListVoucher.Where(s => s.VoucherID == VoucherID);
            VoucherModel data = new VoucherModel();
            data.VoucherID = VoucherID;
            data.Name = EditData.ToList().First().Name;
            data.Value = EditData.ToList().First().Value;
            data.IDFood = EditData.ToList().First().IDFood;
            data.isValue = EditData.ToList().First().isValue;
            return View(data);
        }
        [HttpPost]
        public ActionResult EditVoucher(VoucherModel data)
        {
            var EditData = VoucherAPIHandlerFakeData.GetInstance().ListVoucher.Where(s => s.VoucherID == data.VoucherID);
            VoucherModel model = new VoucherModel();
            EditData.ToList().First().Name = data.Name;
            EditData.ToList().First().Value = data.Value;
            EditData.ToList().First().IDFood = data.IDFood;
            EditData.ToList().First().isValue = data.isValue;
            return RedirectToAction("VoucherManagement", "VoucherManagement");
        }
        public ActionResult DeleteVoucher(int VoucherID)
        {
            var data = VoucherAPIHandlerFakeData.GetInstance().ListVoucher.Where(s => s.VoucherID == VoucherID).FirstOrDefault();
            VoucherAPIHandlerFakeData.GetInstance().ListVoucher.Remove(data);
            return RedirectToAction("VoucherManagement", "VoucherManagement");
        }
    }
}