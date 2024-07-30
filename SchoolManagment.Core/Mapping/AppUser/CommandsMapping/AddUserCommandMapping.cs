using SchoolManagment.Core.Features.AppUser.Commands.Models;
using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Core.Mapping.AppUser
{
    public partial class ApplicationUserProfile
    {
        public void AddUserMapping()
        {

            CreateMap<AddUserCommand, ApplicationUser>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone));

        }
    }
}
