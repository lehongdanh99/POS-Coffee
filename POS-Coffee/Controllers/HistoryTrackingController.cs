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
        public ActionResult IndexOfHistoryTracking(string filterValue, int? pageNo, string sortOrder, string fromday, string today)
        {
            List<HistoryTrackingModel> LstHistory = HistoryTrackingAPIHandlerData.GetInstance().ListHistoryTracking.ToList();
            DateTime fromday1 = new DateTime();
            DateTime today1 = new DateTime();
            try
            {
                fromday1 = Convert.ToDateTime(fromday);
            }
            catch (Exception ex)
            {

            }
            try
            {
                today1 = Convert.ToDateTime(today);
            }
            catch (Exception ex)
            {

            }

            ViewBag.fromday = fromday;
            ViewBag.today = today;

            if (!String.IsNullOrEmpty(filterValue))
            {
                LstHistory = LstHistory.Where(s => s.table.Equals("filterValue")).ToList();
            }

            if (!String.IsNullOrEmpty(fromday))
            {
                LstHistory = LstHistory.Where(s => s.occurTime >= fromday1).ToList();
            }

            if (!String.IsNullOrEmpty(today))
            {
                LstHistory = LstHistory.Where(s => s.occurTime <= today1).ToList();
            }

            var Pagination = new PagedList<HistoryTrackingModel>(LstHistory, pageNo ?? 1, pageSize);
            return View(Pagination);
        }

        public ActionResult Details(int id)
        {
            HistoryTrackingModel LstHistory = HistoryTrackingAPIHandlerData.GetInstance().ListHistoryTracking.Where(s => s.id == id).FirstOrDefault();
            return View(LstHistory);
        }
        public ActionResult SortDay()
        {
            return View();
        }
    }
}