using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Instructor.Queries.Response;

namespace SchoolManagment.Core.Features.Instructor.Queries.Models
{
    public class GetInstructorByIdQuery : IRequest<Response<GetInstructorResponse>>
    {
        public GetInstructorByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
