using Microsoft.Extensions.DependencyInjection;
using SchoolManagment.Services.Abstracts;
using SchoolManagment.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Services
{
	public static class ModuleServiceDependencies
	{
		public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
		{
			services.AddScoped<IStudentService, StudentService>();
			return services;
		}
	}
}
