using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Infrastructure.Repositories
{
	public class StudentRepository : IStudentRepository
	{

		#region Fields
		private readonly ApplicationDbContext context;

		#endregion

		#region Constructor
		public StudentRepository(ApplicationDbContext context)
		{
			this.context = context;
		}
		#endregion


		#region Functions
		public async Task<List<Student>> GetStudentsAsync()
			=> await context.Students.ToListAsync();



		#endregion

	}
}
