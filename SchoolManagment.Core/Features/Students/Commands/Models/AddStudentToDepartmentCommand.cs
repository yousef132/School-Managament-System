using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Students.Commands.Models
{
    public class AddStudentToDepartmentCommand : IRequest<Response<string>>
    {
        public int StudentId { get; set; }
        public int DepartmentId { get; set; }
    }
}
