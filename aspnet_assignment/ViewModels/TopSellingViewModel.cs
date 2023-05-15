using aspnet_assignment.Models.Entities;

namespace aspnet_assignment.ViewModels
{
    public class TopSellingViewModel
    {
        public string Title { get; set; } = null!;
        public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
