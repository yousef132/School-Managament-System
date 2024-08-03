using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Authorization.Commands.Models
{
    public class AddRoleCommand : IRequest<Response<string>>
    {
        public AddRoleCommand(string role)
        {
            Role = role;
        }
        public string Role { get; set; }
    }
}
