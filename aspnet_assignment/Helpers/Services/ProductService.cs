﻿using aspnet_assignment.Contexts;
using aspnet_assignment.Helpers.Repositories;
using aspnet_assignment.Models;
using aspnet_assignment.Models.Entities;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace aspnet_assignment.Helpers.Services
{
    public class ProductService
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ImageService _imageService;

        public ProductService(DataContext context, IWebHostEnvironment webHostEnvironment, ImageService imageService)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imageService = imageService;
        }

        public async Task CreateProductAsync(CreateProductViewModel viewModel)
        {
            ProductEntity productEntity = viewModel;
       
            productEntity.StockId = await _context.Stocks.Where(x => x.Stock == "In stock").Select(x => x.Id).FirstOrDefaultAsync();
            foreach(var categoryId in viewModel.Categories)
            {
                await _context.ProductCategories.AddAsync(new ProductCategoryEntity
                {
                    ProductId = productEntity.Id,
                    CategoryId = categoryId,
                });
            }
            _imageService.AddProductImages(viewModel, productEntity);

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UploadProductImagesAsync(List<IFormFile> images)
        {
            try
            {
                foreach(var image in images)
                {
                    string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{image.FileName}";
                    await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
                }
                return true;
            }
            catch { return false; }
        }

        public async Task<ProductEntity> GetProductAsync(ProductEntity entity)
        {
            var result = await _context.Products.Include(x => x.Categories).ThenInclude(x => x.Category).Include(x => x.Images).FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (result != null)
            {
                return result;
            }
            else return null!;
        }

        public async Task<ProductEntity> GetProductByIdAsync(Guid id)
        {
            var product = await _context.Products.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);

            if(product != null)
            {
                return product;
            }
            else
            {
                return null!;
            }
        }

        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            var products = await _context.Products.Include(x => x.Stock).Include(x => x.Categories).ThenInclude(x => x.Category).Include(x => x.Images).ToListAsync();
            var productList = new List<ProductModel>();
            foreach(var product in products)
            {
                ProductModel model = product;
                productList.Add(model);
            }
            return productList;
        }

        public async Task<IEnumerable<ProductModel>> GetAllRelatedProductsAsync(Guid id)
        {
            var selectedProduct = await _context.Products.Include(x => x.Categories).ThenInclude(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);


            if (selectedProduct != null)
            {
                var categoryIds = selectedProduct.Categories.Select(pc => pc.CategoryId);
                var relatedProducts = await _context.Products.Include(x => x.Images).Include(p => p.Categories).ThenInclude(pc => pc.Category).Where(p => p.Categories.Any(pc => categoryIds.Contains(pc.CategoryId))).Where(x => x.Id != id).ToListAsync();
                var productList = new List<ProductModel>();
                foreach (var product in relatedProducts)
                {
                    ProductModel productModel = product;
                    productList.Add(productModel);
                }
                return productList;
            }

            else { return null!; }
            
        }

        public async Task UpdateProductAsync(AdminEditProductViewModel viewModel)
        {
            var product = await GetProductByIdAsync(viewModel.Id);

            if (product != null)
            {
                product.Title = viewModel.Title!;
                product.Price = viewModel.Price;
                product.Description = viewModel.Description!;
                product.Categories.Clear();

                foreach (var categoryId in viewModel.Categories)
                {
                    product.Categories.Add(new ProductCategoryEntity
                    {
                        ProductId = viewModel.Id,
                        CategoryId = categoryId
                    });
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProductAsync(ProductEntity product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
