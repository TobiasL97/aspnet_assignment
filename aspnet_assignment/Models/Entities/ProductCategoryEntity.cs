using Microsoft.EntityFrameworkCore;

namespace aspnet_assignment.Models.Entities
{
    [PrimaryKey(nameof(ProductId), nameof(AddressId))]
    public class ProductCategoryEntity
    {
        public string ProductId { get; set; } = null!;
        public ProductEntity Product { get; set; } = null!;
        public string AddressId { get; set; } = null!;
        public CategoryEntity Category { get; set; } = null!;

    }
}
