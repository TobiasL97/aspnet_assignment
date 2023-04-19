using Microsoft.AspNetCore.Mvc;

namespace aspnet_assignment.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
