using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Services.Implementations
{
	public class StudentService : IStudentService
	{

		#region Fields
		private readonly IStudentRepository studentRepository;
		#endregion

		#region Constructor
		public StudentService(IStudentRepository studentRepository)
		{
			this.studentRepository = studentRepository;
		}
		#endregion

		#region Functions
		public async Task<List<Student>> GetStudentsAsync()
		=> await studentRepository.GetStudentsAsync();


		#endregion



	}
}
