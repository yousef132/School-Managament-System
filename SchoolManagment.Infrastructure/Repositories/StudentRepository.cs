using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Infrastructure.Data;
using SchoolManagment.Infrastructure.InfrastructureBases;

namespace SchoolManagment.Infrastructure.Repositories
{
	public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
	{

		#region Fields
		private readonly DbSet<Student> students;

		#endregion

		#region Constructor
		public StudentRepository(ApplicationDbContext context)
			: base(context)
		{
			students = context.Set<Student>();
		}
		#endregion


		#region Functions

		public async Task<List<Student>> GetStudentsAsync()
			=> await students.ToListAsync();
		#endregion
	}
}
