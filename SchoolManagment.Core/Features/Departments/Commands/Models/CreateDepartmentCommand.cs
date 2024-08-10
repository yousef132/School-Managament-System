using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Departments.Commands.Models
{
    public class CreateDepartmentCommand : IRequest<Response<string>>
    {
        public int? InsId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }
}
