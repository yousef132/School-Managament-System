using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Infrastructure.Data;
using SchoolManagment.Infrastructure.InfrastructureBases;

namespace SchoolManagment.Infrastructure.Repositories
{
	public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
	{

		#region Fields
		private readonly DbSet<Instructor> instructors;

		#endregion

		#region Constructor
		public InstructorRepository(ApplicationDbContext context)
			: base(context)
		{
			instructors = context.Set<Instructor>();
		}
		#endregion


		#region Functions

		#endregion
	}
}
