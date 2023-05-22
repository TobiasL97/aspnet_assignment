using aspnet_assignment.Models;
using aspnet_assignment.Models.Entities;

namespace aspnet_assignment.ViewModels
{
    public class UpToSellViewModel
    {
        public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
