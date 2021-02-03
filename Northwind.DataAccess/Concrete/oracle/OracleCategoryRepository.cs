using Newtonsoft.Json;
using Northind.Entities.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Extesnions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete
{
    public class OracleCategoryRepository : ICategoryRepository
    {
        public async Task<List<Category>> GetAllAsync()
        {

            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().GetAsync("/api/categories").Result;
                var result = JsonConvert.DeserializeObject<List<Category>>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().GetAsync("/api/category/" + id).Result;
                var result = JsonConvert.DeserializeObject<Category>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Category> InsertAsync(Category entity)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                string data = JsonConvert.SerializeObject(entity);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.AddHeader().PostAsync("/api/category", contentData);
                var result = JsonConvert.DeserializeObject<Category>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Category> UpdateAsync(Category entity)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                string data = JsonConvert.SerializeObject(entity);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.AddHeader().PutAsync("/api/category", contentData);
                var result = JsonConvert.DeserializeObject<Category>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task DeleteAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response =await client.AddHeader().DeleteAsync("/api/categories/" + id);
                var result = JsonConvert.DeserializeObject<Category>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
         