using SchoolManagment.Data.Entities;

namespace SchoolManagment.Services.Abstracts
{
    public interface ISubjectService
    {
        Task<bool> AddSubject(Subject subject);
        Task<bool> IsSubjectExist(int id);
        Task<Subject?> GetSubjectById(int id);

        Task<bool> DeleteSubject(Subject subject);
        Task<bool> EditSubject(Subject subject);

        Task<bool> AddSubjectToDepartment(int subjectId, int departmentId);
        Task<bool> AddInstructorToSubject(int subjectId, int instructorId);

    }
}
