using Northind.Entities.Concrete;
using Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccess.Abstract;

namespace Northwind.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoriesRepository;
        public CategoryManager(ICategoryRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        public async Task<Category> CreateAsync(Category categories)
        {
            var result = await _categoriesRepository.InsertAsync(categories);
            return result;
        }
        public async Task<Category> EditAsync(Category categories)
        {
            var result = await _categoriesRepository.UpdateAsync(categories);
            return result;
        }
        public async Task<List<Category>> GetAllAsync()
        {
            var result = await _categoriesRepository.GetAllAsync();
            return result;
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            var result = await _categoriesRepository.GetByIdAsync(id);
            return result;
        }
        public async Task RemoveAsync(int id)
        {
            await _categoriesRepository.DeleteAsync(id);
        }
    }
}
