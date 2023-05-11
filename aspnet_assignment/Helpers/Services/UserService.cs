using aspnet_assignment.Contexts;
using aspnet_assignment.Helpers.Repositories;
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
        private readonly IdentityContext _context;



		public UserService(UserManager<CustomUser> userManager, IdentityContext context)
		{
			_userManager = userManager;
			_context = context;
		}


		public async Task<CustomUser> GetUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                return user;
            }
            else
            {
				return null!;
			}

        }


        public async Task<List<CustomUser>> GetAllUsersAsync()
        {
            var result = await _userManager.Users.ToListAsync();

            return result;
        }

        public async Task<IEnumerable<AdminIndexViewModel>> GetAllUserRolesAsync()
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

		public async Task<CustomUser> GetUserAddressAsync(string id)
		{
            var user = await _userManager.Users.Include(x => x.Addresses).ThenInclude(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);


			return user!;
		}


	}
}
