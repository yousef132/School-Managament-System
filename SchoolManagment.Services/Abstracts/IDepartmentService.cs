using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Entities.Procedures;
using SchoolManagment.Data.Entities.Views;

namespace SchoolManagment.Services.Abstracts
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentById(int id);

        Task<bool> IsDepartmentIdExist(int id);

        Task<List<DepartmentStudentsCount>> GetDepartmentViewData();

        Task<IReadOnlyList<DepartmentTotalStudentsProc>> GetDepartmentTotalStudents(DepartmentTotalStudentsParam param);

        Task<string> DeleteDepartmentAsync(int id);
        Task<string> CreateDepartment(Department department);
        Task<string> EditDepartment(Department department);
        Task<bool> IsInstructorAManager(int instructorId);
        Task<bool> IsInstructorAManagerForOtherDepartment(int instructorId, int departmentId);
        Task<Department?> GetDepartmentByIdWithoutIncludes(int departmentId);
        Task<IReadOnlyList<Department>> GetAllDepartmentsAsync();
    }
}
