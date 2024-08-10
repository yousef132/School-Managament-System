using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Departments.Queries.Responses;

namespace SchoolManagment.Core.Features.Departments.Queries.Models
{
    public class GetAllDepartmentsQuery : IRequest<Response<IReadOnlyList<GetAllDepartmentsResponse>>>

    {

    }
}
