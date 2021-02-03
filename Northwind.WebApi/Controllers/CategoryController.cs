using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using log4net;
using Northind.Entities.Concrete;
using Northwind.Business.Abstract;

namespace Northwind.WebApi.Controllers
{

    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryManager;
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CategoryController(ICategoryService categoriesManager)
        {
            _categoryManager = categoriesManager;

        }

        [HttpGet]
        [Route("getAllCategory")]
        public async Task<IHttpActionResult> getAllCategory()
        {
            log.Error("This could be an error");
            var products = await _categoryManager.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("getCategoryById/{id:int}")]
        public async Task<IHttpActionResult> getCategoryById(int id)
        {
            var product = await _categoryManager.GetByIdAsync(id);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("createCategory")]
        public async Task<IHttpActionResult> createCategory([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryManager.CreateAsync(category);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("editCategories")]
        public async Task<IHttpActionResult> EditCategories([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryManager.EditAsync(category);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("deleteCategories/{id:int}")]
        public async Task<IHttpActionResult> DeleteCategories(int id)
        {
            await _categoryManager.RemoveAsync(id);
            return Ok();
        }
    }
}

