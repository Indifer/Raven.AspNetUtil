namespace Raven.AspNetCore.Discovery
{
    public interface IServiceRegistry<T> where T : IServiceInstance
    {
        void Register(T serviceInstance);

        void Deregister(T serviceInstance);

    }
}
