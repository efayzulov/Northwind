using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Northind.Entities.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Extesnions;

namespace Northwind.DataAccess.Concrete
{
    public class AdoOrderRepository : IOrderRepository
    {
        public async Task<List<Order>> GetAllAsync()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().GetAsync("/api/order").Result;
                var result = JsonConvert.DeserializeObject<List<Order>>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Order> GetByIdAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().GetAsync("/api/order/" + id).Result;
                var result = JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Order> InsertAsync(Order entity)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                string data = JsonConvert.SerializeObject(entity);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.AddHeader().PostAsync("/api/order", contentData);
                var result = JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Order> UpdateAsync(Order entity)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                string data = JsonConvert.SerializeObject(entity);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.AddHeader().PutAsync("/api/order", contentData);
                var result = JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task DeleteAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().DeleteAsync("/api/order/" + id).Result;
                var result = JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
