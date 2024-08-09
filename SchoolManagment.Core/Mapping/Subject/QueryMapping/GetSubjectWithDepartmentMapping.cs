using AutoMapper;
using SchoolManagment.Core.Features.Subject.Responses;
using SchoolManagment.Data.Entities;
using static SchoolManagment.Core.Features.Subject.Responses.GetSubjectWithDepartments;

namespace SchoolManagment.Core.Mapping.Subject
{
    public partial class SubjectProfile : Profile
    {
        public void GetSubjectWithDepartmentMapping()
        {
            CreateMap<Data.Entities.Subject, GetSubjectWithDepartments>()
                  .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubId))
                  .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Localize(src.SubjectNameAr, src.SubjectNameEn)))
                  .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.DepartmentSubjects));



            CreateMap<DepartmentSubject, SubjectWithDepartment>()
                  .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Department.DeptId))
             .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Localize(src.Department.NameAr, src.Department.NameEn)));

        }

    }
}
