namespace SchoolManagment.Core.Features.AppUser.Queries.Responses
{
    public class GetUserListResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? FullName { get; set; }
        public string Country { get; set; }
    }
}
