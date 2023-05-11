using aspnet_assignment.Contexts;
using aspnet_assignment.Models.Identity;

namespace aspnet_assignment.Helpers.Repositories
{
	public class UserRepository : Repository<CustomUser>
	{
		public UserRepository(IdentityContext context) : base(context)
		{
		}
	}
}
