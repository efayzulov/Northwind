using Newtonsoft.Json;
using Northind.Entities.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Extesnions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete
{

    public class AdoProductRepository : IProductRepository
    {
        public async Task<List<Product>> GetAllAsync()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response =  client.AddHeader().GetAsync("/api/products").Result;
                var result = JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().GetAsync("/api/products/" + id).Result;
                var result = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Product> InsertAsync(Product entity)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                string data = JsonConvert.SerializeObject(entity);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.AddHeader().PostAsync("/api/products", contentData);
                var result = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Product> UpdateAsync(Product entity)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                string data = JsonConvert.SerializeObject(entity);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.AddHeader().PutAsync("/api/products", contentData);
                var result = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task DeleteAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().DeleteAsync("/api/products/" + id).Result;
                var result = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
            }
        }

    }
}
