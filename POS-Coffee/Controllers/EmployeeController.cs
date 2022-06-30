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

            List<EmployeeModel> data = EmployeeAPIHandlerData.GetInstance().ListEmployee.ToList();

            if (!String.IsNullOrWhiteSpace(StringSearch))
            {
                data = data.Where(s => (s.name).ToLower().Contains(StringSearch.ToLower()) ).ToList();

            }

            switch (sortOrder)
            {
                case "name_desc":
                    data = data.OrderBy(s => s.name).ToList();
                    break;
                case "Date":
                    data = data.OrderBy(s => s.birthday).ToList();
                    break;
            }

            foreach (EmployeeModel model in data)
            {
                if (model != null)
                    continue;
            }
            //data.ToList();
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
        public ActionResult AddEmployee(EmployeeModel data)
        {
            EmployeeData EmployeeData = new EmployeeData()
            {
                name = data.name,
                birthday = data.birthday,
                username = data.username,
                password = data.password,
                address = data.address,
                phone = data.phone,
                permission = data.permission,
                id = 0
            };

            if (RestAPIHandler<EmployeeData>.PostData(EmployeeData, "employee", GlobalDef.TOKEN) == true)
            {
                EmployeeAPIHandlerData.GetInstance().ListEmployee = RestAPIHandler<EmployeeModel>.parseJsonToModel(GlobalDef.EMPLOYEE_JSON_CONFIG_PATH);
            }
            return RedirectToAction("ViewEmployee", "Employee");
        }

        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            var dataEmployee = EmployeeAPIHandlerData.GetInstance().ListEmployee.Where(x => x.id == id).FirstOrDefault();
            ViewBag.permission = dataEmployee.permission;
            return View(dataEmployee);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel data)
        {
            //var data = BranchAPIHandlerData.GetInstance().ListBranch.Where(x => x.id == id).FirstOrDefault();
            EmployeeModel putEmployee = new EmployeeModel()
            {
                address = data.address,
                birthday=data.birthday,
                id = 0,
                name = data.name,
                password = data.password,
                permission = "ADMIN",
                phone = data.phone,
                username = data.username,
            };
            if (RestAPIHandler<EmployeeModel>.PutData(putEmployee, "employee" + @"/" + data.id, GlobalDef.TOKEN) == true)
            {
                EmployeeAPIHandlerData.GetInstance().ListEmployee = RestAPIHandler<EmployeeModel>.parseJsonToModel(GlobalDef.EMPLOYEE_JSON_CONFIG_PATH);
            }
            return RedirectToAction("ViewEmployee", "Employee");
        }
        public ActionResult DeleteEmployee(int id)
        {
            if (RestAPIHandler<EmployeeModel>.DeleteData(id, "employee" + @"/" + id, GlobalDef.TOKEN) == true)
            {
                EmployeeAPIHandlerData.GetInstance().ListEmployee = RestAPIHandler<EmployeeModel>.parseJsonToModel(GlobalDef.EMPLOYEE_JSON_CONFIG_PATH);
            }
            return RedirectToAction("ViewEmployee", "Employee");
        }

        public ActionResult FilterEmployee()
        {
            return View();
        }

        public ActionResult SortEmployee()
        {
            return View();
        }
    }
}