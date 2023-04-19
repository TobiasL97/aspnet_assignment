using aspnet_assignment.Contexts;
using aspnet_assignment.Models.Entities;

namespace aspnet_assignment.Helpers.Repositories
{
    public class UserAddressRepository : Repository<UserAddressEntity>
    {
        public UserAddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
