namespace aspnet_assignment.Models.Entities
{
    public class ReviewEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime? Created { get; set; } = DateTime.Now;

        public string? Comment { get; set; }

        public string ProductId { get; set; } = null!;

        public ProductEntity Product { get; set; } = null!;
    }
}
