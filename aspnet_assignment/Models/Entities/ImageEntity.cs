namespace aspnet_assignment.Models.Entities
{
    public class ImageEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ImageUrl { get; set; } = null!;

        public ProductEntity Product { get; set; } = null!;
    }
}
