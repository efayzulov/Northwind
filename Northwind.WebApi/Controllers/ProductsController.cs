using Northind.Entities.Concrete;
using Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Northwind.WebApi.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _productManager;
        public ProductsController(IProductService productManager)
        {
            _productManager = productManager;

        }

        [HttpGet]
        [Route("getAllProducts")]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            var products = await _productManager.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("getProductById/{id:int}")]
        public async Task<IHttpActionResult> GetProductById(int id)
        {
            var product = await _productManager.GetByIdAsync(id);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("createProduct")]
        public async Task<IHttpActionResult> CreateProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                var result = await _productManager.CreateAsync(product);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("editProduct")]
        public async Task<IHttpActionResult> EditProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                var result = await _productManager.EditAsync(product);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("deleteProduct/{id:int}")]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            await _productManager.RemoveAsync(id);
            return Ok();
        }
    }
}
