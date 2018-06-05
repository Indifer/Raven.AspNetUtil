using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Rabbit.Extensions.Configuration;
using Raven.AspNetCore.Discovery;
using Raven.AspNetCore.Discovery.Consul;
using Microsoft.AspNetCore.StaticFiles;

namespace Raven.AspNetCore.Consul.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsetting.json")
                .AddJsonFile("consul.json")
                .Build()
                .EnableTemplateSupport();

            var host = new WebHostBuilder()
                .ConfigureLogging(factory => factory.AddConsole())
                .UseKestrel()
                .UseSockets()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(configuration)
                .UseStartup<Startup>()
                .UseConsulMonitor(configuration, (factory) => factory.AddConsul())
                .Build();

            host.Run();
        }
    }


    //public static class AutoWebHostConfiguration
    //{
    //    public static IWebHostBuilder UseConfiguration(this IWebHostBuilder webHostBuilder, IConfiguration configuration)
    //    {
    //        string port = configuration.GetValue<string>("ServicePort");
    //        string host = configuration.GetValue<string>("ServiceHost");

    //        return webHostBuilder.UseUrls(WebHostDefaults.ServerUrlsKey, $"http://{host}:{port}");

    //    }
    //}
}
