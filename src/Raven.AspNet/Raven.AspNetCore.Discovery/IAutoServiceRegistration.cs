using System;
using System.Collections.Generic;
using System.Text;

namespace Raven.AspNetCore.Discovery
{
    public interface IAutoServiceRegistration
    {
        void OnStarted();
        void OnStopping();
    }
}
