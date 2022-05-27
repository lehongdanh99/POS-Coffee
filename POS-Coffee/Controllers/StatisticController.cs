using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;

namespace POS_Coffe.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        public ActionResult Index(string FromDate, string ToDate)
        {
            IQueryable<StatisticModel> lstStatistic = StatisticAPIHandlerFakeData.GetInstance().ListStatistic.AsQueryable();
            if (!String.IsNullOrWhiteSpace(FromDate) || !String.IsNullOrWhiteSpace(ToDate))
            {
                DateTime FromDateSearch = DateTime.Now;
                DateTime ToDateSearch = DateTime.Now;
                try
                {
                    FromDateSearch = DateTime.Parse(FromDate);
                }
                catch (Exception ex)
                {

                }
                try
                {
                    ToDateSearch = DateTime.Parse(ToDate);
                }
                catch (Exception ex)
                {

                }
                System.Console.WriteLine(FromDateSearch);
                System.Console.WriteLine(FromDateSearch);

                lstStatistic = lstStatistic.Where(s => s.FromDate > FromDateSearch);
                lstStatistic = lstStatistic.Where(s => s.ToDate < ToDateSearch);

                foreach (StatisticModel model in lstStatistic)
                {
                    if (model != null)
                        continue;
                }
                return View(lstStatistic.ToList());
            }
            foreach (StatisticModel model in lstStatistic)
            {
                if (model != null)
                    continue;
            }
            return View(lstStatistic.ToList());
        }
    }
}