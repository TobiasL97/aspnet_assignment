using aspnet_assignment.Contexts;
using aspnet_assignment.Helpers.Repositories;
using aspnet_assignment.Models.Entities;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnet_assignment.Helpers.Services
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
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
            

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductEntity> GetProductAsync(ProductEntity entity)
        {
            var result = await _context.Products.Include(x => x.Categories).ThenInclude(x => x.Category).FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (result != null)
            {
                return result;
            }
            else return null!;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            return await _context.Products.Include(x => x.Stock).Include(x => x.Categories).ThenInclude(x => x.Category).ToListAsync();

        }
    }
}