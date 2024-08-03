using SchoolManagment.Core.Features.Authorization.Queries.Response;
using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Core.Mapping.Roles
{
    public partial class RoleMapping
    {
        public void GetRolesListMapping()
        {
            CreateMap<Role, GetRolesListResponse>();
        }
    }
}
