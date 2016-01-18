using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Raven.AspNet.WebApiExtensions.Route;
using Raven.AspNet.WebApiExtensions.Formatters;

namespace Raven.AspNet.WebApiExtensions.Test
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            config.Formatters.Remove(config.Formatters.JsonFormatter);
            config.Formatters.Add(new JilJsonFormatter());
            config.Formatters.Add(new MsgPackFormatter());

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
