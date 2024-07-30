using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.AppUser.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

    }
}
