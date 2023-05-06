using aspnet_assignment.Helpers.Services;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnet_assignment.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                BestCollection = new BestCollectionViewModel
                {
                    Title = "Best Collection",
                },
            };

            return View(viewModel);
        }
    }
}
