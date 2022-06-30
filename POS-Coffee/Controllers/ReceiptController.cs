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
            List<ReceiptModel> receiptModels = RestAPIHandler<ReceiptModel>.parseJsonToModel(GlobalDef.RECEIPT_JSON_CONFIG_PATH);


            return View(receiptModels);
        }
        public PartialViewResult GetDetail(int id)
        {
            ReceiptModel dataReceipt = ReceiptAPIHandler.GetInstance().ListReipt.Where(s => s.id == id).FirstOrDefault();
            return PartialView(dataReceipt);
        }
    }
}