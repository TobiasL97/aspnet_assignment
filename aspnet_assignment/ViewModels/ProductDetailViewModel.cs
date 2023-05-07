using aspnet_assignment.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_assignment.ViewModels
{
    public class ProductDetailViewModel
    {
        public string Title { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public ICollection<ProductCategoryEntity> Categories { get; set; } = new List<ProductCategoryEntity>();

        public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();

        public ICollection<ImageEntity> Images { get; set; } = new List<ImageEntity>();

        public static implicit operator ProductDetailViewModel(ProductEntity entity)
        {
            var product = new ProductDetailViewModel
            {
                Title = entity.Title,
                Price = entity.Price,
                Description = entity.Description,
                Categories = entity.Categories,
                Reviews = entity.Reviews,
                Images = entity.Images,
            };
            return product;
        }
    }
}
