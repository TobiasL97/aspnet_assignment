using aspnet_assignment.Helpers.Services;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace aspnet_assignment.Controllers
{
    public class ContactController : Controller
    {
        private readonly CommentService _commentService;

        public ContactController(CommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                if(viewModel.SaveInfo == true)
                {
                    await _commentService.CreateComment(viewModel);
                }
                await _commentService.CreateComment(viewModel);

                return RedirectToAction("Index");
               
            }

            return View();
        }
    }
}
