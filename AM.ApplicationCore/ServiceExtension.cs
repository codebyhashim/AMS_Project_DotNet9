using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using AM.Interfaces;

namespace AM.Infrastructure
{
    public static  class ServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection Services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            //Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            //Services.AddScoped<IDoctorRepository, DoctorRepository>();
            //Services.AddScoped<IPatientRepository, PatientRepository>();
            //Services.AddScoped<IAdminRepository, AdminRepository>();
            return Services;
        }
    }
}
