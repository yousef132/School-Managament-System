using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Data.Entities.Views;
using SchoolManagment.Data.Helper;
using SchoolManagment.Infrastructure.Abstracts.Functions;
using SchoolManagment.Infrastructure.Abstracts.Procedures;
using SchoolManagment.Infrastructure.Abstracts.Views;
using SchoolManagment.Infrastructure.InfrastructureBases;
using SchoolManagment.Infrastructure.Repositories.Functions;
using SchoolManagment.Infrastructure.Repositories.Procedures;
using SchoolManagment.Infrastructure.Repositories.Views;

namespace SchoolManagment.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {

        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.Configure<JWT>(configuration.GetSection("JWT"));
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            #region Views
            services.AddScoped<IViewRepository<DepartmentStudentsCount>, DepartmentViewRepository>();
            #endregion

            #region Procedures
            services.AddScoped<IDepartmentTotalStudentsRepository, DepartmentTotalStudentsRepository>();

            #endregion

            #region Functions
            services.AddScoped<IDepartmentGetTop3SalariesRepository, DepartmentGetTop3SalariesRepository>();

            #endregion

            return services;
        }

    }

}
