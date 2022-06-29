using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;
using PagedList;

namespace POS_Coffe.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        public int pageSize = 10;
        public ActionResult BranchManagement(int? pageNo)
        {
            List<BranchModel> LstBranch = BranchAPIHandlerData.GetInstance().ListBranch.ToList();
            var Pagination = new PagedList<BranchModel>(LstBranch, pageNo ?? 1, pageSize);
            return View(Pagination);
        }
        [HttpGet]
        public ActionResult AddBranch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBranch(BranchModel DataBranch)
        {
            BranchModel postBranch = new BranchModel()
            {
                id = 0,
                branchName = DataBranch.branchName
            };
            if (RestAPIHandler<BranchModel>.PostData(postBranch, "branch",GlobalDef.TOKEN) == true)
            {
                BranchAPIHandlerData.GetInstance().ListBranch = RestAPIHandler<BranchModel>.parseJsonToModel(GlobalDef.BRANCH_JSON_CONFIG_PATH);
            }
            return RedirectToAction("BranchManagement", "Branch");
        }
        [HttpGet]
        public ActionResult EditBranch(int id)
        {
            var data = BranchAPIHandlerData.GetInstance().ListBranch.Where(x => x.id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult EditBranch(BranchModel data)
        {
            //var data = BranchAPIHandlerData.GetInstance().ListBranch.Where(x => x.id == id).FirstOrDefault();
            BranchModel postBranch = new BranchModel()
            {
                branchName = data.branchName,
            };
            if(RestAPIHandler<BranchModel>.PutData(postBranch, "branch"+@"/"+data.id,GlobalDef.TOKEN) == true)
            {
                BranchAPIHandlerData.GetInstance().ListBranch = RestAPIHandler<BranchModel>.parseJsonToModel(GlobalDef.BRANCH_JSON_CONFIG_PATH);
            }
            return RedirectToAction("BranchManagement", "Branch");
        }
        public ActionResult DeleteBranch(int id)
        {
            //if (RestAPIHandler<BranchModel>.DeleteData(id, "branch" + @"/" + id, GlobalDef.TOKEN) == true)
            //{
            //    BranchAPIHandlerData.GetInstance().ListBranch = RestAPIHandler<BranchModel>.parseJsonToModel(GlobalDef.BRANCH_JSON_CONFIG_PATH);
            //}
            return RedirectToAction("BranchManagement", "Branch");
        }
        public class PostBranch
        {
            public int id { get; set; }
            public string branchName { get; set; }
        }
    }
}