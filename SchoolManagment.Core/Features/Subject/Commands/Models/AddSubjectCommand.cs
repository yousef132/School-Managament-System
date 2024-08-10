using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Subject.Commands.Models
{
    public class AddSubjectCommand : IRequest<Response<string>>
    {
        public string SubjectNameAr { get; set; }
        public string SubjectNameEn { get; set; }
        public DateTime Period { get; set; }
    }

}
