using SchoolManagment.Core.Features.Departments.Queries.Responses;
using SchoolManagment.Data.Entities.Procedures;
using SchoolManagment.Data.Entities.Views;

namespace SchoolManagment.Core.Mapping.Department
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentStudentsCountQueryMapping()
        {
            CreateMap<DepartmentView, GetDepartmentStudentCountListResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.DepartmentNameAr, src.DepartmentNameEn)))
              .ForMember(dest => dest.NumberOfStudents, opt => opt.MapFrom(src => src.Students));

            CreateMap<DepartmentTotalStudentsProc, GetDepartmentStudentCountListResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.DepartmentNameAr, src.DepartmentNameEn)))
              .ForMember(dest => dest.NumberOfStudents, opt => opt.MapFrom(src => src.StudentsCount));



        }
    }
}
