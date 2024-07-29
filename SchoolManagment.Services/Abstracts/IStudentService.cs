using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.Specifications.Student;

namespace SchoolManagment.Services.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);

        #region GetWithSpecifications
        public Task<List<Student>> GetStudentsWithSpecificationsAsync(StudentSpecification specs);
        public Task<Student> GetStudentByIdWithSpecificationsAsync(int id);
        #endregion


        public Task<string> AddAsync(Student student);

        public Task<bool> IsNameEnExist(string name);
        public Task<bool> IsNameArExist(string name);
        public Task<bool> IsNameExistExcludeItself(string name, int id);

        public Task<string> EditStudentAsync(Student student);
        public Task<string> DeleteStudentAsync(Student student);
    }
}
