using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Raven.AspNetCore.Discovery
{
    public interface IHealthMiddleware
    {
        Task InvokeAsync(HttpContext context);
    }
}
