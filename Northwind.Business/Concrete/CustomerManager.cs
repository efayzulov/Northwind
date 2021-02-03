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

    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _ICustomerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            _ICustomerRepository = customerRepository;
        }
        public async Task<Customer> CreateAsync(Customer customer)
        {
            var result = await _ICustomerRepository.InsertAsync(customer);
            return result;
        }
        public async Task<Customer> EditAsync(Customer customer)
        {
            var result = await _ICustomerRepository.UpdateAsync(customer);
            return result;
        }
        public async Task<List<Customer>> GetAllAsync()
        {
            var result = await _ICustomerRepository.GetAllAsync();
            return result;
        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            var result = await _ICustomerRepository.GetByIdAsync(id);
            return result;
        }
        public async Task RemoveAsync(int id)
        {
            await _ICustomerRepository.DeleteAsync(id);
        }
    }
}
