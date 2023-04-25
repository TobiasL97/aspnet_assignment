namespace aspnet_assignment.Models.Entities
{
    public class StockEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Stock { get; set; } = null!;

        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
