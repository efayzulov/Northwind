using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northind.Entities.Concrete;
using Northwind.Business.Abstract;
using Northwind.DataAccess.Abstract;

namespace Northwind.Business.Concrete
{
    public class SupplierManager : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierManager(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task<Supplier> CreateAsync(Supplier supplier)
        {
            var result = await _supplierRepository.InsertAsync(supplier);
            return result;
        }
        public async Task<Supplier> EditAsync(Supplier supplier)
        {
            var result = await _supplierRepository.UpdateAsync(supplier);
            return result;
        }
        public async Task<List<Supplier>> GetAllAsync()
        {
            var result = await _supplierRepository.GetAllAsync();
            return result;
        }
        public async Task<Supplier> GetByIdAsync(int id)
        {
            var result = await _supplierRepository.GetByIdAsync(id);
            return result;
        }
        public async Task RemoveAsync(int id)
        {
            await _supplierRepository.DeleteAsync(id);
        }
    }
}
