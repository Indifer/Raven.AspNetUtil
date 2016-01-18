using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Raven.AspNet.WebApiExtensions.Route
{
    /// <summary>
    /// 
    /// </summary>
    public class NamespaceHttpControllerSelector : DefaultHttpControllerSelector
    {
        private static readonly string ControllerKey = "controller";
        private const string NamespaceRouteVariableName = "Namespace";
        private readonly HttpConfiguration _configuration;
        private readonly Lazy<ConcurrentDictionary<string, Type>> _apiControllerCache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public NamespaceHttpControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
            _configuration = configuration;
            _apiControllerCache = new Lazy<ConcurrentDictionary<string, Type>>(new Func<ConcurrentDictionary<string, Type>>(InitializeApiControllerCache));
        }

        private ConcurrentDictionary<string, Type> InitializeApiControllerCache()
        {
            IAssembliesResolver assembliesResolver = this._configuration.Services.GetAssembliesResolver();
            var types = this._configuration.Services.GetHttpControllerTypeResolver().GetControllerTypes(assembliesResolver);

            return new ConcurrentDictionary<string, Type>(types.ToDictionary(t => t.FullName, t => t));
        }

        public IEnumerable<string> GetControllerFullName(HttpRequestMessage request, string controllerName)
        {
            object namespaceName;
            var data = request.GetRouteData();
            IEnumerable<string> keys = _apiControllerCache.Value.ToDictionary<KeyValuePair<string, Type>, string, Type>(t => t.Key,
                    t => t.Value, StringComparer.CurrentCultureIgnoreCase).Keys.ToList();
            if (data.Route.DataTokens == null ||
                !data.Route.DataTokens.TryGetValue(NamespaceRouteVariableName, out namespaceName))
            {
                return from k in keys
                       where k.EndsWith(string.Format(".{0}{1}", controllerName, ControllerKey), StringComparison.CurrentCultureIgnoreCase)
                       select k;
            }

            //get the defined namespace
            string[] namespaces = (string[])namespaceName;
            return from n in namespaces
                   join k in keys on string.Format("{0}.{1}{2}", n, controllerName, ControllerKey).ToLower() equals k.ToLower()
                   select k;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            Type type;
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            string controllerName = this.GetControllerName(request);
            if (string.IsNullOrEmpty(controllerName))
            {
                throw new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.NotFound,
                    string.Format("No route providing a controller name was found to match request URI '{0}'", new object[] { request.RequestUri })));
            }
            IEnumerable<string> fullNames = GetControllerFullName(request, controllerName);
            if (fullNames.Count() == 0)
            {
                throw new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.NotFound,
                        string.Format("No route providing a controller name was found to match request URI '{0}'", new object[] { request.RequestUri })));
            }

            if (this._apiControllerCache.Value.TryGetValue(fullNames.First(), out type))
            {
                return new HttpControllerDescriptor(_configuration, controllerName, type);
            }
            throw new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.NotFound,
                string.Format("No route providing a controller name was found to match request URI '{0}'", new object[] { request.RequestUri })));
        }
    }
}
