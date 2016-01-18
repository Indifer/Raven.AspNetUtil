using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Raven.AspNet.WebApiExtensions.Route
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpRouteCollectionExtended
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="routes"></param>
        /// <param name="name"></param>
        /// <param name="routeTemplate"></param>
        /// <param name="defaults"></param>
        /// <param name="namespaces"></param>
        /// <returns></returns>
        public static IHttpRoute MapHttpRoute(this HttpRouteCollection routes, string name, string routeTemplate, object defaults, string[] namespaces)
        {
            return routes.MapHttpRoute(name, routeTemplate, defaults, null, null, namespaces);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="routes"></param>
        /// <param name="name"></param>
        /// <param name="routeTemplate"></param>
        /// <param name="defaults"></param>
        /// <param name="constraints"></param>
        /// <param name="handler"></param>
        /// <param name="namespaces"></param>
        /// <returns></returns>
        public static IHttpRoute MapHttpRoute(this HttpRouteCollection routes, string name, string routeTemplate, object defaults, object constraints, HttpMessageHandler handler, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            var routeValue = new HttpRouteValueDictionary(new { Namespace = namespaces });//设置路由值  
            var route = routes.CreateRoute(routeTemplate, new HttpRouteValueDictionary(defaults), new HttpRouteValueDictionary(constraints), routeValue, handler);
            routes.Add(name, route);
            return route;
        }  
    }
}
