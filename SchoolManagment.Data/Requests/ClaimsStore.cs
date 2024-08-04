using System.Security.Claims;

namespace SchoolManagment.Data.Requests
{
    public static class ClaimsStore
    {
        public static List<Claim> Claims = new()
        {
            new Claim("Create Student", "false"),
            new Claim("Edit Student", "false"),
            new Claim("Delete Student", "false")
        };

    }
}
