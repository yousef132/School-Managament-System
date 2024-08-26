using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagment.Core.Bases;
using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Core.Features.AppUser.Commands.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Address? Address { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? Phone { get; set; }
        public IFormFile? Image { get; set; }
    }
}
