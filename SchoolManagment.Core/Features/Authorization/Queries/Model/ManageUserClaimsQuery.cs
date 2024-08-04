using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Data.Responses;

namespace SchoolManagment.Core.Features.Authorization.Queries.Model
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResponse>>
    {
        public ManageUserClaimsQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; set; }
    }
}
