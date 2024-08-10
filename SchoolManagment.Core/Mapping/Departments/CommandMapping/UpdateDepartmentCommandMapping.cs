using SchoolManagment.Core.Features.Departments.Commands.Models;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void UpdateDepartmentCommandMapping()
        {
            CreateMap<UpdateDepartmentCommand, Department>()
                .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DepartmentId));
        }
    }
}
