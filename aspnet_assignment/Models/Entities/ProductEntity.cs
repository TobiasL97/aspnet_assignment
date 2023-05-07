using aspnet_assignment.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace aspnet_assignment.Models.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; } = null!;

        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        public string Description { get; set; } = null!;
        public Guid StockId { get; set; }

        public ICollection<ImageEntity> Images { get; set; } = new List<ImageEntity>();

        public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();

        public ICollection<ProductCategoryEntity> Categories { get; set; } = new List<ProductCategoryEntity>();

        public StockEntity Stock { get; set; } = null!;

    }
}
