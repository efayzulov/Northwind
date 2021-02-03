using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northind.Entities.Concrete;

namespace Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category categories);
        Task<Category> EditAsync(Category categories);
        Task RemoveAsync(int id);
    }
}
