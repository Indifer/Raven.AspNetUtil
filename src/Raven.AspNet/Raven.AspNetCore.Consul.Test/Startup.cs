using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Raven.AspNetCore.Discovery;
using Raven.AspNetCore.Discovery.Consul;

namespace Raven.AspNetCore.Consul.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddConsul();
            ;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            app.UseConsulMonitor(env, lifetime);

            app.Run(context =>
            {
                return context.Response.WriteAsync("Hello from ASP.NET Core!");
            });

        }

    }


}
