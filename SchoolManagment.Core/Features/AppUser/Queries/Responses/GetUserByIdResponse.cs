using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Core.Features.AppUser.Queries.Responses
{
    public class GetUserByIdResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? FullName { get; set; }
        public Address? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? LastUpdate { get; set; }

        public string Gender { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
