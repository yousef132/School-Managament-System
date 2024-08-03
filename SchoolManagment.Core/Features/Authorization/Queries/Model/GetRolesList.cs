using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authorization.Queries.Response;

namespace SchoolManagment.Core.Features.Authorization.Queries.Model
{
    public class GetRolesListQuery : IRequest<Response<IReadOnlyList<GetRolesListResponse>>>
    {
    }
}
