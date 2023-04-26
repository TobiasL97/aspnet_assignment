﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace aspnet_assignment.Models.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; } = null!;

        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public Guid StockId { get; set; }

        public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();

        public ICollection<ProductCategoryEntity> Categories { get; set; } = new List<ProductCategoryEntity>();

        public ICollection<ProductImageEntity> ProductImages { get; set; } = null!;

        public StockEntity Stock { get; set; } = null!;
    }
}
