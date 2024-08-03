using AutoMapper;

namespace SchoolManagment.Core.Mapping.Roles
{
    public partial class RoleMapping : Profile
    {
        public RoleMapping()
        {
            GetRolesListMapping();
        }
    }
}
