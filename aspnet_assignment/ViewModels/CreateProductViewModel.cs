using aspnet_assignment.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace aspnet_assignment.ViewModels
{
    public class CreateProductViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "You must enter the title of the product")]
        [Display(Name = "Title*")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "You must enter the price of the product")]
        [Display(Name = "Price*")]
        public decimal Price { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Categories")]
        public List<Guid> Categories { get; set; } = new List<Guid>();

        [Required(ErrorMessage = "You must enter an imageurl")]
        [Display(Name = "ImageUrl*")]
        [DataType(DataType.Upload)]
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();

        public static implicit operator ProductEntity(CreateProductViewModel viewModel)
        {
            return new ProductEntity
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Price = viewModel.Price,
                Description = viewModel.Description!,

            };
        }
    }


}
