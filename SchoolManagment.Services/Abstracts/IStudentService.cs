using SchoolManagment.Data.Entities;

namespace SchoolManagment.Services.Abstracts
{
	public interface IStudentService
	{
		public Task<List<Student>> GetStudentsAsync();
		public Task<Student> GetStudentByIdAsync(int id);

		public Task<string> AddAsync(Student student);

		public Task<bool> IsNameExist(string name);
		public Task<bool> IsNameExistExcludeItself(string name, int id);

		public Task<string> EditStudentAsync(Student student);
		public Task<string> DeleteStudentAsync(Student student);
	}
}
