using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Raven.AspNet.WebApiExtensions.Test.A.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public string A()
        {
            return "a";
        }
    }
}
