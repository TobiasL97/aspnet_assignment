using aspnet_assignment.Helpers.Services;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_assignment.Controllers
{
    public class HomeController : Controller
    {

        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public HomeController(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                BestCollection = new BestCollectionViewModel
                {
                    Title = "Best Collection",
                    Categories = await _categoryService.GetAllCategoriesAsync(),
                    Products = await _productService.GetAllProductsAsync()
                },

                TopSelling = new TopSellingViewModel
                {
                    Title = "Top selling products in this week",
                    Products = await _productService.GetAllProductsAsync()
                },

                UpToSell = new UpToSellViewModel
                {
                    Products = await _productService.GetAllProductsAsync()
                }

            };



            

            return View(viewModel);
        }
    }
}
