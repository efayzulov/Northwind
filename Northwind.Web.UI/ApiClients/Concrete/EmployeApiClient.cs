using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Northwind.Web.UI.Extensions;

namespace Northwind.Web.UI.ApiClients.Concrete
{
    public class EmployeApiClient
    {
        public async Task<HttpResponseMessage> GetAllEmploye()
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.AddHeader().GetAsync("/api/employe/getAllEmploye");
                return response;
            }
        }
        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.AddHeader().DeleteAsync("/api/employe/deleteEmploye/" + id);
                return response;
            }
        }

    }
}