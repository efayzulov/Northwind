using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Northwind.Web.UI.ApiClients.Abstract;
using Northwind.Web.UI.Extensions;

namespace Northwind.Web.UI.ApiClients.Concrete
{
    public class CustomerApiClient : ICustomerApiClient
    {
        public async Task<HttpResponseMessage> GetAllCustomer()
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.AddHeader().GetAsync("/api/customer/GetAllcustomer");
                return response;
            }
        }
        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.AddHeader().DeleteAsync("/api/customer/DeleteCustomer/" + id);
                return response;
            }
        }

    }
}