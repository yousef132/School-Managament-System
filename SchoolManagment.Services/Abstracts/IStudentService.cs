using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.Specifications.Student;

namespace SchoolManagment.Services.Abstracts
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);

        #region GetWithSpecifications
        Task<List<Student>> GetStudentsWithSpecificationsAsync(StudentSpecification specs);
        Task<Student> GetStudentByIdWithSpecificationsAsync(int id);
        #endregion


        Task<string> AddAsync(Student student);

        Task<bool> IsNameEnExist(string name);
        Task<bool> IsNameArExist(string name);
        Task<bool> IsNameArExistExcludeItself(string name, int id);
        Task<bool> IsNameEnExistExcludeItself(string name, int id);

        Task<string> EditStudentAsync(Student student);
        Task<string> DeleteStudentAsync(Student student);

        Task<string> AddStudentToDepartment(int studentId, int departmentId);


    }
}
