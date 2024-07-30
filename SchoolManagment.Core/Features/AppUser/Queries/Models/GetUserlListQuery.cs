using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.AppUser.Queries.Responses;

namespace SchoolManagment.Core.Features.AppUser.Queries.Models
{
    public class GetUserListQuery : IRequest<Response<List<GetUserListResponse>>>
    {
    }
}
