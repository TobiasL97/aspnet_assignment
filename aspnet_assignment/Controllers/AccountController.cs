using aspnet_assignment.Helpers.Services;
using aspnet_assignment.Models.Identity;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_assignment.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthenticationService _authService;
        private readonly SignInManager<CustomUser> _signInManager;

        public AccountController(AuthenticationService authService, SignInManager<CustomUser> signInManager)
        {
            _authService = authService;
            _signInManager = signInManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        #region SignUp
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                if(await _authService.CheckIfUserExistsAsync(x => x.Email == viewModel.Email))
                {
                    //Kollar om det finns en användare med samma E-mail
                    ModelState.AddModelError("", "A user with the same E-mail already exists"); 
                }

                if(await _authService.CreateUserAsync(viewModel))
                {
                    return RedirectToAction("SignIn", "Account");
                }

            }
            return View(viewModel);
        }
        #endregion

        #region SignIn

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInUserViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                if(await _authService.LoginAsync(viewModel))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect Email or Password");
                }
            }
            
            return View(viewModel);

        }
        #endregion

        #region SignOut
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
