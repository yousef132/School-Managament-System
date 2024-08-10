using SchoolManagment.Core.Features.Subject.Commands.Models;

namespace SchoolManagment.Core.Mapping.Subject
{
    public partial class SubjectProfile
    {
        public void AddSubjectCommandMapping()
        {
            CreateMap<AddSubjectCommand, Data.Entities.Subject>();

        }
    }
}
