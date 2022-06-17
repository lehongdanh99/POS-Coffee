using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe;
using PagedList;
using POS_Coffe.Models;

namespace POS_Coffe.Controllers
{
    public class HistoryTrackingController : Controller
    {
        public int pageSize = 10;
        public ActionResult IndexOfHistoryTracking(string StringSearch, int? pageNo, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = String.IsNullOrEmpty(sortOrder) ? "Price_desc" : "";

            IQueryable<HistoryTrackingModel> dataModel = HistoryTrackingAPIHandlerFakeData.GetInstance().ListHistoryTracking.AsQueryable();

            foreach (HistoryTrackingModel model in dataModel)
            {
                if (model != null)
                    continue;
            }
            dataModel.ToList();

            var Pagination = new PagedList<HistoryTrackingModel>(dataModel, pageNo ?? 1, pageSize);

            return View(Pagination);
        }

        [HttpGet]
        public PartialViewResult Details(int HistoryID)
        {
            HistoryTrackingModel dataTracking = HistoryTrackingAPIHandlerFakeData.GetInstance().ListHistoryTracking.Where(x => x.HistoryID == HistoryID).FirstOrDefault();
            if (dataTracking.TableEffect == "Employee")
            {
                EmployeeModel dataEmp = EmployeeAPIHandlerFakeData.GetInstance().ListEmployee.Where(x => x.EmployeeID == dataTracking.EmpID).FirstOrDefault();
                return PartialView(dataEmp);
            }
            return PartialView();
        }
        public ActionResult SortDay()
        {
            return View();
        }
    }
}