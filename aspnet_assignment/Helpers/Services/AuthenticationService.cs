using aspnet_assignment.Models.Entities;
using aspnet_assignment.Models.Identity;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace aspnet_assignment.Helpers.Services
{
    public class AuthenticationService
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly AddressService _addressService;

        public AuthenticationService(UserManager<CustomUser> userManager, AddressService addressService, SignInManager<CustomUser> signInManager)
        {
            _userManager = userManager;
            _addressService = addressService;
            _signInManager = signInManager;
        }

        public async Task<bool> CheckIfUserExistsAsync(Expression<Func<CustomUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }

        public async Task<bool> CreateUserAsync(SignUpUserViewModel viewModel)
        {
            CustomUser user = viewModel;

            
            if (!await _userManager.Users.AnyAsync())
            {
                await _userManager.CreateAsync(user, viewModel.Password);
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                await _userManager.CreateAsync(user, viewModel.Password);
                await _userManager.AddToRoleAsync(user, "User");
            }
         
            var address = await _addressService.GetOrCreateAddressAsync(viewModel);
            if (address != null)
            {
                await _addressService.AddAddressAsync(user, address);
                return true;
            }
            return false;
        }

        public async Task<bool> LoginAsync(SignInUserViewModel viewModel)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == viewModel.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, false, false);
                return result.Succeeded;
            }

            return false;
        }
    }
}
