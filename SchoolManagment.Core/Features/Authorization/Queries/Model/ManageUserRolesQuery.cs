using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Data.Responses;

namespace SchoolManagment.Core.Features.Authorization.Queries.Model
{
    public class ManageUserRolesQuery : IRequest<Response<ManageUserRolesResponse>>
    {
        public ManageUserRolesQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; set; }
    }
}
