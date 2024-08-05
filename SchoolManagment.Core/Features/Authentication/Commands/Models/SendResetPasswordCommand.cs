using MediatR;
using SchoolManagment.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagment.Core.Features.Authentication.Commands.Models
{
    public class SendResetPasswordCommand : IRequest<Response<string>>
    {
        [Required]
        public string Email { get; set; }
    }
}
