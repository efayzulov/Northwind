using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Web.UI.ApiClients.Abstract
{
   public interface ICustomerApiClient
    {
        Task<HttpResponseMessage> GetAllCustomer(); 
        Task<HttpResponseMessage> DeleteAsync(int id);
    }
}
