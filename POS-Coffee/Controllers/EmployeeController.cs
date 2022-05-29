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
        public ActionResult ViewEmployee(string Username, string Password, string Phone, string Name, string Birthday, string Permission, string StringSearch)
        {
            IQueryable<EmployeeModel> data = EmployeeAPIHandlerFakeData.GetInstance().ListEmployee.AsQueryable();

            if (!String.IsNullOrWhiteSpace(StringSearch))
            {
                data = data.Where(s => (s.Name).ToLower().Contains(StringSearch.ToLower()) );

            }

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
            int count = EmployeeAPIHandlerFakeData.GetInstance().ListEmployee.Count();
            EmployeeModel model = new EmployeeModel();
            model.EmployeeID = count + 1;
            model.Name = data.Name;
            model.Permission = role;
            model.Birthday = data.Birthday;
            model.Phone = data.Phone;
            model.Username = data.Username;
            model.Password = data.Password;
            EmployeeAPIHandlerFakeData.GetInstance().ListEmployee.Add(model);
            //return View(model);
            return RedirectToAction("ViewEmployee", "Employee", model);
        }

        [HttpGet]
        public ActionResult EditEmployee(int EmployeeID)
        {
            var EditData = EmployeeAPIHandlerFakeData.GetInstance().ListEmployee.Where(s => s.EmployeeID == EmployeeID);
            EmployeeModel data = new EmployeeModel();
            data.EmployeeID = EmployeeID;
            data.Name = EditData.ToList().First().Name;
            data.Permission = EditData.ToList().First().Permission;
            data.Birthday = EditData.ToList().First().Birthday;
            data.Phone = EditData.ToList().First().Phone;
            data.Username = EditData.ToList().First().Username;
            return View(data);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel data)
        {
            var EditData = EmployeeAPIHandlerFakeData.GetInstance().ListEmployee.Where(s => s.EmployeeID == data.EmployeeID);
            EmployeeModel model = new EmployeeModel();
            EditData.ToList().First().Name = data.Name;
            EditData.ToList().First().Permission = data.Permission;
            EditData.ToList().First().Birthday = data.Birthday;
            EditData.ToList().First().Phone = data.Phone;
            EditData.ToList().First().Username = data.Username;

            return RedirectToAction("ViewEmployee", "Employee");
        }
        public ActionResult DeleteEmployee(int EmployeeID)
        {
        //    var deleteData = EmployeeAPIHandlerFakeData.GetInstance().ListEmployee.Where(s => s.EmployeeID == EmployeeID).AsQueryable();
            var data = EmployeeAPIHandlerFakeData.GetInstance().ListEmployee.Where(s => s.EmployeeID == EmployeeID).FirstOrDefault();
            EmployeeAPIHandlerFakeData.GetInstance().ListEmployee.Remove(data);
            return RedirectToAction("ViewEmployee", "Employee");
        }
    }
}