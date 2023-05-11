﻿using aspnet_assignment.Contexts;
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
		private readonly UserAddressRepository _userAddressRepository;
		private readonly AddressService _addressService;
		private readonly IdentityContext _context;

		public AdminController(AuthenticationService authService, UserService userService, UserAddressRepository userAddressRepository, IdentityContext context)
		{
			_authService = authService;
			_userService = userService;
			_userAddressRepository = userAddressRepository;
			_context = context;
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



		[HttpGet]
		public async Task<IActionResult> EditUser(string Id)
		{
			var user = await _userService.GetUserAddressAsync(Id);
			//var user = await _userService
			//var address = await _addressService.GetUserAddressAsync(Id);

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
	}
}
