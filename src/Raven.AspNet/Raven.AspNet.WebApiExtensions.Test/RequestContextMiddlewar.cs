using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Raven.AspNet.WebApiExtensions.Test
{
    using AppFunc = Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

    public class RequestContextMiddlewar
    {
        readonly AppFunc next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public RequestContextMiddlewar(AppFunc next)
        {
            this.next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        public async Task Invoke(IDictionary<string, object> environment)
        {
            environment.Add(new KeyValuePair<string, object>("test", "1111"));
            try
            {
                await next(environment);
            }
            finally
            {
            }
        }
    }

    class Handler1 : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}