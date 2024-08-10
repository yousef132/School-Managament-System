using AutoMapper;

namespace SchoolManagment.Core.Mapping.Instructor
{
    public partial class InstructorMapping : Profile
    {
        public InstructorMapping()
        {
            AddInstructorMapping();
            GetInstructorQueryMapping();
        }
    }
}
