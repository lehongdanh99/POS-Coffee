﻿using System;
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
        public ActionResult Index(string FromDate, string ToDate, string sortOrder, int? pageNo)
        {
            ViewBag.ToDateSortParm = String.IsNullOrEmpty(sortOrder) ? "ToDate_desc" : "";
            ViewBag.CustomerPaySortParm = sortOrder == "CustomerPay" ? "CustomerPay_desc" : "CustomerPay";
            ViewBag.DiscountPriceSortParm = String.IsNullOrEmpty(sortOrder) ? "DiscountPrice_desc" : "";
            ViewBag.TotalPriceSortParm = String.IsNullOrEmpty(sortOrder) ? "TotalPrice_desc" : "";
            IQueryable<StatisticModel> lstStatistic = StatisticAPIHandlerFakeData.GetInstance().ListStatistic.AsQueryable();
            int count = 0;
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

                //lstStatistic = lstStatistic.Where(s => s.FromDate > FromDateSearch);
                //lstStatistic = lstStatistic.Where(s => s.ToDate < ToDateSearch);
                lstStatistic = lstStatistic.Where(s => s.Day > FromDateSearch && s.Day < ToDateSearch);

                switch (sortOrder)
                {
                    //case "FromDate_desc":
                    //    //lstStatistic = lstStatistic.OrderByDescending(s => s.FromDate.Year).ThenByDescending(s => s.FromDate.Month).ThenByDescending(s => s.FromDate.Day);
                    //    lstStatistic = lstStatistic.OrderByDescending(s => s.FromDate.Date);
                    //    break;
                    case "ToDate_desc":
                        lstStatistic = lstStatistic.OrderByDescending(s => s.Day.Year).ThenByDescending(s => s.Day.Month).ThenByDescending(s => s.Day.Day);
                        break;
                    case "CustomerPay_desc":
                        lstStatistic = lstStatistic.OrderByDescending(s => s.CustomerPay);
                        break;
                    case "DiscountPrice_desc":
                        lstStatistic = lstStatistic.OrderByDescending(s => s.DiscountPrice);
                        break;
                    case "TotalPrice_desc":
                        lstStatistic = lstStatistic.OrderByDescending(s => s.TotalPrice);
                        break;
                }

                foreach (var item in lstStatistic)
                {
                    count = item.CustomerPay + count;
                }
                ViewBag.Count = count;
                foreach (StatisticModel model in lstStatistic)
                {
                    if (model != null)
                        continue;
                }

                var Pagination1 = new PagedList<StatisticModel>(lstStatistic, pageNo ?? 1, pageSize);

                return View(Pagination1);
     
            }
            switch (sortOrder)
            {
                //case "FromDate_desc":
                //    lstStatistic = lstStatistic.OrderByDescending(s => s.FromDate);
                //    break;
                case "ToDate_desc":
                    lstStatistic = lstStatistic.OrderByDescending(s => s.Day);
                    break;
                case "CustomerPay_desc":
                    lstStatistic = lstStatistic.OrderByDescending(s => s.CustomerPay);
                    break;
                case "DiscountPrice_desc":
                    lstStatistic = lstStatistic.OrderByDescending(s => s.DiscountPrice);
                    break;
                case "TotalPrice_desc":
                    lstStatistic = lstStatistic.OrderByDescending(s => s.TotalPrice);
                    break;
            }

            foreach (var item in lstStatistic)
            {
                count = item.CustomerPay + count;
            }

            ViewBag.Count = count;
            foreach (StatisticModel model in lstStatistic)
            {
                if (model != null)
                    continue;
            }

            return View(lstStatistic.ToList());
        }
        
        public PartialViewResult GetDetails(string Table)
        {
            StatisticModel lstStatistic = StatisticAPIHandlerFakeData.GetInstance().ListStatistic.Where(s => s.Table.Equals(Table)).FirstOrDefault();
            return PartialView(lstStatistic);
        }
    }
}