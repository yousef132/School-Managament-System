using AutoMapper;

namespace SchoolManagment.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentByIdQueryMapping();
            GetDepartmentStudentsCountQueryMapping();
            CreateDepartmentCommandMapping();
            GetTop3InstructorSalariesByDeptQueryMapping();
            UpdateDepartmentCommandMapping();
            GetAllDepartmentsMapping();
        }
    }
}
