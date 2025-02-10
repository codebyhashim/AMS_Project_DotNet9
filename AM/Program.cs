using System.Reflection;
using AM.ApplicationCore.Interfaces;
using AM.Data;
using AM.Infrastructure;
using AM.Infrastructure.Services;
using AM.Interfaces;
using AM.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace AM
{
    public class Program
    {
       
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
              .WriteTo.Console()
              .Enrich.FromLogContext()
              .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);
           
            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddHttpContextAccessor();

            //builder.Services.AddInfrastructure(builder.Configuration);


            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();
            
            //Register repository pattern
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IEmailService, EmailServie>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));  // For .NET 6+

            //builder.Services.AddScoped<IDoctor, DoctorRepository>();
            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            //builder.Services.AddControllersWithViews();
            // i have add role

            builder.Services.AddControllersWithViews().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
            });
          
           

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication(builder.Configuration);



            Log.Logger = new LoggerConfiguration()
     .WriteTo.MSSqlServer(
         connectionString: "Server=localhost; Database=AM; Integrated Security=True; TrustServerCertificate=True; Trusted_Connection=True; MultipleActiveResultSets=true",
         sinkOptions: new MSSqlServerSinkOptions
         {
             TableName = "LogEvents",
             AutoCreateSqlTable = true   // This ensures that the table will be created automatically
         })
     .Enrich.FromLogContext()
     .CreateLogger();



            // Example of logging
            //Log.Information("This is a test log entry");
            Log.Error("dvcasdfac");
            builder.Host.UseSerilog();
            var app = builder.Build();

          
            app.UseSerilogRequestLogging();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            //app.UseSession();
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}")
                .WithStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();
            app.UseSerilogRequestLogging();


            // create roll
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "Patient", "Doctor" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

            }

            using (var scope = app.Services.CreateScope())
            {
                var UserManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                string email = "admin@gmail.com";
                string password = "#Admin123";


                if (await UserManager.FindByEmailAsync(email) == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = email,
                        Email = email
                    };
                    await UserManager.CreateAsync(user, password);
                    await UserManager.AddToRoleAsync(user, "Admin");

                }

            }
            // Automatically Assign Patient Role to New Users
            // This step ensures new users are added as 'Patient' by default
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var users = userManager.Users.ToList();

                foreach (var user in users)
                {
                    // Assign Patient Role to users that do not already have a role assigned
                    if (!userManager.IsInRoleAsync(user, "Patient").Result)
                    {
                        await userManager.AddToRoleAsync(user, "Patient");
                    }
                }
            }
            app.Run();
        }
    }
}



