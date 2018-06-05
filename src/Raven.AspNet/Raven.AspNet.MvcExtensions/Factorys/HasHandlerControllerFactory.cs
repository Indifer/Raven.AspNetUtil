using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Raven.AspNet.MvcExtensions.Factorys
{
    public class HasHandlerControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            IController controller = base.CreateController(requestContext, controllerName);
            try
            {
                ControllerFactoryHandler.Process(controller, requestContext, controllerName);
            }
            finally
            { }
            return controller;
        }
    }
}
