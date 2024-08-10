using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Subject.Commands.Models
{
    public class AddInstructorToSubjectCommand : IRequest<Response<string>>
    {
        public int InstructorId { get; set; }
        public int SubjectId { get; set; }
    }

}
