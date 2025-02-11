using System.Reflection;
//using AM.ApplicationCore.Behaviour;
using Azure.Core;
using Azure;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using AM.Models;

namespace AM.Infrastructure
{
    public static class ServiceExtension
    {
        public static object AddApplication(this IServiceCollection Services, IConfiguration configuration)
        {
            // register mediatr
            Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // register fluent validation
            //Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
           
                return Services;
        }
    }
}
//Services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehaviour<,>));
//Services.AddScoped<IValidator<DoctorModel>, createDoctorRequestValidator>();
//Services.AddFluentValidationAutoValidation();

//Services.AddValidatorsFromAssemblyContaining<createDoctorRequestValidator>;