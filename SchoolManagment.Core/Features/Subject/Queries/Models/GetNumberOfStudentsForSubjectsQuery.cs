using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Data.Responses;

namespace SchoolManagment.Core.Features.Subject.Queries.Models
{
    public class GetNumberOfStudentsForSubjectsQuery : IRequest<Response<IReadOnlyList<GetNumberOfStudentsForSubjectResponse>>>
    {
    }
}
