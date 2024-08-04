using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Data.Requests;

namespace SchoolManagment.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : UpdateUserRolesRequest, IRequest<Response<string>>
    {

    }
}
