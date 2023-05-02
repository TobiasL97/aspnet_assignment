using aspnet_assignment.Helpers.Services;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_assignment.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ProductDetail()
        {
            return View();
        }

        
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                await _productService.CreateProductAsync(viewModel);
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
