using SchoolManagment.Core.Features.AppUser.Queries.Responses;
using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Core.Mapping.AppUser
{
    public partial class ApplicationUserProfile
    {
        public void GetCurrentUserMapping()
        {
            CreateMap<ApplicationUser, GetCurrentUserResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
