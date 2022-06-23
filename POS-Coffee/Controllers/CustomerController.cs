using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_Coffe.Models;

namespace POS_Coffe.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult CustomerManagement()
        {
            List<CustomerModel> dataCustomer = CustomerAPIHandlerData.GetInstance().ListCustomer.ToList();
            return View(dataCustomer);
        }
    }
}