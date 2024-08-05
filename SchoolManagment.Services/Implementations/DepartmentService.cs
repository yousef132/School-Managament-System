using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Entities.Views;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Infrastructure.Abstracts.Views;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IViewRepository<DepartmentView> viewRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, IViewRepository<DepartmentView> viewRepository)
        {
            this.departmentRepository = departmentRepository;
            this.viewRepository = viewRepository;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            // If i used specification pattern the department.DepartmentSubject.Subject Will Not Be Included
            // Because I have to make thenInclude on the 'DepartmentSubject' to include the 'Subject'

            //var specs = new DepartmentWithSpecifications(id);
            //var department = await departmentRepository.GetByIdWithSpecification(specs);

            var department = await departmentRepository
                                .GetTableAsNotTracked()
                                .Where(d => d.DeptId == id)
                                .Include(d => d.Instructor)
                                .Include(d => d.Instructors)
                                .Include(d => d.Students)
                                .Include(d => d.DepartmentSubjects)
                                .ThenInclude(ds => ds.Subject)
                                .FirstOrDefaultAsync();
            return department ?? new Department();
        }

        public async Task<List<DepartmentView>> GetDepartmentViewData()
            => await viewRepository.GetTableAsNotTracked().ToListAsync();

        public async Task<bool> IsDepartmentIdExist(int id)
        {
            bool exist = await departmentRepository.GetTableAsNotTracked().AnyAsync(d => d.DeptId == id);

            return exist;
        }
    }
}
