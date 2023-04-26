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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {


            return View();
        }
    }
}
