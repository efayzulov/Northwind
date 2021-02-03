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
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private readonly IOrderServicecs _orderServicecs;
        public OrderController(IOrderServicecs orderManager)
        {
            _orderServicecs = orderManager;

        }

        [HttpGet]
        [Route("getAllorder")]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            var order = await _orderServicecs.GetAllAsync();
            return Ok(order);
        }

        [HttpGet]
        [Route("getorderById/{id:int}")]
        public async Task<IHttpActionResult> GetProductById(int id)
        {
            var order = await _orderServicecs.GetByIdAsync(id);
            if (order != null)
            {
                return Ok(order);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("createorder")]
        public async Task<IHttpActionResult> CreateCategories([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderServicecs.CreateAsync(order);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("editOrder")]
        public async Task<IHttpActionResult> EditCategories([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderServicecs.EditAsync(order);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("deleteorder/{id:int}")]
        public async Task<IHttpActionResult> DeleteCategories(int id)
        {
            await _orderServicecs.RemoveAsync(id);
            return Ok();
        }
    }
}


    