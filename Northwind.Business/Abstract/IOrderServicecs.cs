using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northind.Entities.Concrete;

namespace Northwind.Business.Abstract
{
   public interface IOrderServicecs
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<Order> CreateAsync(Order order);
        Task<Order> EditAsync(Order order);
        Task RemoveAsync(int id);
    }
}
