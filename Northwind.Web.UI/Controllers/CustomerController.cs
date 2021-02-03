using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Northind.Entities.Concrete;
using Northwind.Web.UI.ApiClients;
using Northwind.Web.UI.ApiClients.Abstract;
using Northwind.Web.UI.ApiClients.Concrete;

namespace Northwind.Web.UI.Controllers
{

 
    public class CustomerController : Controller
    {
        private readonly ICustomerApiClient _customerApiClient = new CustomerApiClient();
        private static List<Customer> customers = new List<Customer>{
            new Customer{ Id ="1", CompanyName = "Customer Name 1", ContactName = "Contaact Name 1", ContactTitle = "Contact Ttile 1"},
            new Customer{ Id ="2", CompanyName = "Customer Name 2", ContactName = "Contaact Name 2", ContactTitle = "Contact Ttile 2"}
        };

        public CustomerController()
        {
            //ICategoryApiClient categoryApiClient
            // _categoryApiClient = categoryApiClient;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> CustomerReadData()
        {
            var response = await _customerApiClient.GetAllCustomer();
            string result = await response.Content.ReadAsStringAsync();

            switch ((int)response.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    var customers = JsonConvert.DeserializeObject<List<Customer>>(result);
                    return Json(new { Success = true, data = customers }, JsonRequestBehavior.AllowGet);
                case (int)HttpStatusCode.NotFound:
                    return HttpNotFound();
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public JsonResult SaveCategory(Customer customer)
        {
            if (customer.Id == "0")
            {
                customers.Add(customer);
            }
            else
            {
                //update
                var existCustomer = customers.Find(f => f.Id == customer.Id);
                existCustomer.CompanyName = customer.CompanyName;
                existCustomer.ContactName = customer.ContactName;
                existCustomer.ContactTitle = customer.ContactTitle;
                existCustomer.Address = customer.Address;

            }
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var response = await _customerApiClient.DeleteAsync(id);
            string result = await response.Content.ReadAsStringAsync();
            switch ((int)response.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
                case (int)HttpStatusCode.NotFound:
                    return HttpNotFound();
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public JsonResult EditCustomer(string id)
        {
            var existCustomer = customers.Find(f => f.Id == id);
            return Json(new { Success = true, data = existCustomer }, JsonRequestBehavior.AllowGet);
        }
    }
}