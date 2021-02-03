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
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerManager;

        public CustomerController(ICustomerService customerManager)
        {
            _customerManager = customerManager;

        }

        [HttpGet]
        [Route("getAllcustomer")]
        public async Task<IHttpActionResult> GetAllcustomer()
        {
            var customer = await _customerManager.GetAllAsync();
            return Ok(customer);
        }

        [HttpGet]
        [Route("getcustomerById/{id:int}")]
        public async Task<IHttpActionResult> GetProductById(int id)
        {
            var customer = await _customerManager.GetByIdAsync(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("createcustomer")]
        public async Task<IHttpActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var result = await _customerManager.CreateAsync(customer);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("editCustomer")]
        public async Task<IHttpActionResult> EditCustomer([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var result = await _customerManager.EditAsync(customer);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("deleteCustomer/{id:int}")]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {
            await _customerManager.RemoveAsync(id);
            return Ok();
        }
    }
}
