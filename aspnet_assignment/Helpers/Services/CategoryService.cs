using aspnet_assignment.Contexts;
using aspnet_assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;

namespace aspnet_assignment.Helpers.Services
{
    public class CategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task PopulateCategoriesAsync()
        {
            if(_context.Categories.IsNullOrEmpty())
            {
                var categoryList = new List<CategoryEntity>
                {
                    new CategoryEntity { CategoryName = "New"},
                    new CategoryEntity { CategoryName = "Popular"},
                    new CategoryEntity { CategoryName = "Featured"}
                };

                await _context.Categories.AddRangeAsync(categoryList);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryEntity>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
