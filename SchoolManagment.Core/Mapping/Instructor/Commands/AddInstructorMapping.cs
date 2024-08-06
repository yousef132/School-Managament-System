using SchoolManagment.Core.Features.Instructor.Commands.Models;

namespace SchoolManagment.Core.Mapping.Instructor
{
    public partial class InstructorMapping
    {
        public void AddInstructorMapping()
        {
            CreateMap<AddInstructorCommand, Data.Entities.Instructor>()
                .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DepartmentId));

        }
    }
}
