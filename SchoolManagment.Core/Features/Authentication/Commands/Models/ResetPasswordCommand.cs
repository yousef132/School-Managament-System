using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Authentication.Commands.Models
{
    public class ResetPasswordCommand : IRequest<Response<string>>
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }

    }
}
