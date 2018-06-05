using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Raven.AspNet.WebApiExtensions.Dispatchers
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpControllerActivatorHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void UseHandlerHttpControllerActivator(this HttpConfiguration config)
        {
            config.Services.Replace(typeof(IHttpControllerActivator), new Dispatchers.HasHandlerHttpControllerActivator());
        }

        private static SortedDictionary<string, Action<IHttpController, HttpRequestMessage, HttpControllerDescriptor, Type>> handlers
            = new SortedDictionary<string, Action<IHttpController, HttpRequestMessage, HttpControllerDescriptor, Type>>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="handler"></param>
        public static void Register(string name, Action<IHttpController, HttpRequestMessage, HttpControllerDescriptor, Type> handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException();
            }
            handlers.Add(name, handler);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static bool Remove(string name)
        {
            return handlers.Remove(name);
        }

        /// <summary>
        /// 
        /// </summary>
        internal static void Process(IHttpController httpController, HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            foreach (var h in handlers)
            {
                h.Value(httpController, request, controllerDescriptor, controllerType);
            }
        }

    }
}
