using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northind.Entities.Concrete;

namespace Northwind.DataAccess.Abstract
{
   public interface ICustomerRepository :IGenericRepository<Customer>
    {
    }
}
