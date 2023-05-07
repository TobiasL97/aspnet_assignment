using aspnet_assignment.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace aspnet_assignment.Models.Entities
{
    public class ImageEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ImageUrl { get; set; } = null!;

        public Guid ProductId { get; set; }

        public ProductEntity Product { get; set; } = null!;

    }
}
