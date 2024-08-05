using MediatR;
using SchoolManagment.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagment.Core.Features.Authentication.Queries.Model
{
    public class ResetPasswordQuery : IRequest<Response<string>>
    {
        [Required]

        public string Code { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
