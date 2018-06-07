namespace Raven.AspNetCore.Discovery
{
    public interface IDiscoveryServiceConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Token { get; set; }
    }

    public interface IDiscoveryServiceConfiguration<T> : IDiscoveryServiceConfiguration
        where T : IServiceInstance
    {

        /// <summary>
        /// 
        /// </summary>
        T Discovery { get; set; }
    }
}
