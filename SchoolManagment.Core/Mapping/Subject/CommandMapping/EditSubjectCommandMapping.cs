using SchoolManagment.Core.Features.Subject.Commands.Models;

namespace SchoolManagment.Core.Mapping.Subject
{
    public partial class SubjectProfile
    {

        public void EditSubjectCommandMapping()
        {
            CreateMap<EditSubjectCommand, Data.Entities.Subject>()
                .ForMember(dest => dest.SubId, opt => opt.MapFrom(src => src.SubjectId));
        }
    }
}
