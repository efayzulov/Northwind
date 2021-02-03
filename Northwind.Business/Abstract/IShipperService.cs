using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northind.Entities.Concrete;

namespace Northwind.Business.Abstract
{
   public interface IShipperService
    {
        Task<List<Shipper>> GetAllAsync();
        Task<Shipper> GetByIdAsync(int id);
        Task<Shipper> CreateAsync(Shipper shippers);
        Task<Shipper> EditAsync(Shipper shippers);
        Task RemoveAsync(int id);
    }
}
