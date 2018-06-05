using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raven.AspNetCore.Discovery
{
    public interface IDiscoveryServiceBuilder
    {
        IServiceCollection Services { get; }
    }

    internal class DiscoveryServiceBuilder : IDiscoveryServiceBuilder
    {
        public DiscoveryServiceBuilder(IServiceCollection services)
        {
            this.Services = services;
        }

        public IServiceCollection Services { get; }

    }

}
