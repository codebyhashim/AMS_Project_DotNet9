using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using AM.Interfaces;
using System.Reflection;

namespace AM.Infrastructure
{
    public static  class ServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddMediatR(config=>config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly() ));
            return Services;
        }
    }
}
