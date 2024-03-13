﻿namespace DirtX.Models;
using DirtX.Infrastructure.Data.Models.Enums;

public class OilDetailsViewModel
{
    public int Id { get; set; }
    public OilType Type { get; set; }
    public string BrandName { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool IsAvailable { get; set; }
    public int StockQuantity { get; set; }
    public string ImageUrl { get; set; }
}