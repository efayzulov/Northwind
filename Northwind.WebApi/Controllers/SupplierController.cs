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
    [RoutePrefix("api/supplier")]
    public class SupplierController : ApiController
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierManager)
        {
            _supplierService = supplierManager;

        }

        [HttpGet]
        [Route("getAllsupplier")]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            var supplier = await _supplierService.GetAllAsync();
            return Ok(supplier);
        }

        [HttpGet]
        [Route("getsupplierById/{id:int}")]
        public async Task<IHttpActionResult> GetProductById(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);
            if (supplier != null)
            {
                return Ok(supplier);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("createsupplier")]
        public async Task<IHttpActionResult> CreateCategories([FromBody] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var result = await _supplierService.CreateAsync(supplier);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("editSupplier")]
        public async Task<IHttpActionResult> EditCategories([FromBody] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var result = await _supplierService.EditAsync(supplier);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("deleteSupplier/{id:int}")]
        public async Task<IHttpActionResult> DeleteSupplier(int id)
        {
            await _supplierService.RemoveAsync(id);
            return Ok();
        }
    }
}

