using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Data.Helper;

namespace SchoolManagment.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthModel>>
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}
