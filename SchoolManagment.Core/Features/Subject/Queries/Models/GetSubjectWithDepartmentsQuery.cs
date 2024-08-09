using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Subject.Responses;

namespace SchoolManagment.Core.Features.Subject.Queries.Models
{
    public class GetSubjectWithDepartmentsQuery : IRequest<Response<IReadOnlyList<GetSubjectWithDepartments>>>
    {
    }


}
