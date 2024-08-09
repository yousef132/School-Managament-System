using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Subject.Commands.Models
{
    public class EditSubjectCommand : IRequest<Response<string>>
    {
        public int SubjectId { get; set; }
        public string SubjectNameAr { get; set; }
        public string SubjectNameEn { get; set; }
        public DateTime Period { get; set; }
    }

}
