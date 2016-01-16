using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TokenAuthMVC.API.Controllers
{
    [RoutePrefix("api/authentication")]
    public class AuthenticationController : ApiController
    {
        [Route("login")]
        [HttpGet]
        public HttpWebResponse Login()
        {
            return null;
        }
    }
}
