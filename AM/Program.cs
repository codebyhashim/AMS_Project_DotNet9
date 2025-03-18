using System.Reflection;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Validator;
using AM.Data;
using AM.Infrastructure;
using AM.Infrastructure.Services;
using AM.Interfaces;
using AM.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using BundlerMinifier;

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
            builder.Services.AddAuthentication()
.AddGoogle(options =>
{
options.ClientId = "213390042590-2avfghd2bpckfff3a49itpu0unfim5il.apps.googleusercontent.com";
    options.ClientSecret = "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";
});
            builder.Services.AddValidatorsFromAssemblyContaining<DoctorValidator>();
            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAuthenticated", policy => policy.RequireAuthenticatedUser());
            });



            //builder.Services.AddInfrastructure(builder.Configuration);

            //builder.Services.AddFluentValidationAutoValidation()
            //    .AddFluentValidationClientsideAdapters()
            //    .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            builder.Services.AddControllersWithViews();
            
        //    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        //.AddEntityFrameworkStores<ApplicationDbContext>();

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

            //builder.Services.AddControllersWithViews().AddRazorPagesOptions(options =>
            //{
            //    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
                

            //});
          
           
            // add extension method
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication(builder.Configuration);
            builder.Services.AddFluentValidationClientsideAdapters();
            //Registere validator
            builder.Services.AddValidatorsFromAssemblyContaining<DoctorValidator>();
            //builder.Services.AddValidatorsFromAssemblyContaining<PatientRepository>();
            //builder.Services.AddValidatorsFromAssemblyContaining<BookAppointmentValidator>();
            //builder.Services.AddValidatorsFromAssemblyContaining<UpdateDoctorValidator>();

           
            //Creating log table in sqldatabase
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

            //Creating log file in project

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("LogFiles/log-.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}", rollingInterval: RollingInterval.Day)
            .CreateLogger();



            // Example of logging
            //Log.Information("This is a test log entry");
            Log.Error("dvcasdfac");
            builder.Host.UseSerilog();
            var app = builder.Build();

            if (app.Environment.IsProduction())
            {
                // Enable BundlingMinifier only in production
               // app.UseBundlingMinifier();
            }

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

            //            builder.Services.AddAuthentication()
            //.AddGoogle(options =>
            //{
            //    options.ClientId = "[Your Google Client ID]";
            //    options.ClientSecret = "[Your Google Client Secret]";
            //    // Configure Other Options 
            //});





       

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication(); // Enable Authentication
            app.UseAuthorization();
            //app.UseSession();
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                //pattern: "{controller=Account}/{action=Login}/{id?}")
                pattern: "{controller=Home}/{action=Index}/{id?}")

                .WithStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();
            app.UseSerilogRequestLogging();
           

            //using Identity for rols
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



