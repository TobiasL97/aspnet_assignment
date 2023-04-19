using Microsoft.AspNetCore.Mvc;

namespace aspnet_assignment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
