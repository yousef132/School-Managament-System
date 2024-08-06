using SchoolManagment.Data.Entities.Procedures;

namespace SchoolManagment.Infrastructure.Abstracts.Procedures
{
    public interface IDepartmentTotalStudentsRepository
    {
        Task<IReadOnlyList<DepartmentTotalStudentsProc>> GetDepartmentTotalStudents(DepartmentTotalStudentsParam param);
    }
}
