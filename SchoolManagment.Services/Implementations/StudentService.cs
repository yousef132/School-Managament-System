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
		public async Task<Student> GetStudentByIdAsync(int id)
		{
			var student = studentRepository.GetTableAsNotTracked()
				.FirstOrDefault(s => s.StudId == id);

			return student;	

		}

		public async Task<string> AddAsync(Student student)
		{
			// check if name exist or not 
			bool exist = studentRepository.GetTableAsNotTracked().Any(s => s.Name == student.Name);
			if(exist)
			{
				return "Exist";
			}
			await studentRepository.AddAsync(student);
			await studentRepository.SaveChangesAsync();
			return "Success";
		}

		#endregion



	}
}
