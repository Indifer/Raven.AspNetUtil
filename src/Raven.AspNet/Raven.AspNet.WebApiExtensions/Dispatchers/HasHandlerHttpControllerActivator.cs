using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Raven.AspNet.WebApiExtensions.Dispatchers
{
    /// <summary>
    /// 
    /// </summary>
    public class HasHandlerHttpControllerActivator : IHttpControllerActivator
    {
        DefaultHttpControllerActivator defaultHttpControllerActivator;

        /// <summary>
        /// 
        /// </summary>
        public HasHandlerHttpControllerActivator()
        {
            defaultHttpControllerActivator = new DefaultHttpControllerActivator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="controllerDescriptor"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            IHttpController controller = defaultHttpControllerActivator.Create(request, controllerDescriptor, controllerType);
            try
            {
                HttpControllerActivatorHandler.Process(controller, request, controllerDescriptor, controllerType);
            }
            finally
            { }
            return controller;
        }
    }
}
