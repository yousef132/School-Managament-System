using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Infrastructure.Data;
using SchoolManagment.Infrastructure.InfrastructureBases;

namespace SchoolManagment.Infrastructure.Repositories
{
	public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
	{

		#region Fields
		private readonly DbSet<Subject> subjects;

		#endregion

		#region Constructor
		public SubjectRepository(ApplicationDbContext context)
			: base(context)
		{
			subjects = context.Set<Subject>();
		}
		#endregion


		#region Functions

		#endregion
	}
}
