using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Xdl.Internship.Authentication.Handlers
{
    public static class Configure
    {
        public static void AddAuthHandlers(this IServiceCollection service)
        {
            var assembly = typeof(Configure).Assembly;
            service.AddMediatR(assembly);
        }
    }
}
