using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Northwind.Web.UI.Extensions;

namespace Northwind.WinForm.ApiClients.Abstract.Concrete
{
    public class CategoryApiClient : ICategoryApiClient
    {
        public HttpResponseMessage GetAllCAtegories()
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response =  httpClient.AddHeader().GetAsync("/api/category/getAllCategory").Result;
                return response;
            }
        }

        public HttpResponseMessage EditCategories()
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response =  httpClient.AddHeader().GetAsync("/api/category/EditCategories").Result;
                return response;
            }
        }

        public HttpResponseMessage DeleteAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response =  httpClient.AddHeader().DeleteAsync("/api/category/deleteCategories/" + id).Result;
                return response;
            }
        }

        public HttpResponseMessage getCategorybyIdAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response =  httpClient.AddHeader().GetAsync("/api/category/getCategoryById/" + id).Result;
                return response;
            }
        }

        public HttpResponseMessage AddCategory(Northind.Entities.Concrete.Category category)
        {
            using (var httpClient = new HttpClient())
            {
                string data = JsonConvert.SerializeObject(category);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response =  httpClient.AddHeader().PostAsync("/api/category/createCategory", contentData).Result;

                return response;
            }
        }

    }
}