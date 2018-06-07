using System;

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
