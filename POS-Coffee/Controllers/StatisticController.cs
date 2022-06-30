using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;
using PagedList;

namespace POS_Coffe.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        public int pageSize = 10;
        public ActionResult Index(string daytime, string ToDate, string sortOrder, int? pageNo)
        {
            if (!String.IsNullOrWhiteSpace(daytime))
            {
                string str = daytime;
                string[] LstStr = str.Split('-');
                GlobalDef.DAY = Convert.ToInt32(LstStr[2]);
                GlobalDef.MONTH = Convert.ToInt32(LstStr[1]);
                GlobalDef.YEAR = Convert.ToInt32(LstStr[0]);
            }
            else
            {
                GlobalDef.DAY = DateTime.Now.Day;
                GlobalDef.MONTH = DateTime.Now.Month;
                GlobalDef.YEAR = DateTime.Now.Year;
            }

            //StatisticModel LstStatistic = RestAPIHandler<StatisticModel>.GetData(GlobalDef.STATISTIC_JSON_CONFIG_PATH + GlobalDef.PATHGETDATE, GlobalDef.TOKEN);
            StatisticModel LstStatistic = RestAPIHandler<StatisticModel>.GetData(GlobalDef.STATISTIC_JSON_CONFIG_PATH + @"?month=06&year=2022", GlobalDef.TOKEN);
            //int sum = 0;
            //    foreach(var item in LstStatistic)
            //    {
            //        item.revenue = LstStatistic.revenue;
            //        item.receiptTotal = LstStatistic.receiptTotal;
            //    }
            //    ViewBag.Count = sum;
            return View(LstStatistic);
        }

        public PartialViewResult GetDetails(int id)
        {
            StatisticModel LstStatistic = RestAPIHandler<StatisticModel>.GetData(GlobalDef.STATISTIC_JSON_CONFIG_PATH + @"?month=06&year=2022", GlobalDef.TOKEN);
            List<ReceiptModel> receiptData = LstStatistic.receipts;
            ReceiptModel data = receiptData.Where(s => s.id == id).FirstOrDefault();
            return PartialView(data);
        }
    }
}