using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Departments.Queries.Responses;

namespace SchoolManagment.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentStudentCountQuery : IRequest<Response<List<GetDepartmentStudentCountResponse>>>
    {
    }
}
