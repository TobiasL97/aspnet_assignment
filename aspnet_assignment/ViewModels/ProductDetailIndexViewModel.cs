using aspnet_assignment.Models.Entities;

namespace aspnet_assignment.ViewModels
{
    public class ProductDetailIndexViewModel
    {
        public ProductDetailViewModel ProductDetail { get; set; } = null!;

        public ProductDetailInfoViewModel ProductDetailInfo { get; set; } = null!;

        public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();

    }
}
