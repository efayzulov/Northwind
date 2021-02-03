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
   public class AdoCustomerRepository : ICustomerRepository
    {
        public async Task<List<Customer>> GetAllAsync()
        {

            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().GetAsync("/api/customers").Result;
                var result = JsonConvert.DeserializeObject<List<Customer>>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().GetAsync("/api/customers/" + id).Result;
                var result = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Customer> InsertAsync(Customer entity)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                string data = JsonConvert.SerializeObject(entity);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.AddHeader().PostAsync("/api/customers", contentData);
                var result = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Customer> UpdateAsync(Customer entity)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                string data = JsonConvert.SerializeObject(entity);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.AddHeader().PutAsync("/api/customers", contentData);
                var result = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task DeleteAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().DeleteAsync("/api/customers/" + id).Result;
                var result = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
