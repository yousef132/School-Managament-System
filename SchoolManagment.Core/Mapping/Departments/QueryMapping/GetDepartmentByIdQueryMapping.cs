using SchoolManagment.Core.Features.Departments.Queries.Responses;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdQueryMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor.Localize(src.Instructor.NameAr, src.Instructor.NameEn)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DeptId))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.DepartmentSubjects))// Must  Make Then Include To Subject
                .ForMember(dest => dest.Instructors, opt => opt.MapFrom(src => src.Instructors))
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students));



            CreateMap<Student, StudentResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));



            CreateMap<DepartmentSubject, SubjectResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.Localize(src.Subject.SubjectNameAr, src.Subject.SubjectNameEn)));



            CreateMap<Data.Entities.Instructor, InstructorResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InstId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));




        }
    }
}
