using SchoolManagment.Core.Features.AppUser.Commands.Models;
using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Core.Mapping.AppUser
{
    public partial class ApplicationUserProfile
    {
        public void UpdateUserMapping()
        {
            CreateMap<UpdateUserCommand, ApplicationUser>();
        }
    }
}
