using Microsoft.Extensions.DependencyInjection;

namespace Raven.AspNetCore.Discovery.Consul
{
    public static class ConsulServiceCollectionExtensions
    {
        public static IDiscoveryServiceBuilder AddConsul(this IDiscoveryServiceBuilder builder)
        {
            //services.AddSingleton<IServiceRegistry<IServiceInstance>>(
            //    new ConsulServiceRegistry(serviceProvider.GetService<ILoggerFactory>().CreateLogger<ConsulServiceRegistry>()
            //    , (IDiscoveryServiceConfiguration)services.Single(x => 
            //                                                    typeof(IDiscoveryServiceConfiguration).IsAssignableFrom(x.ServiceType)).ImplementationInstance)
            //    );
            builder.Services.AddSingleton<IServiceRegistry<IServiceInstance>, ConsulServiceRegistry>();
            builder.Services.AddSingleton<IHealthMiddlewareBuilder>(new HealthMiddlewareBuilder(typeof(ConsulMiddleware)));

            return builder;
        }
    }
}
