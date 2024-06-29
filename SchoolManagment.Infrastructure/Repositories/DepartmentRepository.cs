using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Infrastructure.Data;
using SchoolManagment.Infrastructure.InfrastructureBases;

namespace SchoolManagment.Infrastructure.Repositories
{
	public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
	{


		#region Fields & Properties
		private readonly DbSet<Department> departments;

		#endregion



		#region Constructor
		public DepartmentRepository(ApplicationDbContext context) :
			base(context)
		{
			departments = context.Set<Department>();
		}
		#endregion



		#region Functions

		#endregion


	}
}
