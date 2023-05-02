using aspnet_assignment.Contexts;
using aspnet_assignment.Models.Entities;
using aspnet_assignment.ViewModels;
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

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductEntity>> GetAllProductsAsync()
        {
            return await _context.Products.Include(x => x.Stock).ToListAsync();
        }
    }
}
