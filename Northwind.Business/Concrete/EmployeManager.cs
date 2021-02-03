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
    public class EmployeManager : IEmployeService
    {
        private readonly IEmployeRepository _employeRepository;
        public EmployeManager(IEmployeRepository employeRepository)
        {
            _employeRepository = employeRepository;
        }
        public async Task<Employe> CreateAsync(Employe employe)
        {
            var result = await _employeRepository.InsertAsync(employe);
            return result;
        }
        public async Task<Employe> EditAsync(Employe employe)
        {
            var result = await _employeRepository.UpdateAsync(employe);
            return result;
        }
        public async Task<List<Employe>> GetAllAsync()
        {
            var result = await _employeRepository.GetAllAsync();
            return result;
        }
        public async Task<Employe> GetByIdAsync(int id)
        {
            var result = await _employeRepository.GetByIdAsync(id);
            return result;
        }
        public async Task RemoveAsync(int id)
        {
            await _employeRepository.DeleteAsync(id);
        }
    }
}
