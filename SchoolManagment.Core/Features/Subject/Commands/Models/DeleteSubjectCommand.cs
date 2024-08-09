using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Subject.Commands.Models
{
    public class DeleteSubjectCommand : IRequest<Response<string>>
    {
        public DeleteSubjectCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

}
