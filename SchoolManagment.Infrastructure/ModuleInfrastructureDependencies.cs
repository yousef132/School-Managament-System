using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Infrastructure.InfrastructureBases;
using SchoolManagment.Infrastructure.Repositories;

namespace SchoolManagment.Infrastructure
{
	public static class ModuleInfrastructureDependencies
	{

		public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
		{
			services.AddScoped<IStudentRepository, StudentRepository>();
			services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
			services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			services.AddScoped<ISubjectRepository, SubjectRepository>();
			services.AddScoped<IStudentRepository, StudentRepository>();
			services.AddScoped<IInstructorRepository, InstructorRepository>();


			return services;
		}

	}
}
