using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.WinForm.ApiClients.Abstract
{
   public interface IEmployeApiClient
    {
        Task<HttpResponseMessage> GetAllEmploye();
        Task<HttpResponseMessage> DeleteAsync(int id);
    }
}
