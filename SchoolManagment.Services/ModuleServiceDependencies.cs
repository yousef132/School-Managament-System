using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Services.Abstracts;
using SchoolManagment.Services.Implementations;

namespace SchoolManagment.Services
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();


            return services;
        }
    }
}
