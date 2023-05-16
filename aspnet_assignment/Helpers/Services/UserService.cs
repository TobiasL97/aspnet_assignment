using aspnet_assignment.Contexts;
using aspnet_assignment.Helpers.Repositories;
using aspnet_assignment.Models.Identity;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Data;

namespace aspnet_assignment.Helpers.Services
{
    public class UserService
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly IdentityContext _identityContext;
        private readonly SignInManager<CustomUser> _signInManager;



		public UserService(UserManager<CustomUser> userManager, IdentityContext identityContext, SignInManager<CustomUser> signInManager)
		{
			_userManager = userManager;
			_identityContext = identityContext;
			_signInManager = signInManager;
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

        public async Task UpdateUserAsync(AdminEditUserViewModel viewModel)
        {
			var user = await GetUserAddressAsync(viewModel.Id);
			
			if (user != null)
            {
                user.UserName = viewModel.Email;
				user.FirstName = viewModel.FirstName;
				user.LastName = viewModel.LastName;
				user.Email = viewModel.Email;
				user.PhoneNumber = viewModel.Mobile;
				user.CompanyName = viewModel.CompanyName;
                user.NormalizedEmail = viewModel.Email.ToUpper();
                user.NormalizedUserName = viewModel.Email.ToUpper();
				foreach (var address in user.Addresses)
				{
					address.Address.StreetName = viewModel.StreetName;
					address.Address.City = viewModel.City;
					address.Address.PostalCode = viewModel.PostalCode;
				};
                var roles = await _userManager.GetRolesAsync(user);
                foreach(var role in roles)
                {
                    if(viewModel.Role != role)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role);
                        await _userManager.AddToRoleAsync(user, viewModel.Role);
					}
				}

				await _identityContext.SaveChangesAsync();

			}
		}
	}
}
