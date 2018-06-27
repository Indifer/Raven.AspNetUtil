using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Raven.AspNet.MvcExtensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class FilterContextExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool HasMarkerAttribute<T>(this ActionExecutingContext that)
        {
            return that.ActionDescriptor.GetFilterAttributes(true).Any(x => x is T)
                || that.ActionDescriptor.ControllerDescriptor.GetFilterAttributes(true).Any(x => x is T);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool HasMarkerAttribute<T>(this ActionExecutedContext that)
        {
            return that.ActionDescriptor.GetFilterAttributes(true).Any(x => x is T)
                || that.ActionDescriptor.ControllerDescriptor.GetFilterAttributes(true).Any(x => x is T);
        }
    }
}
