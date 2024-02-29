﻿using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.MotorcycleSpecs;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.ProductModels
{
    public class Part : Product
    {
        [Required]
        public PartType Type { get; set; }

        public List<PartProperty> Properties { get; set; }
        public List<MotorcyclePart> MotorcycleParts { get; set; }
    }
}
