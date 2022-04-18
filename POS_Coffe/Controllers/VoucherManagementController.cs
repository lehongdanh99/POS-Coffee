using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_Coffe.Controllers
{
    public class VoucherManagementController : Controller
    {
        // GET: VoucherManagement
        public ActionResult VoucherManagement()
        {
            return View();
        }
        public ActionResult AddVoucher()
        {
            return View();
        }
        public ActionResult EditVoucher()
        {
            return View();
        }
    }
}