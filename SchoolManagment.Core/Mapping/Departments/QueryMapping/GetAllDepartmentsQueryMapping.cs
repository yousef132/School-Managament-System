using SchoolManagment.Core.Features.Departments.Queries.Responses;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {

        public void GetAllDepartmentsMapping()
        {
            CreateMap<Department, GetAllDepartmentsResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
                .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.InsId));
        }
    }
}
