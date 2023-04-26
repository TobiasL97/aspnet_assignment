namespace aspnet_assignment.Models.Entities
{
    public class ReviewEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime? Created { get; set; } = DateTime.Now;

        public string? Comment { get; set; }

        public Guid ProductId { get; set; }

        public ProductEntity Product { get; set; } = null!;
    }
}
