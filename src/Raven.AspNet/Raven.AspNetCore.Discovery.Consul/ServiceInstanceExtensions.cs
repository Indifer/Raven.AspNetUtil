using Consul;
using System;

namespace Raven.AspNetCore.Discovery.Consul
{
    public static class ServiceInstanceExtensions
    {
        public static AgentServiceRegistration CreateAgentServiceRegistration(this IServiceInstance instance)
        {

            return new AgentServiceRegistration()
            {
                Address = instance.Host,
                ID = instance.InstanceID,
                Name = instance.ServiceName,
                Port = instance.Port,
                Tags = instance.Tags,
                Checks = new[]{ new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                    Interval = instance.Interval,
                    Timeout = instance.Timeout,
                    HTTP = $"http://{instance.Host}:{instance.Port}{Defaults.ConsuleCheckPath}"
                }}

            };
        }
    }
}
