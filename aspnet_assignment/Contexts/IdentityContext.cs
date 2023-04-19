using aspnet_assignment.Models.Entities;
using aspnet_assignment.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aspnet_assignment.Contexts
{
    public class IdentityContext : IdentityDbContext<CustomUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<AddressEntity> AspNetAddresses { get; set; }

        public DbSet<UserAddressEntity> AspNetUserAddresses { get; set; }
    }
}
