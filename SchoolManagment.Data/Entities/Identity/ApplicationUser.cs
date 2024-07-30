﻿using Microsoft.AspNetCore.Identity;

namespace SchoolManagment.Data.Entities.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }

    }
}
