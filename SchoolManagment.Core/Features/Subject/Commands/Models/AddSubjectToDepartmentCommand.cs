using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Subject.Commands.Models
{
    public class AddSubjectToDepartmentCommand : IRequest<Response<string>>
    {
        public int DepartmentId { get; set; }
        public int SubjectId { get; set; }
    }

}
