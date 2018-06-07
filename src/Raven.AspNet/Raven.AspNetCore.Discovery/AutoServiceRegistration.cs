namespace Raven.AspNetCore.Discovery
{
    public class AutoServiceRegistration : IAutoServiceRegistration
    {
        private IServiceRegistry<IServiceInstance> serviceRegistry;
        private IServiceInstance serviceInstance;

        public AutoServiceRegistration(IServiceRegistry<IServiceInstance> serviceRegistry, IServiceInstance serviceInstance)
        {
            this.serviceRegistry = serviceRegistry;
            this.serviceInstance = serviceInstance;
        }

        public void OnStarted()
        {
            serviceRegistry.Register(serviceInstance);
        }

        public void OnStopping()
        {
            serviceRegistry.Deregister(serviceInstance);
        }
    }
}
