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

namespace Northwind.Web.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly  ICategoryApiClient _categoryApiClient = new CategoryApiClient();
        private static List<Category> categories = new List<Category>{
            new Category { Id = 1,Name="Category Id 1",Description = "Desc 1"},
            new Category { Id = 2,Name="Category Id 2",Description = "Desc 2"}
        };

        public CategoryController()
        {
            //ICategoryApiClient categoryApiClient
           // _categoryApiClient = categoryApiClient;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> CategoryReadData()
        {
            var response = await _categoryApiClient.GetAllCAtegories();
            string result = await response.Content.ReadAsStringAsync();

            switch ((int)response.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    var categories = JsonConvert.DeserializeObject<List<Category>>(result);
                    return Json(new { Success = true, data = categories }, JsonRequestBehavior.AllowGet);
                case (int)HttpStatusCode.NotFound:
                    return HttpNotFound();
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public async Task<ActionResult> SaveCategory(Category category)
        {
            if (category.Id == 0)
            {
                var response = await _categoryApiClient.AddCategory(category);
                string result = await response.Content.ReadAsStringAsync();

                switch ((int)response.StatusCode)
                {
                    case (int)HttpStatusCode.OK:
                        var data = JsonConvert.DeserializeObject<Category>(result);
                        return Json(new { Success = true, data = data }, JsonRequestBehavior.AllowGet);
                    case (int)HttpStatusCode.NotFound:
                        return HttpNotFound();
                    default:
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                //update
                var existCategory = categories.Find(f => f.Id == category.Id);
                existCategory.Name = category.Name;
                existCategory.Description = category.Description;
            }
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var response = await _categoryApiClient.DeleteAsync(id);

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
        public async Task<ActionResult> EditCategory(int id)
        {
            var response = await _categoryApiClient.getCategorybyIdAsync(id);
            string result = await response.Content.ReadAsStringAsync();

            switch ((int)response.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    var category = JsonConvert.DeserializeObject<Category>(result);
                    return Json(new { Success = true, data = category }, JsonRequestBehavior.AllowGet);
                case (int)HttpStatusCode.NotFound:
                    return HttpNotFound();
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}