using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Core.Bahaviors;
using SchoolManagment.Core.Filters;
using System.Reflection;

namespace SchoolManagment.Data
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {

            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Mediator Config.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<AuthAttribute>();

            //validators 
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
