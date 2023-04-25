namespace aspnet_assignment.Models.Entities
{
    public class CategoryEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string CategoryName { get; set; } = null!;

        public ICollection<ProductCategoryEntity> Products { get; set; } = new List<ProductCategoryEntity>();
    }
}
