using aspnet_assignment.Models.Entities;

namespace aspnet_assignment.ViewModels
{
    public class UpToSellViewModel
    {
        public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
