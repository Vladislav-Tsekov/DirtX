﻿using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            Product part = await context.Products
                .AsNoTracking()
                .Include(p => p.Brand)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return part;
        }

        public async Task<List<Product>> GetAllPartsAsync()
        {
            return await context.Products
                .Where(p => p.Type.Name == "Part")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllOilsAsync()
        {
            return await context.Products
                .Where(p => p.Type.Name == "Oil")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllGearsAsync()
        {
            return await context.Products
                .Where(p => p.Type.Name == "Gear")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProductBrand> GetProductBrandAsync(string brandName)
        {
            return await context.ProductBrands
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Name == brandName);
        }

        public async Task<List<Product>> GetProductsByBrandAsync(ProductBrand brand)
        {
            return await context.Products
                .Where(p => p.BrandId == brand.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsByCategoryAsync(ProductCategory category)
        {
            return await context.Products
                .Where(p => p.Category == category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<ProductBrand>> GetDistinctProductBrandsAsync(List<Product> products)
        {
            List<int> distinctBrands = products
                .Select(p => p.BrandId)
                .Distinct()
                .ToList();

            List<ProductBrand> brands = await context.ProductBrands
                .AsNoTracking()
                .Where(brand => distinctBrands.Contains(brand.Id))
                .ToListAsync();

            return brands;
        }

        public List<ProductCategory> GetProductCategories(List<Product> products)
        {
            List<ProductCategory> productTypes = products
                .Select(p => p.Category)
                .Distinct()
                .ToList();

            return productTypes;
        }

        public async Task<List<ProductSpecification>> GetProductSpecificationsAsync(int id)
        {
            List<ProductSpecification> specs = await context.ProductsSpecifications
                .AsNoTracking()
                .Include(p => p.Specification)
                .ThenInclude(pp => pp.Title)
                .Where(p => p.ProductId == id)
                .ToListAsync();

            return specs;
        }
    }
}
