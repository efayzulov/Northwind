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
   public class ShipperManager :IShipperService
    {
        private readonly IShipperRepository _shipperRepository;
        public ShipperManager(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }
        public async Task<Shipper> CreateAsync(Shipper shipper)
        {
            var result = await _shipperRepository.InsertAsync(shipper);
            return result;
        }
        public async Task<Shipper> EditAsync(Shipper shipper)
        {
            var result = await _shipperRepository.UpdateAsync(shipper);
            return result;
        }
        public async Task<List<Shipper>> GetAllAsync()
        {
            var result = await _shipperRepository.GetAllAsync();
            return result;
        }
        public async Task<Shipper> GetByIdAsync(int id)
        {
            var result = await _shipperRepository.GetByIdAsync(id);
            return result;
        }
        public async Task RemoveAsync(int id)
        {
            await _shipperRepository.DeleteAsync(id);
        }
    }
}
