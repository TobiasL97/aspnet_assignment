using aspnet_assignment.Models;
using aspnet_assignment.Models.Entities;

namespace aspnet_assignment.ViewModels
{
    public class TopSellingViewModel
    {
        public string Title { get; set; } = null!;
        public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
