using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Entities.Procedures;
using SchoolManagment.Data.Entities.Views;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Infrastructure.Abstracts.Procedures;
using SchoolManagment.Infrastructure.Abstracts.Views;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IViewRepository<DepartmentStudentsCount> viewRepository;
        private readonly IDepartmentTotalStudentsRepository departmentTotalStudentsRepository;

        public DepartmentService(IDepartmentRepository departmentRepository,
                                 IViewRepository<DepartmentStudentsCount> viewRepository,
                                 IDepartmentTotalStudentsRepository departmentTotalStudentsRepository)
        {
            this.departmentRepository = departmentRepository;
            this.viewRepository = viewRepository;
            this.departmentTotalStudentsRepository = departmentTotalStudentsRepository;
        }

        public async Task<string> CreateDepartment(Department department)
        {
            try
            {
                await departmentRepository.AddAsync(department);
                return "Success";

            }
            catch (Exception ex)
            {
                return "Failed";
                throw;
            }
        }

        public async Task<string> DeleteDepartmentAsync(int id)
        {
            try
            {
                var department = await departmentRepository.GetByIdAsync(id);
                if (department == null)
                    return "DepartmentNotFound";
                await departmentRepository.DeleteAsync(department);
                return "Success";
            }
            catch (Exception)
            {
                return "Failed";
                throw;
            }
        }

        public async Task<string> EditDepartment(Department department)
        {
            try
            {

                await departmentRepository.UpdateAsync(department);

                return "Success";
            }
            catch (Exception)
            {
                return "Failed";
                throw;
            }

        }

        public async Task<IReadOnlyList<Department>> GetAllDepartmentsAsync()
            => await departmentRepository.GetTableAsNotTracked().ToListAsync();

        // If i used specification pattern the department.DepartmentSubject.Subject Will Not Be Included
        // Because I have to make thenInclude on the 'DepartmentSubject' to include the 'Subject'
        public async Task<Department> GetDepartmentById(int id)
            => await departmentRepository
                                .GetTableAsNotTracked()
                                .Where(d => d.DeptId == id)
                                .Include(d => d.Instructor)
                                .Include(d => d.Instructors)
                                .Include(d => d.Students)
                                .Include(d => d.DepartmentSubjects)
                                .ThenInclude(ds => ds.Subject)
                                .FirstOrDefaultAsync() ?? new Department();

        public async Task<Department?> GetDepartmentByIdWithoutIncludes(int departmentId)
            => await departmentRepository.GetTableAsNotTracked().FirstOrDefaultAsync(d => d.DeptId == departmentId);


        public async Task<IReadOnlyList<DepartmentTotalStudentsProc>> GetDepartmentTotalStudents(DepartmentTotalStudentsParam param)
            => await departmentTotalStudentsRepository.GetDepartmentTotalStudents(param);

        public async Task<List<DepartmentStudentsCount>> GetDepartmentViewData()
            => await viewRepository.GetTableAsNotTracked().ToListAsync();

        public async Task<bool> IsDepartmentIdExist(int id)
             => await departmentRepository.GetTableAsNotTracked().AnyAsync(d => d.DeptId == id);

        public async Task<bool> IsInstructorAManager(int instructorId)
             => await departmentRepository.GetTableAsNotTracked().AnyAsync(d => d.InsId == instructorId);

        public async Task<bool> IsInstructorAManagerForOtherDepartment(int instructorId, int departmentId)
             => await departmentRepository.GetTableAsNotTracked().AnyAsync(d => d.InsId == instructorId && d.DeptId != departmentId);


    }
}
