using aspnet_assignment.Models;

namespace aspnet_assignment.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
