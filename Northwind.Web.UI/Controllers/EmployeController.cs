using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Northwind.Web.UI.ApiClients;
using Northwind.Web.UI.ApiClients.Abstract;
using Northwind.Web.UI.ApiClients.Concrete;
using Northind.Entities.Concrete;

namespace Northwind.Web.UI.Controllers
{
    public class EmployeController : Controller
    {
        private readonly EmployeApiClient _employeApiClient = new EmployeApiClient();
        private static readonly List<Employe> employes = new List<Employe>{
            new Employe{Id = 1, LastName = "Employe Id 1", FirstName = "FirstName 1", Title = "Title", TitleOfCourtesy = "TitleOfCourtesy 1"},
            new Employe{Id = 2, LastName = "Employe Id 2", FirstName = "FirstName 2", Title = "Title", TitleOfCourtesy = "TitleOfCourtesy 2"},
        };

        public EmployeController()
        {
            //ICategoryApiClient categoryApiClient
            // _categoryApiClient = categoryApiClient;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> EmployeReadData()
        {
            var response = await _employeApiClient.GetAllEmploye();
            string result = await response.Content.ReadAsStringAsync();
           
            switch ((int)response.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    var employes = JsonConvert.DeserializeObject<List<Employe>>(result);
                    return Json(new { Success = true, data = employes }, JsonRequestBehavior.AllowGet);
                case (int)HttpStatusCode.NotFound:
                    return HttpNotFound();
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public JsonResult SaveCategory(Employe employe)
        {
            if (employe.Id == 0)
            {
                employes.Add(employe);
            }
            else
            {
                //update
                var existEmploye = employes.Find(f => f.Id == employe.Id);
                existEmploye.LastName = employe.LastName;
                existEmploye.FirstName = employe.FirstName;
            }
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteEmploye(int id)
        {
            var response = await _employeApiClient.DeleteAsync(id);
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
        public JsonResult EditEmploye(int id)
        {
            var existEmploye = employes.Find(f => f.Id == id);
            return Json(new { Success = true, data = existEmploye }, JsonRequestBehavior.AllowGet);
        }
    }
}