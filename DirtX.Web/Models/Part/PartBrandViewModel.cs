﻿namespace DirtX.Web.Models.Part;
using DirtX.Infrastructure.Data.Models.Products;

public class PartBrandViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public List<Part> Parts { get; set; }
}