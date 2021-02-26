using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Xdl.Internship.Offers.Handlers
{
    public static class Configure
    {
        public static void AddMediatRHandlers(this IServiceCollection service)
        {
            service.AddMediatR(typeof(Configure).Assembly);
        }
    }
}
