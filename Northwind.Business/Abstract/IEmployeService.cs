using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northind.Entities.Concrete;

namespace Northwind.Business.Abstract
{
   public interface IEmployeService
    {
        Task<List<Employe>> GetAllAsync();
        Task<Employe> GetByIdAsync(int id);
        Task<Employe> CreateAsync(Employe employe);
        Task<Employe> EditAsync(Employe employe);
        Task RemoveAsync(int id);
    }
}
