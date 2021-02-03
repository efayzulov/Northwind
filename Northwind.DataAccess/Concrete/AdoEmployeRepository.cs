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
    public class AdoEmployeRepository : IEmployeRepository
    {
        public async Task<List<Employe>> GetAllAsync()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().GetAsync("/api/employess").Result;
                var result = JsonConvert.DeserializeObject<List<Employe>>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Employe> GetByIdAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().GetAsync("/api/employess/" + id).Result;
                var result = JsonConvert.DeserializeObject<Employe>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Employe> InsertAsync(Employe entity)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                string data = JsonConvert.SerializeObject(entity);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.AddHeader().PostAsync("/api/employess", contentData);
                var result = JsonConvert.DeserializeObject<Employe>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task<Employe> UpdateAsync(Employe entity)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                string data = JsonConvert.SerializeObject(entity);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.AddHeader().PutAsync("/api/employess", contentData);
                var result = JsonConvert.DeserializeObject<Employe>(await response.Content.ReadAsStringAsync());

                return result;
            }
        }
        public async Task DeleteAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.AddHeader().DeleteAsync("/api/employe/" + id).Result;
                var result = JsonConvert.DeserializeObject<Employe>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
