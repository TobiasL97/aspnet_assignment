using aspnet_assignment.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_assignment.ViewModels
{
    public class ProductDetailViewModel
    {
        public string Title { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public ICollection<ProductCategoryEntity> Categories { get; set; } = new List<ProductCategoryEntity>();

        public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();

        public ICollection<ImageEntity> Images { get; set; } = new List<ImageEntity>();

    }
}
