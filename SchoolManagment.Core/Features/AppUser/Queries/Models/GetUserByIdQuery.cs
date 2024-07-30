using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.AppUser.Queries.Responses;

namespace SchoolManagment.Core.Features.AppUser.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
