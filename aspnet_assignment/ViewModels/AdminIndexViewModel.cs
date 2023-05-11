using aspnet_assignment.Models.Entities;
using aspnet_assignment.Models.Identity;

namespace aspnet_assignment.ViewModels
{
    public class AdminIndexViewModel
    {
        public string Id { get; set; } = null!;
        public string? FirstName { get; set;}
        public string? LastName { get; set;}
        public string? Email { get; set;}

        public string? Title { get; set;}
        public decimal? Price { get; set;}
        public List<ImageEntity> Images { get; set;} = new List<ImageEntity>();

        

        public IList<string> Roles { get; set; } = null!;


        public static implicit operator AdminIndexViewModel(CustomUser user)
        {
            return new AdminIndexViewModel
            {
                Id = user.Id,
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
            };
        }
    }
}
