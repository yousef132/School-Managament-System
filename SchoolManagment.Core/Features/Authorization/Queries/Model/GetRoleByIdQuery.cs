using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authorization.Queries.Response;

namespace SchoolManagment.Core.Features.Authorization.Queries.Model
{
    public class GetRoleByIdQuery : IRequest<Response<GetRolesListResponse>>
    {
        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
