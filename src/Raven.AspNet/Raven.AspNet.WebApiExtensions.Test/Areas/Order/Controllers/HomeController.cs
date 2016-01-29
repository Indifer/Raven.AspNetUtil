using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Raven.AspNet.WebApiExtensions.Test.Areas.Order.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public string A()
        {
            return "a";
        }
    }
}
