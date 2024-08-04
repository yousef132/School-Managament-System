namespace SchoolManagment.Data.Responses
{
    public class ManageUserRolesResponse
    {
        public int UserId { get; set; }
        public List<UserRole> Roles { get; set; }

    }
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasRole { get; set; }

    }
}
