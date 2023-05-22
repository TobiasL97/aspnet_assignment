using aspnet_assignment.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_assignment.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;
        public Guid StockId { get; set; }

        public ICollection<ImageEntity> Images { get; set; } = new List<ImageEntity>();

        public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();

        public ICollection<ProductCategoryEntity> Categories { get; set; } = new List<ProductCategoryEntity>();

        public StockEntity Stock { get; set; } = null!;

        public static implicit operator ProductModel(ProductEntity entity)
        {
            return new ProductModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Price = entity.Price,
                Description = entity.Description,
                StockId = entity.StockId,
                Images = entity.Images,
                Categories = entity.Categories,
                Stock = entity.Stock
            };
        }
    }
}
