using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Raven.AspNetCore.Consul.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET api/values/5
        [HttpGet]
        public string Get()
        {
            //await Task.Delay(300);
            return "ResponseModel-Get";
        }
    }
}
