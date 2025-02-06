using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Infrastructure
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return Services;
        }
    }
}
