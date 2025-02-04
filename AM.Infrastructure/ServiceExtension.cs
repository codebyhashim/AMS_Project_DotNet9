using AM.ApplicationCore.Interfaces;
using AM.Data;
using AM.Infrastructure.Services;
using AM.Interfaces;
using AM.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
namespace AM.Infrastructure
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection Services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            Services.AddScoped<IDoctorRepository, DoctorRepository>();
            Services.AddScoped<IPatientRepository, PatientRepository>();
            Services.AddScoped<IAdminRepository, AdminRepository>();
            Services.AddScoped<IEmailService, EmailServie>();
            //Services.AddHttpContextAccessor();

            return Services;
        }
    }
}
