using aspnet_assignment.Models.Entities;

namespace aspnet_assignment.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
