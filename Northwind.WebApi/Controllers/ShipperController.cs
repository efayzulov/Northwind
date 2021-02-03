using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northind.Entities.Concrete;
using Northwind.Business.Abstract;

namespace Northwind.WebApi.Controllers
{
    [RoutePrefix("api/shipper")]
    public class ShipperController : ApiController
    {
        private readonly IShipperService _shipperService;
        public ShipperController(IShipperService shipperManager)
        {
            _shipperService = shipperManager;

        }

        [HttpGet]
        [Route("getAllshipper")]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            var shipper = await _shipperService.GetAllAsync();
            return Ok(shipper);
        }

        [HttpGet]
        [Route("getshipperById/{id:int}")]
        public async Task<IHttpActionResult> GetProductById(int id)
        {
            var shipper = await _shipperService.GetByIdAsync(id);
            if (shipper != null)
            {
                return Ok(shipper);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("createShipper")]
        public async Task<IHttpActionResult> CreateShipper([FromBody] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                var result = await _shipperService.CreateAsync(shipper);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("editShipper")]
        public async Task<IHttpActionResult> EditCategories([FromBody] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                var result = await _shipperService.EditAsync(shipper);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("deleteShipper/{id:int}")]
        public async Task<IHttpActionResult> DeleteShipper(int id)
        {
            await _shipperService.RemoveAsync(id);
            return Ok();
        }
    }
}

