using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Raven.AspNet.MvcExtensions.Filters
{
    /// <summary>
    /// 模型验证过滤器
    /// </summary>
    public class ModelValidateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 验证失败错误码
        /// </summary>
        const int ValidateFailedCode = 400;

        /// <summary>
        /// Action执行前进行模型验证
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                var modelState = filterContext.Controller.ViewData.ModelState;
                if (!modelState.IsValid)
                {
                    StringBuilder errMsg = new StringBuilder();
                    foreach (var item in modelState.Values.Where(v => v.Errors.Count > 0))
                    {
                        errMsg.Append(string.Join(";", item.Errors.Select(e => e.ErrorMessage)));
                        errMsg.Append(";");
                    }
                    filterContext.Result = new JsonResult
                    {
                        Data = new
                        {
                            Code = ValidateFailedCode,
                            Message = errMsg.ToString()
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }
        }
    }
}
