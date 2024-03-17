﻿using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Models
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<ProductProperty> Specs { get; set; }
    }
}
