﻿using aspnet_assignment.Models.Entities;

namespace aspnet_assignment.ViewModels
{
    public class BestCollectionViewModel
    {
        public string Title { get; set; } = null!;

        public IEnumerable<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();

        public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
