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
    public class AdoSupplierRepository : ISupplierRepository
    {
        public async Task<List<Supplier>> GetAllAsync()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().GetAsync("/api/supplier").Result;
                var result = JsonConvert.DeserializeObject<List<Supplier>>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Supplier> GetByIdAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().GetAsync("/api/supplier/" + id).Result;
                var result = JsonConvert.DeserializeObject<Supplier>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Supplier> InsertAsync(Supplier entity)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                string data = JsonConvert.SerializeObject(entity);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.AddHeader().PostAsync("/api/supplier", contentData);
                var result = JsonConvert.DeserializeObject<Supplier>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Supplier> UpdateAsync(Supplier entity)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                string data = JsonConvert.SerializeObject(entity);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.AddHeader().PutAsync("/api/supplier", contentData);
                var result = JsonConvert.DeserializeObject<Supplier>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task DeleteAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().DeleteAsync("/api/Supplier/" + id).Result;
                var result = JsonConvert.DeserializeObject<Supplier>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
          