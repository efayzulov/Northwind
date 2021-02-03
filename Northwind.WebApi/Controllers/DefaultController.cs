using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Northwind.WebApi.Controllers
{
    [RoutePrefix("api/default")]
    public class DefaultController : ApiController
    {
        // GET: api/Default
        [Route("getData")]
        public IEnumerable<string> getData()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        [Route("getData/{id:int}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
