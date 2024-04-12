﻿using DirtX.Core.Enums;
using DirtX.Core.Interfaces;
using DirtX.Core.Models.Admin;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
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
            return await context.Products
                .AsNoTracking()
                .Include(p => p.Brand)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetAllPartsAsync()
        {
            return await context.Products
                .AsNoTracking()
                .Where(p => p.Type.Name == "Part")
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllOilsAsync()
        {
            return await context.Products
                .AsNoTracking()
                .Where(p => p.Type.Name == "Oil")
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllGearsAsync()
        {
            return await context.Products
                .AsNoTracking()
                .Where(p => p.Type.Name == "Gear")
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
                .AsNoTracking()
                .Where(p => p.BrandId == brand.Id)
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsByCategoryAsync(ProductCategory category, ProductSorting sorting = ProductSorting.Name_Ascending)
        {
            IQueryable<Product> products = context.Products.Where(p => p.Category == category).AsNoTracking();

            switch (sorting)
            {
                case ProductSorting.Name_Descending:
                    products = products.OrderByDescending(o => o.Title);
                    break;
                case ProductSorting.Price_Ascending:
                    products = products.OrderBy(o => o.Price);
                    break;
                case ProductSorting.Price_Descending:
                    products = products.OrderByDescending(o => o.Price);
                    break;
                default:
                    break;
            }

            return await products.ToListAsync();
        }

        public async Task<List<ProductBrand>> GetDistinctProductBrandsAsync(List<Product> products)
        {
            List<int> distinctBrands = products
                .Select(p => p.BrandId)
                .Distinct()
                .ToList();

            return await context.ProductBrands
                .AsNoTracking()
                .Where(brand => distinctBrands.Contains(brand.Id))
                .ToListAsync();
        }

        public List<ProductCategory> GetProductCategories(List<Product> products)
        {
            return products
                .Select(p => p.Category)
                .Distinct()
                .ToList();
        }

        public async Task<List<ProductSpecification>> GetProductSpecificationsAsync(int id)
        {
            return await context.ProductsSpecifications
                .AsNoTracking()
                .Include(p => p.Specification)
                .ThenInclude(pp => pp.Title)
                .Where(p => p.ProductId == id)
                .ToListAsync();
        }

        public async Task<List<MotorcycleProduct>> GetCompatiblePartsAsync(int makeId, int modelId, int displacementId, int yearId)
        {
            return await context.MotorcyclesParts
                .AsNoTracking()
                .Include(mp => mp.Motorcycle)
                .Include(mp => mp.Motorcycle.Make)
                .Include(mp => mp.Motorcycle.Model)
                .Include(mp => mp.Motorcycle.Displacement)
                .Include(mp => mp.Motorcycle.Year)
                .Include(mp => mp.Product.Brand)
                .Where(mp => mp.Motorcycle.MakeId == makeId &&
                             mp.Motorcycle.ModelId == modelId &&
                             mp.Motorcycle.DisplacementId == displacementId &&
                             mp.Motorcycle.YearId == yearId)
                .ToListAsync();
        }

        public Task<Product> AddProductAsync(ProductFormViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> QueryAllProductsAsync(ProductsQueryModel model, ProductSorting sorting = ProductSorting.Name_Ascending)
        {
            IQueryable<Product> products = context.Products
                .Include(p => p.Brand)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.Search))
            {
                string input = $"%{model.Search.ToLower()}%";

                products = products
                    .Where(i => EF.Functions.Like(i.Title, input) ||
                                EF.Functions.Like(i.Brand.Name, input) ||
                                EF.Functions.Like(i.Description, input));
            }

            switch (sorting)
            {
                case ProductSorting.Name_Descending:
                    products = products.OrderByDescending(o => o.Title);
                    break;
                case ProductSorting.Price_Ascending:
                    products = products.OrderBy(o => o.Price);
                    break;
                case ProductSorting.Price_Descending:
                    products = products.OrderByDescending(o => o.Price);
                    break;
                default:
                    break;
            }

            return await products.ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await context.Products.ToListAsync();
        }
    }
}
