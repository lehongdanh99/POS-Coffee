using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;
using PagedList;
namespace POS_Coffe.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public int pageSize = 10;
        public ActionResult CustomerManagement(int? pageNo)
        {
            List<CustomerModel> dataCustomer = CustomerAPIHandlerData.GetInstance().ListCustomer.ToList();
            var Pagination = new PagedList<CustomerModel>(dataCustomer, pageNo ?? 1, pageSize);
            return View(Pagination);
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            CustomerModel model = new CustomerModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddCustomer(CustomerModel DataCustomer)
        {
            CustomerModel postCustomer = new CustomerModel()
            {
                id = 0,
                phone = DataCustomer.phone,
                name = DataCustomer.name,
                point = 0,
                previousPoint = 0,
            };

            if (RestAPIHandler<CustomerModel>.PostData(postCustomer, "customer", GlobalDef.TOKEN) == true)
            {
                CustomerAPIHandlerData.GetInstance().ListCustomer = RestAPIHandler<CustomerModel>.parseJsonToModel(GlobalDef.CUSTOMER_JSON_CONFIG_PATH);
            }
            return RedirectToAction("CustomerManagement", "Customer");
        }
        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            var data = CustomerAPIHandlerData.GetInstance().ListCustomer.Where(x => x.id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult EditCustomer(CustomerModel DataCustomer)
        {
            //var data = BranchAPIHandlerData.GetInstance().ListBranch.Where(x => x.id == id).FirstOrDefault();
            CustomerModel putBranch = new CustomerModel()
            {
                id = 0,
                phone = DataCustomer.phone,
                name = DataCustomer.name,
                point = DataCustomer.point,
                previousPoint=DataCustomer.previousPoint,
            };
            if (RestAPIHandler<CustomerModel>.PutData(putBranch, "customer" + @"/" + DataCustomer.id, GlobalDef.TOKEN) == true)
            {
                CustomerAPIHandlerData.GetInstance().ListCustomer = RestAPIHandler<CustomerModel>.parseJsonToModel(GlobalDef.CUSTOMER_JSON_CONFIG_PATH);
            }
            return RedirectToAction("CustomerManagement", "Customer");
        }
        public ActionResult DeleteCustomer(int id)
        {
            if (RestAPIHandler<CustomerModel>.DeleteData(id, "customer" + @"/" + id, GlobalDef.TOKEN) == true)
            {
                CustomerAPIHandlerData.GetInstance().ListCustomer = RestAPIHandler<CustomerModel>.parseJsonToModel(GlobalDef.CUSTOMER_JSON_CONFIG_PATH);
            }
            return RedirectToAction("CustomerManagement", "Customer");

        }
    }
}