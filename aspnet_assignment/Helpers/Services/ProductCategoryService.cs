using aspnet_assignment.Contexts;
using aspnet_assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspnet_assignment.Helpers.Services
{
    public class ProductCategoryService
    {
        private readonly DataContext _context;
        public ProductCategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ProductCategoryEntity>> GetAllProductCategories()
        {
            return await _context.ProductCategories.ToListAsync();
        }
    }
}
