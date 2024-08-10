using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Data.Entities.Views;
using SchoolManagment.Data.Helper;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Infrastructure.Abstracts.Functions;
using SchoolManagment.Infrastructure.Abstracts.Procedures;
using SchoolManagment.Infrastructure.Abstracts.Views;
using SchoolManagment.Infrastructure.InfrastructureBases;
using SchoolManagment.Infrastructure.Repositories;
using SchoolManagment.Infrastructure.Repositories.Functions;
using SchoolManagment.Infrastructure.Repositories.Procedures;
using SchoolManagment.Infrastructure.Repositories.Views;

namespace SchoolManagment.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {

        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
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
