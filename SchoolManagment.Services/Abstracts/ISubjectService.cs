using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Responses;

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

        Task<IReadOnlyList<Subject>> GetAllSubjectsIncludingDepartments();
        Task<IReadOnlyList<GetNumberOfStudentsForSubjectResponse>> GetNumberOfStudentsForSubjects();
        Task<IReadOnlyList<GetTopStudentInEachSubjectResponse>> GetTopStudentInEachSubject();
    }
}
