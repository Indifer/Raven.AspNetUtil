using System;
using System.Collections.Generic;
using System.Text;

namespace Raven.AspNetCore.Discovery
{
    public interface IServiceInstance
    {
        /// <summary>
        /// Instance ID
        /// </summary>
        string InstanceID { get; }

        /// <summary>
        /// Service Name
        /// </summary>
        string ServiceName { get; }

        /// <summary>
        /// 
        /// </summary>
        string[] Tags { get; }

        /// <summary>
        /// 
        /// </summary>
        string Host { get; }

        /// <summary>
        /// 
        /// </summary>
        int Port { get; }

        /// <summary>
        /// 
        /// </summary>
        TimeSpan Interval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        TimeSpan Timeout { get; set; }
    }



}
