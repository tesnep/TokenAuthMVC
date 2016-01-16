using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenAuthMVC.API.Attributes;

namespace TokenAuthMVC.API.Controllers
{
    [RestAuthorize]
    public class ExampleAPIController : ApiController
    {
        // GET: api/ExampleAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ExampleAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ExampleAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ExampleAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ExampleAPI/5
        public void Delete(int id)
        {
        }
    }
}
