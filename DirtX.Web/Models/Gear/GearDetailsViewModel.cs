﻿using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Web.Models.Gear
{
    public class GearDetailsViewModel
    {
        public int Id { get; set; }
        public GearType Type { get; set; }
        public string BrandName { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Specification> Specs { get; set; }
    }
}
