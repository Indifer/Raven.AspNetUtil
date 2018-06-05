using Consul;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raven.AspNetCore.Discovery.Consul
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsulServiceRegistry : IServiceRegistry<IServiceInstance>
    {
        private readonly ILogger<ConsulServiceRegistry> _logger;
        private readonly ConsulClient _consul;
        private readonly IDiscoveryServiceConfiguration _consulOptions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consul"></param>
        /// <param name="logger"></param>
        /// <param name="consulOptions"></param>
        public ConsulServiceRegistry(ILogger<ConsulServiceRegistry> logger, IDiscoveryServiceConfiguration consulOptions)
        {
            _logger = logger;
            _consulOptions = consulOptions;
            _consul = new ConsulClient(config => 
            {
                config.Address = new Uri(_consulOptions.Address);
                if (!string.IsNullOrEmpty(_consulOptions.Token))
                {
                    config.Token = _consulOptions.Token;
                }
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceInstance"></param>
        public void Deregister(IServiceInstance serviceInstance)
        {
            try
            {
                var res = _consul.Agent.ServiceDeregister(serviceInstance.InstanceID).GetAwaiter().GetResult();

                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    _logger.LogError($"Error deregistering service with consul: {serviceInstance.ServiceName} | {serviceInstance.InstanceID}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deregistering service with consul: {serviceInstance.ServiceName} | {serviceInstance.InstanceID}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceInstance"></param>
        public void Register(IServiceInstance serviceInstance)
        {
            _logger.LogInformation($"Registering service with consul: {serviceInstance.ServiceName} | {serviceInstance.InstanceID}");
            var service = serviceInstance.CreateAgentServiceRegistration();
            try
            {
                var res = _consul.Agent.ServiceRegister(service).GetAwaiter().GetResult();

                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    _logger.LogError($"Error registering service with consul: {serviceInstance.ServiceName} | {serviceInstance.InstanceID}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error registering service with consul: {serviceInstance.ServiceName} | {serviceInstance.InstanceID}");
            }
            
        }
    }
}
