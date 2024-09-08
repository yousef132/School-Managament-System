using SchoolManagment.Core.Features.Instructor.Queries.Response;

namespace SchoolManagment.Core.Mapping.Instructor
{
    public partial class InstructorMapping
    {
        public void GetInstructorQueryMapping()
        {
            CreateMap<Data.Entities.Instructor, GetInstructorResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
