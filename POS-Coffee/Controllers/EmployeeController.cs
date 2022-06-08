using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;
using PagedList;
using System.IO;

namespace POS_Coffe.Controllers
{
    public class EmployeeController : Controller
    {
        public int pageSize = 10;
        public ActionResult ViewEmployee(int? pageNo, string Username, string Password, string Phone, string Name, string Birthday, string Permission, string StringSearch, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<EmployeeModel> data = EmployeeAPIHandlerFakeData.GetInstance().ListEmployee.AsQueryable();

            if (!String.IsNullOrWhiteSpace(StringSearch))
            {
                data = data.Where(s => (s.Name).ToLower().Contains(StringSearch.ToLower()) );

            }

            switch (sortOrder)
            {
                case "name_desc":
                    data = data.OrderBy(s => s.Name);
                    break;
                case "Date":
                    data = data.OrderBy(s => s.Birthday);
                    break;
            }

            foreach (EmployeeModel model in data)
            {
                if (model != null)
                    continue;
            }
            data.ToList();
            var Pagination = new PagedList<EmployeeModel>(data, pageNo ?? 1, pageSize);
            return View(Pagination);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<string> dataPermission = new List<string>();
            dataPermission.Add("ADMIN");
            dataPermission.Add("EMPLOYEE");
            dataPermission.Add("MANAGER");

            ViewBag.Permission = new SelectList(dataPermission, "");
            EmployeeModel model = new EmployeeModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel data, HttpPostedFileWrapper Picture)
        {
            var test = Path.Combine(Server.MapPath("~/Content/images"), Picture.FileName);
            System.Console.WriteLine(data.Picture);
            int count = EmployeeAPIHandlerFakeData.GetInstance().ListEmployee.Count();
            EmployeeModel model = new EmployeeModel();
            model.EmployeeID = count + 1;
            model.Name = data.Name;
            model.Permission = data.Permission;
            model.Birthday = data.Birthday;
            model.Phone = data.Phone;
            model.Username = data.Username;
            model.Password = data.Password;
            model.Picture = test;
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