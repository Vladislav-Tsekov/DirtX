﻿using DirtX.Infrastructure.Data.Models.Motorcycles;
using DirtX.Infrastructure.Data.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class MotorcyclePart
    {
        [ForeignKey(nameof(MotorcycleId))]
        public Motorcycle Motorcycle { get; set; }
        public int MotorcycleId { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; }
        public int PartId { get; set; }
    }
}
