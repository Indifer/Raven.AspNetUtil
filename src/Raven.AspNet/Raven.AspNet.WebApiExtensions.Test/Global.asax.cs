using Raven.AspNet.WebApiExtensions.Dispatchers;
using Raven.AspNet.WebApiExtensions.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;

namespace Raven.AspNet.WebApiExtensions.Test
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector),
                new NamespaceHttpControllerSelector(GlobalConfiguration.Configuration));
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new HasHandlerHttpControllerActivator());

            GlobalConfiguration.Configure(WebApiConfig.Register);
            ;
        }
    }
}
