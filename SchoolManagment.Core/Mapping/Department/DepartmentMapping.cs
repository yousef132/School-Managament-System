using AutoMapper;

namespace SchoolManagment.Core.Mapping.Department
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentByIdQueryMapping();
            GetDepartmentStudentsCountQueryMapping();

        }
    }
}
