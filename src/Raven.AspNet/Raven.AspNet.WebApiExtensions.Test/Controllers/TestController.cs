using Raven.AspNet.WebApiExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Raven.AspNet.WebApiExtensions.Test.A.Controllers
{
    [ExceptionProcess]
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

        [HttpGet]
        [Compression]
        public List<User> C()
        {
            List<User> list = new List<Controllers.User>();
            for (var i = 0; i < 10; i++)
            {
                list.Add(new User { Name = "gg", ID = 134 });
            }
            return list;
        }

    }

    public class User
    {

        public string Name { get; set; }

        public long ID { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class ExceptionProcessAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            ;
            base.OnException(actionExecutedContext);
        }
    }
}
