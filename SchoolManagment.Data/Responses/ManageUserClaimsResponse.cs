namespace SchoolManagment.Data.Responses
{
    public class ManageUserClaimsResponse
    {
        public int UserId { get; set; }
        public List<UserClaims> Claims { get; set; }
    }

    public class UserClaims
    {
        public string Type { get; set; }
        public bool Value { get; set; }

    }
}
