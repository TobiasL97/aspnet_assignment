using aspnet_assignment.Contexts;
using aspnet_assignment.Helpers.Repositories;
using aspnet_assignment.Helpers.Services;
using aspnet_assignment.Models.Identity;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace aspnet_assignment.Controllers
{
    public class AdminController : Controller
    {
		private readonly AuthenticationService _authService;
		private readonly UserService _userService;
		private readonly IdentityContext _identityContext;
		private readonly UserManager<CustomUser> _userManager;
		private readonly ProductService _productService;

        public AdminController(AuthenticationService authService, UserService userService, UserManager<CustomUser> userManager, ProductService productService, IdentityContext identityContext)
        {
            _authService = authService;
            _userService = userService;
            _userManager = userManager;
            _productService = productService;
            _identityContext = identityContext;
        }

        [Authorize(Roles = "Admin")]
        public  IActionResult Index()
        {


            return View();
        }

		public IActionResult CreateUser()
		{
			return View();
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public async Task<IActionResult> CreateUser(AdminCreateUserViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				if (await _authService.CheckIfUserExistsAsync(x => x.Email == viewModel.Email))
				{
					ModelState.AddModelError("", "A user with the same E-mail already exists");
				}

				if (await _authService.AdminCreateUserAsync(viewModel))
				{
					return RedirectToAction("index", "Admin");
				}

			}
			return View(viewModel);
		}



		[Authorize(Roles = "Admin")]
		[HttpGet]
		public async Task<IActionResult> EditUser(string Id)
		{
			var user = await _userService.GetUserAddressAsync(Id);

			var userViewModel = new AdminEditUserViewModel
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Mobile = user.PhoneNumber,
				Email = user.Email!,
				CompanyName = user.CompanyName,
				
			};
			foreach(var address in user.Addresses)
			{
				if(address != null)
				{
					userViewModel.StreetName = address.Address.StreetName;
					userViewModel.City = address.Address.City;
					userViewModel.PostalCode = address.Address.PostalCode;
				}
			}

			return View(userViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> EditUser(AdminEditUserViewModel viewModel)
		{
			if(ModelState.IsValid)
			{
				
				await _userService.UpdateUserAsync(viewModel);
				return RedirectToAction("index");
				
			}

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteUser(string id)
		{
			var user = await _userService.GetUserAsync(id);

			if(user != null)
			{
				await _userManager.DeleteAsync(user);
				await _identityContext.SaveChangesAsync();
                return Ok();
            }
			else
			{
				return BadRequest();
			}
			
		}

		public async Task<IActionResult> EditProduct(Guid id)
		{
			var product = await _productService.GetProductByIdAsync(id);

			var editProductViewModel = new AdminEditProductViewModel
			{
				Title = product.Title,
				Description = product.Description,
				Price = product.Price,
			};

			return View(editProductViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> EditProduct(AdminEditProductViewModel viewModel)
		{
			if(ModelState.IsValid)
			{
				await _productService.UpdateProductAsync(viewModel);
				return RedirectToAction("index");
			}

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteProduct(Guid id)
		{
			var product = await _productService.GetProductByIdAsync(id);

			if(product != null)
			{
				await _productService.RemoveProductAsync(product);
				return Ok();
			}

			return BadRequest();
		}
	}
}
