using aspnet_assignment.Models.Entities;

namespace aspnet_assignment.ViewModels
{
    public class ProductDetailInfoViewModel
    {

        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ICollection<ImageEntity> Images { get; set; } = new List<ImageEntity>();

        public static implicit operator ProductDetailInfoViewModel(ProductEntity entity)
        {
            return new ProductDetailInfoViewModel
            {
                Title = entity.Title,
                Description = entity.Description,
                Images = entity.Images
            };
        }
    }
}
