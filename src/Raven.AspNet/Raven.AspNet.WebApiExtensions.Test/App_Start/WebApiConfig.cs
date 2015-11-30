using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Raven.AspNet.WebApiExtensions.Route;

namespace Raven.AspNet.WebApiExtensions.Test
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                namespaces: new string[] { "Raven.AspNet.WebApiExtensions.Test.A.Controllers" }
                
            );
        }
    }
}
