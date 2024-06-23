using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Infrastructure
{
	public static class ModuleInfrastructureDependencies
	{

		public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
		{
			services.AddScoped<IStudentRepository, StudentRepository>();


			return services;
		}

	}
}
