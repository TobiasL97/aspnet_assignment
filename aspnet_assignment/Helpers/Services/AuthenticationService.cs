using aspnet_assignment.Models.Entities;
using aspnet_assignment.Models.Identity;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

namespace aspnet_assignment.Helpers.Services
{
    public class AuthenticationService
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly AddressService _addressService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ImageService _imageService;

        public AuthenticationService(UserManager<CustomUser> userManager, AddressService addressService, SignInManager<CustomUser> signInManager, IWebHostEnvironment webHostEnvironment, ImageService imageService)
        {
            _userManager = userManager;
            _addressService = addressService;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
            _imageService = imageService;
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
                if(viewModel.Image != null)
                {
                    _imageService.AddProfileImage(viewModel.Image.FileName, user);
                }
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                await _userManager.CreateAsync(user, viewModel.Password);
                if (viewModel.Image != null)
                {
                    _imageService.AddProfileImage(viewModel.Image.FileName, user);
                }
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

        public async Task<bool> UploadProfileImage(IFormFile Image)
        {
            try
            {
                string imagePath = $"{_webHostEnvironment.WebRootPath}/images/profileimages/{Image.FileName}";
                await Image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> AdminCreateUserAsync(AdminCreateUserViewModel viewModel)
        {

            try
			{
				CustomUser customUser = viewModel;

				await _userManager.CreateAsync(customUser, viewModel.Password);
				await _userManager.AddToRoleAsync(customUser, viewModel.Role);

				var address = await _addressService.GetOrCreateAddressAsync(viewModel);
				if (address != null)
				{
					await _addressService.AddAddressAsync(customUser, address);
					return true;
				}

				return true;
			}

            catch { return false; }

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

        public async Task FindLoggedInUser(CustomUser User)
        {
            var user = await _userManager.GetUserIdAsync(User);
        }
    }
}
