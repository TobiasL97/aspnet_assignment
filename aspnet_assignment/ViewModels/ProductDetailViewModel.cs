using aspnet_assignment.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_assignment.ViewModels
{
    public class ProductDetailViewModel
    {
        public string Title { get; set; } = null!;

        public decimal Price { get; set; }

        public ICollection<ProductCategoryEntity> Categories { get; set; } = new List<ProductCategoryEntity>();

        public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();

        public ProductDetailImageGridViewModel ImageGrid { get; set; } = null!;
    }
}
