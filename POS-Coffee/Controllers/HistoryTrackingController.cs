using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe;

namespace POS_Coffe.Controllers
{
    public class HistoryTrackingController : Controller
    {
        // GET: HistoryTracking
        public ActionResult IndexOfHistoryTracking()
        {
            
            return View();
        }
        public ActionResult CreateVoucher() { return View(); }
        public ActionResult EditVoucher() { return View(); }
        public ActionResult DeleteVoucher() { return View(); }
    }
}