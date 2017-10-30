using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Raven.AspNet.MvcExtensions.Filters
{
    /// <summary>
    /// 模型验证过滤器
    /// </summary>
    public class ModelValidateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 验证失败时跳转的uri
        /// 例如：https://m.mallcoo.com.cn/error?msg={0}
        /// </summary>
        public string ErrorUri { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorUri">验证失败时跳转的uri例如：https://m.mallcoo.com.cn/error?msg={0} </param>
        public ModelValidateAttribute(string errorUri )
        {
            ErrorUri = errorUri;
        }

        /// <summary>
        /// Action执行前进行模型验证
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var modelState = filterContext.Controller.ViewData.ModelState;
            if (!modelState.IsValid)
            {
                StringBuilder errMsg = new StringBuilder();
                foreach (var item in modelState.Values)
                {
                    errMsg.AppendLine(string.Join(";", item.Errors.Select(e => e.ErrorMessage)));
                }
                filterContext.Result = new RedirectResult(string.Format(ErrorUri,errMsg));
            }
        }

        
    }
}
