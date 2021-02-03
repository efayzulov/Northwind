using Newtonsoft.Json;
using Northind.Entities.Concrete;
using Northwind.Business.Abstract;
using Northwind.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            var result = await _productRepository.InsertAsync(product);
            return result;
        }
        public async Task<Product> EditAsync(Product product)
        {
            var result = await _productRepository.UpdateAsync(product);
            return result;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            var result = await _productRepository.GetAllAsync();

            return result;
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            var result = await _productRepository.GetByIdAsync(id);

            return result;
        }
        public async Task RemoveAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
