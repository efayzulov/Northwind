using Northind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Web.UI.ApiClients.Abstract
{
    public interface ICategoryApiClient
    { 
        Task<HttpResponseMessage> GetAllCAtegories();
        Task<HttpResponseMessage> DeleteAsync(int id);
        Task<HttpResponseMessage> getCategorybyIdAsync(int id);
        Task<HttpResponseMessage> AddCategory(Category category);
    }
}
