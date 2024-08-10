using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Departments.Queries.Responses;

namespace SchoolManagment.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public GetDepartmentByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id;
    }
}
