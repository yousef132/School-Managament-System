using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Data.Requests;

namespace SchoolManagment.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand : EditRoleRequest, IRequest<Response<string>>
    {

    }
}
