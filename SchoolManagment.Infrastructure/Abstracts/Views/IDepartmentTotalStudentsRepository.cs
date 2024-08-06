using SchoolManagment.Data.Entities.Procedures;

namespace SchoolManagment.Infrastructure.Abstracts.Views
{
    public interface IDepartmentTotalStudentsRepository
    {
        Task<IReadOnlyList<DepartmentTotalStudentsProc>> GetDepartmentTotalStudents(DepartmentTotalStudentsParam param);
    }
}
