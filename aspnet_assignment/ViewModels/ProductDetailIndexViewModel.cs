using aspnet_assignment.Models;

namespace aspnet_assignment.ViewModels
{
    public class ProductDetailIndexViewModel
    {
        public ProductDetailViewModel ProductDetail { get; set; } = null!;

        public ProductDetailInfoViewModel ProductDetailInfo { get; set; } = null!;

        public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();

    }
}
