using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.WinForm.ApiClients.Abstract
{
    public interface ICategoryApiClient
    {
        HttpResponseMessage GetAllCAtegories();
        HttpResponseMessage DeleteAsync(int id);
        HttpResponseMessage getCategorybyIdAsync(int id);
        HttpResponseMessage AddCategory(Northind.Entities.Concrete.Category category);

    }
}
