using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Raven.AspNet.Lib
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public string A()
        {
            return "adggasg";
        }
    }
}
