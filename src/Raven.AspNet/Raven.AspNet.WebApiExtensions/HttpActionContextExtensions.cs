using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Raven.AspNet.WebApiExtensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpActionContextExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool HasMarkerAttribute<T>(this HttpActionContext that)
            where T : class
        {
            return that.ActionDescriptor.GetCustomAttributes<T>().Any()
                || that.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<T>().Any();
        }

    }
}
