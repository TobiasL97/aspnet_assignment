using aspnet_assignment.Helpers.Services;
using aspnet_assignment.Models.Entities;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace aspnet_assignment.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ImageService _imageService;

        public ProductController(ProductService productService, ImageService imageService)
        {
            _productService = productService;
            _imageService = imageService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ProductViewModel
            {
                Products = await _productService.GetAllProductsAsync()
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetail(ProductEntity entity)
        {
            var product = await _productService.GetProductAsync(entity);
            var viewModel = new ProductDetailIndexViewModel
            {
                ProductDetail = new ProductDetailViewModel
                {
                    Title = product.Title,
                    Price = product.Price,
                    Categories = product.Categories,
                    Reviews = product.Reviews,
                    Images = product.Images
                },

                ProductDetailInfo = new ProductDetailInfoViewModel
                {
                    Title = product.Title,
                    Description = product.Description,
                    Images = product.Images,
                },

                Products = await _productService.GetAllRelatedProductsAsync(entity.Id)

            };
            return View(viewModel);
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
                await _productService.UploadProductImagesAsync(viewModel.Images);

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View(viewModel);
            }

            
        }
    }
}
