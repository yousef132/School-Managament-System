using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Subject.Responses;

namespace SchoolManagment.Core.Features.Subject.Queries.Models
{
    public class GetSubjectByIdQuery : IRequest<Response<GetSubjectByIdResponse>>
    {
        public int Id { get; set; }
        public GetSubjectByIdQuery(int id)
        {
            this.Id = id;
        }

    }
}
