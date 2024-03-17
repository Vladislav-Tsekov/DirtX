﻿using DirtX.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class Part : Product
    {
        [Required]
        public PartType Type { get; set; }

        public List<PartProperty> PartProperties { get; set; }
        public List<MotorcyclePart> MotorcycleParts { get; set; }
    }
}
