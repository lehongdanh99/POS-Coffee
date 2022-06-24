using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;

namespace POS_Coffe.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        public ActionResult BranchManagement()
        {
            List<BranchModel> LstBranch = BranchAPIHandlerData.GetInstance().ListBranch.ToList();
            return View(LstBranch);
        }
    }
}