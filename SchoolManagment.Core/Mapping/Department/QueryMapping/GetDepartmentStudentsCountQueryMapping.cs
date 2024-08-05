using SchoolManagment.Core.Features.Departments.Queries.Responses;
using SchoolManagment.Data.Entities.Views;

namespace SchoolManagment.Core.Mapping.Department
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentStudentsCountQueryMapping()
        {
            CreateMap<DepartmentView, GetDepartmentStudentCountResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.DepartmentNameAr, src.DepartmentNameEn)))
              .ForMember(dest => dest.NumberOfStudents, opt => opt.MapFrom(src => src.Students));
        }
    }
}
