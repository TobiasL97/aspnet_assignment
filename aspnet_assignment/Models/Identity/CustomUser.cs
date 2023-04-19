using aspnet_assignment.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace aspnet_assignment.Models.Identity
{
    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? CompanyName { get; set; }

        public string? ProfileImage { get; set; }

        public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();
    }
}
