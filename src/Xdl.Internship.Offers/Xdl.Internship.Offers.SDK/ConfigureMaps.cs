using System;
using Microsoft.Extensions.DependencyInjection;

namespace Xdl.Internship.Offers.SDK
{
    public static class ConfigureMaps
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection service)
        {
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
