using aspnet_assignment.Helpers.Services;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_assignment.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthenticationService _authService;

        public AccountController(AuthenticationService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUpUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUpUser(SignUpUserViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(await _authService.CheckIfUserExistsAsync(x => x.Email == model.Email))
                {
                    //Kollar om det finns en användare med samma E-mail
                    ModelState.AddModelError("", "A user with the same E-mail already exists"); 
                }
                else
                {
                    
                }
            }
            return View(model);
        }
    }
}
