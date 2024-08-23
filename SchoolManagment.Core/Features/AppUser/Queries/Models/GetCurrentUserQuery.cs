using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.AppUser.Queries.Responses;

namespace SchoolManagment.Core.Features.AppUser.Queries.Models
{
    public class GetCurrentUserQuery : IRequest<Response<GetCurrentUserResponse>>
    {
        public GetCurrentUserQuery(string email)
        {
            Email = email;
        }
        public string Email { get; set; }
    }
}
