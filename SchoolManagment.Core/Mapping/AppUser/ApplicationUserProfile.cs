using AutoMapper;

namespace SchoolManagment.Core.Mapping.AppUser
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            AddUserMapping();
            GetUsersListMapping();
            GetUserByIdMapping();
            UpdateUserMapping();
        }
    }
}
