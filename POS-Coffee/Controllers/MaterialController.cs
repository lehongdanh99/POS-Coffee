using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;

namespace POS_Coffe.Controllers
{
    public class MaterialController : Controller
    {
        // GET: Material
        public ActionResult MaterialManagement()
        {
            //IQueryable<EmployeeModel> data = EmployeeModel.GetInstance().LstEmpl.AsQueryable();
            //foreach (EmployeeModel model in data)
            //{
            //    if (model != null)
            //        continue;
            //}
            return View(/*data.ToList()*/);
        }
        public ActionResult AddMaterial()
        {
            return View();
        }
        public ActionResult EditMaterial()
        {
            return View();
        }
        public ActionResult DeleteMaterial()
        {
            return View();
        }

    }
}