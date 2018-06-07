namespace Raven.AspNetCore.Discovery
{
    public interface IAutoServiceRegistration
    {
        void OnStarted();
        void OnStopping();
    }
}
