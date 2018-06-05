using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Raven.AspNet.MvcExtensions.Factorys
{
    public static class ControllerFactoryHandler
    {
        private static SortedDictionary<string, Action<IController, RequestContext, string>> handlers
            = new SortedDictionary<string, Action<IController, RequestContext, string>>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public static void UseHandlerControllerFactory(this ControllerBuilder builder)
        {
            builder.SetControllerFactory(new HasHandlerControllerFactory());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="handler"></param>
        public static void Register(string name, Action<IController, RequestContext, string> handler)
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
        internal static void Process(IController controller, RequestContext requestContext, string controllerName)
        {
            foreach (var h in handlers)
            {
                h.Value(controller, requestContext, controllerName);
            }
        }
    }
}
