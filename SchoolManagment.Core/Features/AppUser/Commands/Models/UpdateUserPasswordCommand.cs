using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.AppUser.Commands.Models
{
    public class UpdateUserPasswordCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
