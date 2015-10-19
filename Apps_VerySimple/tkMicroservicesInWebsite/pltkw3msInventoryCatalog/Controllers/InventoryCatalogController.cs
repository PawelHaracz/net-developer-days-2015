using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pltkw3msInventoryCatalog.Controllers
{
    
    public class InventoryCatalogController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public string Find(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("FindByName")]
        public string FindByName(string name)
        {
            return "value";
        }

        [HttpGet]
        [Route("FindByCategory")]
        public string FindByCategory(string name)
        {
            return "value";
        }
        [HttpGet]
        [Route("FindSimilar")]
        public string FindSimilar(string name)
        {
            return "value";
        }
        public void Post([FromBody]string value)
        {
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public void Delete(int id)
        {
        }
    }
}
