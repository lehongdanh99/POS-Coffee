using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;

namespace POS_Coffe.Controllers
{
    public class ReceiptController : Controller
    {
        // GET: Receipt
        public ActionResult ReceiptManagement()
        {
            List<ReceiptModel> receiptModels = ReceiptAPIHandler.GetInstance().ListReipt.ToList();
            return View(receiptModels);
        }
    }
}