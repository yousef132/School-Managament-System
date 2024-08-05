using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Email.Commands.Models
{
    public class SendEmailCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Message { get; set; }

    }
}
