using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Departments.Commands.Models
{
    public class DeleteDepartmentCommand : IRequest<Response<string>>
    {
        public DeleteDepartmentCommand(int id)
        {
            DepartmentId = id;
        }
        public int DepartmentId { get; set; }
    }
}
