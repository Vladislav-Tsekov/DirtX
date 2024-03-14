﻿namespace DirtX.Web.Models.Used;
using DirtX.Infrastructure.Data.Models.Enums;

public class UsedIndexViewModel
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Displacement { get; set; }
    public int Year { get; set; }
    public byte[] Image { get; set; }
    public string Province { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Contact { get; set; }
}
