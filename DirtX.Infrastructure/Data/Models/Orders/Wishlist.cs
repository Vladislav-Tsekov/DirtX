﻿using DirtX.Infrastructure.Data.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Orders
{
    public class Wishlist
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
