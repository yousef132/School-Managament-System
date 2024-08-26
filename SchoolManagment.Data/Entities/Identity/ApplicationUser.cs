using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagment.Data.Entities.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public Address? Address { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastUpdate { get; set; } = null;
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }



        [EncryptColumn]
        public string? Code { get; set; }
        public ICollection<UserRefreshToken> userRefreshTokens { get; set; } = new HashSet<UserRefreshToken>();
    }
    [Owned]
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
