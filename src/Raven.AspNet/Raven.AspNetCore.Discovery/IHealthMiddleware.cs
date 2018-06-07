using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Raven.AspNetCore.Discovery
{
    public interface IHealthMiddleware
    {
        Task InvokeAsync(HttpContext context);
    }
}
