using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;

namespace POS_Coffe.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult ViewEmployee(string Username, string Password, string Phone, string Name, string Birthday, string Permission)
        {
            IQueryable<EmployeeModel> data = EmployeeModel.GetInstance().LstEmpl.AsQueryable();
            foreach (EmployeeModel model in data)
            {
                if (model != null)
                    continue;
            }
            return View(data.ToList());
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<string> dataPermission = new List<string>();
            dataPermission.Add("ROLE_ADMIN");
            dataPermission.Add("ROLE_EMPLOYEE");
            dataPermission.Add("ROLE_MANAGER");

            ViewBag.Permission = new SelectList(dataPermission, "");
            EmployeeModel model = new EmployeeModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel data)
        {
            string role = "Employee";
            if (data.Permission == "ROLE_ADMIN")
            {
                role = "Admin";
            }
            else if (data.Permission == "ROLE_MANAGER")
            {
                role = "Manager";
            }

            EmployeeModel model = new EmployeeModel();
            model.EmployeeID = 1;
            model.Name = data.Name;
            model.Permission = role;
            model.Birthday = data.Birthday;
            model.Phone = data.Phone;
            model.Username = data.Username;
            model.Password = data.Password;
            EmployeeModel.GetInstance().LstEmpl.Add(model);
            //return View(model);
            return RedirectToAction("ViewEmployee", "Employee", model);
        }

        [HttpGet]
        public ActionResult EditEmployee(int EmployeeID)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditEmployee()
        {
            return View();
        }
        public ActionResult DeleteEmployee(int EmployeeID)
        {
            //var deleteData = db.where(s => s.UniqueID == ID).firstorDefault;
            return View();
        }
    }
}