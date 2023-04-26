using aspnet_assignment.Models.Identity;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Data;

namespace aspnet_assignment.Helpers.Services
{
    public class UserService
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UserService(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        


        public async Task<List<CustomUser>> GetAllUsersAsync()
        {
            var result = await _userManager.Users.ToListAsync();

            return result;
        }

        public async Task<IEnumerable<AdminIndexViewModel>> GetAllUsers()
        {
            var userList = new List<AdminIndexViewModel>();
            var users = await _userManager.Users.ToListAsync();

            

            foreach (var user in users)
            {
                AdminIndexViewModel adminIndexViewModel = user;
                adminIndexViewModel.Roles = await _userManager.GetRolesAsync(user);
                userList.Add(adminIndexViewModel);
            }

            var listSortedByRole = userList.OrderByDescending(x => x.Roles.Contains("Admin"));

            return listSortedByRole;
        }
    }
}
