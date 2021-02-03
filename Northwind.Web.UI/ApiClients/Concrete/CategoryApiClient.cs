using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Northind.Entities.Concrete;
using Northwind.Web.UI.ApiClients.Abstract;
using Northwind.Web.UI.Extensions;

namespace Northwind.Web.UI.ApiClients
{
    public class CategoryApiClient:ICategoryApiClient
    {
        public async Task<HttpResponseMessage> GetAllCAtegories()
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.AddHeader().GetAsync("/api/category/getAllCategory");
                return response;
            }
        }

        public async Task<HttpResponseMessage> EditCategories()
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.AddHeader().GetAsync("/api/category/EditCategories");
                return response;
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.AddHeader().DeleteAsync("/api/category/deleteCategories/" + id);
                return response;
            }
        }

        public async Task<HttpResponseMessage> getCategorybyIdAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.AddHeader().GetAsync("/api/category/getCategoryById/" + id);
                return response;
            }
        }

        public async Task<HttpResponseMessage> AddCategory(Category category)
        {
            using (var httpClient = new HttpClient())
            {
                string data = JsonConvert.SerializeObject(category);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.AddHeader().PostAsync("/api/category/createCategory", contentData);

                return response;
            }
        }
    }
}