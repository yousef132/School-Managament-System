namespace SchoolManagment.Core.Features.AppUser.Queries.Responses
{
    public class GetCurrentUserResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? ImagePath { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
