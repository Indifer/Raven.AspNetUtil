using System;
using System.Collections.Generic;
using System.Text;

namespace Raven.AspNetCore.Discovery
{
    public static class Defaults
    {
        public static readonly string ConsuleDiscoveryInstanceIDTemplate = "${ServiceName}-${ServiceHost}:${ServicePort}";
        public static readonly string ConsuleDiscoveryHostTemplate = "${ServiceHost}";
        public static readonly string ConsuleDiscoveryPortTemplate = "${ServicePort}";
    }
}
