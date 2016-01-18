using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
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

        [HttpGet]
        public User B()
        {
            return new User { Name = "gg", ID = 134 };
        }
    }
    
    public class User
    {
        
        public string Name { get; set; }

        public long ID { get; set; }
    }

}
