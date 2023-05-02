using aspnet_assignment.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace aspnet_assignment.ViewModels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "You must enter the title of the product")]
        [Display(Name = "Title*")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "You must enter the price of the product")]
        [Display(Name = "Price*")]
        public decimal Price { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Categories")]
        public List<string> Categories { get; set; } = null!;

        [Required(ErrorMessage = "You must enter an imageurl")]
        [Display(Name = "ImageUrl*")]
        public string ImageUrl { get; set; } = null!;

        public static implicit operator ProductEntity(CreateProductViewModel viewModel)
        {
            return new ProductEntity
            {
                Title = viewModel.Title,
                Price = viewModel.Price,
                Description = viewModel.Description!,
                ProductImageUrl = viewModel.ImageUrl,
            };
        }
    }


}
