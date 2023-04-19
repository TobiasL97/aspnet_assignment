using aspnet_assignment.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace aspnet_assignment.Models.Entities
{
    [PrimaryKey(nameof(UserId), nameof(AddressId))]
    public class UserAddressEntity
    {
        public string UserId { get; set; } = null!;
        public CustomUser User { get; set; } = null!;
        public int AddressId { get; set; }

        public AddressEntity Address { get; set; } = null!;
    }
}
