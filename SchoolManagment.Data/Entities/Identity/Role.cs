using Microsoft.AspNetCore.Identity;

namespace SchoolManagment.Data.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        // just for EntityFramework
        private Role()
        {

        }
        public Role(string role) : base(role)
        {

        }
    }
}
