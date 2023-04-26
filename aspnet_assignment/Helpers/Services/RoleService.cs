using aspnet_assignment.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace aspnet_assignment.Helpers.Services
{
    public class RoleService
    {
        private readonly UserManager<CustomUser> _userManager;

        public RoleService(UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
        }

        
    }
}
