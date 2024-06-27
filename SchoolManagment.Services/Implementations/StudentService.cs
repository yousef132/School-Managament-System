using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Infrastructure.Specifications.Student;
using SchoolManagment.Services.Abstracts;

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


			await studentRepository.AddAsync(student);
			try
			{
				await studentRepository.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception("Department Id Not Valid");
			}

			return "Success";
		}

		public async Task<bool> IsNameExist(string name)
		{
			// check if name exist or not 
			bool exist = studentRepository.GetTableAsNotTracked().Any(s => s.Name == name);
			return exist ? true : false;
		}

		public async Task<bool> IsNameExistExcludeItself(string name, int id)
		{
			bool exist = studentRepository
						 .GetTableAsNotTracked()
						 .Any(s => s.Name == name && !s.StudId.Equals(id));
			return exist ? true : false;


		}

		public async Task<string> EditStudentAsync(Student student)
		{
			await studentRepository.UpdateAsync(student);

			return "Success";
		}

		public async Task<string> DeleteStudentAsync(Student student)
		{
			await studentRepository.DeleteAsync(student);
			return "Success";
		}

		public async Task<List<Student>> GetStudentsWithSpecificationsAsync(StudentSpecification inputSpecs)
		{
			var specs = new StudentsWithSpecifications(inputSpecs);
			var result = await studentRepository.GetAllWithSpecification(specs);
			return result;
		}

		public async Task<Student> GetStudentByIdWithSpecificationsAsync(int id)
		{
			var specs = new StudentsWithSpecifications(id);
			var students = await studentRepository.GetByIdWithSpecification(specs);
			return students;
		}
		#endregion



	}
}
