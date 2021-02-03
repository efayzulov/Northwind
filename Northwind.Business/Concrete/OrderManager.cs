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
    public class OrderManager : IOrderServicecs
    {
        private readonly IOrderRepository _ordersRepository;
        public OrderManager(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public async Task<Order> CreateAsync(Order order)
        {
            var result = await _ordersRepository.InsertAsync(order);
            return result;
        }
        public async Task<Order> EditAsync(Order order)
        {
            var result = await _ordersRepository.UpdateAsync(order);
            return result;
        }
        public async Task<List<Order>> GetAllAsync()
        {
            var result = await _ordersRepository.GetAllAsync();
            return result;
        }
        public async Task<Order> GetByIdAsync(int id)
        {
            var result = await _ordersRepository.GetByIdAsync(id);

            return result;
        }
        public async Task RemoveAsync(int id)
        {
            await _ordersRepository.DeleteAsync(id);
        }
    }
}
