using aspnet_assignment.Contexts;
using aspnet_assignment.Models.Entities;

namespace aspnet_assignment.Helpers.Repositories
{
    public class AddressRepository : Repository<AddressEntity>
    {
        public AddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
