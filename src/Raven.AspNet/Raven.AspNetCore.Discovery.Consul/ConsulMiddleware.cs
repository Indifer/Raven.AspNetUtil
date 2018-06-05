using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Raven.AspNetCore.Discovery.Consul
{
    public class ConsulMiddleware : IHealthMiddleware
    {
        RequestDelegate next;

        public ConsulMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task InvokeAsync(HttpContext context )
        {
            if (context.Request.Path.StartsWithSegments(Defaults.ConsuleCheckPath))
            {
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync("{\"status\":\"UP\"}");
            }
            return next(context);
        }
    }
}
