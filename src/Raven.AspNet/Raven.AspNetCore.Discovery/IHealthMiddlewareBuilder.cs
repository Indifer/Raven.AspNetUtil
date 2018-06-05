using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raven.AspNetCore.Discovery
{
    public interface IHealthMiddlewareBuilder
    {

        Type HealthMiddlewareType { get; }
    }

    public class HealthMiddlewareBuilder : IHealthMiddlewareBuilder
    {
        public HealthMiddlewareBuilder(Type healthMiddlewareType)
        {
            HealthMiddlewareType = healthMiddlewareType;
        }

        public Type HealthMiddlewareType { get; }

    }

}
