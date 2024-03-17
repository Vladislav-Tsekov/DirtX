﻿using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Infrastructure.Data.Models.Products.Properties;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class OilProperty
    {
        [ForeignKey(nameof(SpecificationId))]
        public OilSpecification Specification { get; set; }
        public int SpecificationId { get; set; }

        [ForeignKey(nameof(OilId))]
        public Oil Oil { get; set; }
        public int OilId { get; set; }
    }
}
