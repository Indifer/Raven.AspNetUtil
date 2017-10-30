using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.AspNet.MvcExtensions.Filters;
using Raven.AspNet.MvcExtensions.Test.Models;

namespace Raven.AspNet.MvcExtensions.Test.Controllers
{
    [ModelValidate]
    public class HomeController : Controller
    {
        // GET: Home
        //非ajax请求，不会验证模型
        public ActionResult Index(TestModel model)
        {
            return View();
        }
        //ajax请求会验证参数
        public JsonResult AjaxTest(TestModel model)
        {
            return Json(new {Code=0,Message="ok"},JsonRequestBehavior.AllowGet);
        }
    }
}