using SchoolManagment.Core.Features.Instructor.Queries.Response;

namespace SchoolManagment.Core.Mapping.Instructor
{
    public partial class InstructorMapping
    {
        public void GetInstructorQueryMapping()
        {
            CreateMap<Data.Entities.Instructor, GetInstructorResponse>();
        }
    }
}
