using System;
using System.Collections.Generic;
using System.Text;

namespace Raven.AspNetCore.Discovery.Consul
{
    /// <summary>
    /// 
    /// </summary>
    public class DiscoveryServiceConfiguration : IDiscoveryServiceConfiguration<ServiceInstance>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ServiceInstance Discovery { get; set; }
    }

    /// <summary>
    /// {"ID":"users-14000","Name":"getUsers","Tags":["ly","secure\u003dfalse"],"Address":"172.31.224.193","Port":14000,"Check":{"Interval":"10s","HTTP":"http://172.31.224.193:14000/actuator/health"}}
    /// </summary>
    public class ServiceInstance : IServiceInstance
    {
        /// <summary>
        /// Instance ID
        /// </summary>
        public string InstanceID { get; set; }

        /// <summary>
        /// Service Name
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan Interval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan Timeout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ServiceInstance()
        {
            Interval = TimeSpan.Parse("00:00:10");
            Interval = TimeSpan.Parse("00:00:5");
        }

    }

}
