using aspnet_assignment.Models.Entities;
using aspnet_assignment.Models.Identity;

namespace aspnet_assignment.ViewModels
{
    public class AdminIndexViewModel
    {
        public string? FirstName { get; set;}
        public string? LastName { get; set;}
        public string? Email { get; set;}

        public string? Title { get; set;}
        public decimal? Price { get; set;}
        public string? ImageUrl { get; set;}

        

        public IList<string> Roles { get; set; } = null!;


        public static implicit operator AdminIndexViewModel(CustomUser user)
        {
            return new AdminIndexViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
        }

        public static implicit operator AdminIndexViewModel(ProductEntity product)
        {
            return new AdminIndexViewModel
            {
                Title = product.Title,
                Price = product.Price,
                ImageUrl = product.ProductImageUrl
            };
        }
    }
}
