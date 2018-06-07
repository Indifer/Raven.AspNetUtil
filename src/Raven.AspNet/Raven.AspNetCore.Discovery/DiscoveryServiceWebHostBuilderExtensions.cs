using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Raven.AspNetCore.Discovery.Consul
{
    public static class DiscoveryServiceWebHostBuilderExtensions
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="hostBuilder"></param>
        ///// <param name="options"></param>
        ///// <returns></returns>
        //public static IWebHostBuilder UseConsulMonitor(this IWebHostBuilder hostBuilder, Action<IDiscoveryServiceConfiguration> options)
        //{
        //    var consulConfiguration = new DiscoveryServiceConfiguration<ServiceInstance>() as IDiscoveryServiceConfiguration;
        //    options.Invoke(consulConfiguration);

        //    return hostBuilder.ConfigureServices(configureServices => configureServices.TryAddSingleton(consulConfiguration));
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <param name="configurationFile"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseConsulMonitor(this IWebHostBuilder hostBuilder, IConfiguration configuration, Action<IDiscoveryServiceBuilder> configure)
        {
            var consulConfiguration = configuration.Get<DiscoveryServiceConfiguration>();

            return hostBuilder.ConfigureServices(configureServices =>
            {
                configureServices.TryAddSingleton<IDiscoveryServiceConfiguration>(consulConfiguration);
                configureServices.TryAddSingleton<IServiceInstance>(consulConfiguration.Discovery);
                configureServices.TryAddSingleton<IAutoServiceRegistration, AutoServiceRegistration>();
                
                configure((IDiscoveryServiceBuilder)new DiscoveryServiceBuilder(configureServices));

            });
        }

    }
}
