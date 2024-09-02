using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Instructor.Commands.Models
{
    public class DeleteInstructorCommand : IRequest<Response<string>>
    {
        public DeleteInstructorCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
