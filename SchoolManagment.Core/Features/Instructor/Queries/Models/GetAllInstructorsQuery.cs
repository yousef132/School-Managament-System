using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Instructor.Queries.Response;

namespace SchoolManagment.Core.Features.Instructor.Queries.Models
{
    public class GetAllInstructorsQuery : IRequest<Response<IReadOnlyList<GetInstructorResponse>>>
    {
    }
}
