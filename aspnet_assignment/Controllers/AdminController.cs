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

		public AdminController(AuthenticationService authService)
		{
			_authService = authService;
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
	}
}
