using aspnet_assignment.Contexts;
using aspnet_assignment.Models.Entities;
using aspnet_assignment.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace aspnet_assignment.Helpers.Services
{
    public class ImageService
    {
        private readonly DataContext _context;

        public ImageService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddImageAsync(CreateProductViewModel viewModel, ProductEntity entity)
        {
            try
            {
                foreach (var item in viewModel.Images)
                {
                    var productImage = new ImageEntity
                    {
                        ImageUrl = item.FileName,
                    };

                    entity.Images.Add(productImage);
                }
                return true;
            }
            catch { return false; }
        }

        public async Task<IEnumerable<ImageEntity>> GetProductImagesAsync()
        {
            return await _context.Images.ToListAsync();
        }
    }
}
