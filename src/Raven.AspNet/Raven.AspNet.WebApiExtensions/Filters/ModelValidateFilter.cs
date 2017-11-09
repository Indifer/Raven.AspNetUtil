using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Raven.AspNet.WebApiExtensions.Filters
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
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                StringBuilder errMsg = new StringBuilder();
                foreach (var item in actionContext.ModelState.Values.Where(v => v.Errors.Count > 0))
                {
                    errMsg.Append(string.Join(";", item.Errors.Select(e => e.ErrorMessage)));
                    errMsg.Append(";");
                }
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Code = ValidateFailedCode,
                    Message = errMsg.ToString()
                });
            }
        }
    }
}
