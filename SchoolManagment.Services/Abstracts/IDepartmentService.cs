using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Entities.Procedures;
using SchoolManagment.Data.Entities.Views;

namespace SchoolManagment.Services.Abstracts
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentById(int id);

        Task<bool> IsDepartmentIdExist(int id);

        Task<List<DepartmentView>> GetDepartmentViewData();

        Task<IReadOnlyList<DepartmentTotalStudentsProc>> GetDepartmentTotalStudents(DepartmentTotalStudentsParam param);

    }
}
