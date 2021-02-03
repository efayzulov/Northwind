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
    [RoutePrefix("api/employe")]
    public class EmployeController : ApiController
    {
        private readonly IEmployeService _employeManager;
        public EmployeController(IEmployeService employeManager)
        {
            _employeManager = employeManager;

        }

        [HttpGet]
        [Route("getAllemploye")]
        public async Task<IHttpActionResult> GetAllEmploye()
        {
            var employe = await _employeManager.GetAllAsync();
            return Ok(employe);
        }

        [HttpGet]
        [Route("getemployeById/{id:int}")]
        public async Task<IHttpActionResult> GetEmployeById(int id)
        {
            var employe = await _employeManager.GetByIdAsync(id);
            if (employe != null)
            {
                return Ok(employe);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("createEmploye")]
        public async Task<IHttpActionResult> CreateEmploye([FromBody] Employe employe)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeManager.CreateAsync(employe);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("editEmploye")]
        public async Task<IHttpActionResult> EditEmploye([FromBody] Employe employe)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeManager.EditAsync(employe);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("deleteEmploye/{id:int}")]
        public async Task<IHttpActionResult> DeleteEmploye(int id)
        {
            await _employeManager.RemoveAsync(id);
            return Ok();
        }
    }
}
