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
        private readonly AddressService _addressService;

        public AuthenticationService(UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckIfUserExistsAsync(Expression<Func<CustomUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }

        public async Task<bool> CreateUserAsync(SignUpUserViewModel viewModel)
        {
            var user = viewModel;

            var result = await _userManager.CreateAsync(user, viewModel.Password);
            if(result.Succeeded)
            {
                var address = await _addressService.GetOrCreateAddressAsync(viewModel);
                if (address != null)
                {
                    await _addressService.AddAddressAsync(user, address);
                    return true;
                }
            }
            return false;
        }
    }
}
