namespace aspnet_assignment.Models.Entities
{
    public class ProductImageEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ImageUrl { get; set; } = null!;

        public Guid ProductId { get; set; }

        public ProductEntity Producty { get; set; } = null!;
    }
}
