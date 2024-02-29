using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.ProductModels;
using DirtX.Infrastructure.Data.Models.ProductModels.Properties;
using Microsoft.EntityFrameworkCore;
using static DirtX.Infrastructure.Data.Seeders.SeedersConstants;

namespace DirtX.Infrastructure.Data.Seeders
{
    public static class ProductSeeder
    {
        public static void SeedProducts(ModelBuilder modelBuilder)
        {
            SeedProductBrands(modelBuilder);
            SeedParts(modelBuilder);
            SeedProductProperties(modelBuilder);
            SeedOils(modelBuilder);
            SeedGears(modelBuilder);
        }

        private static void SeedProductBrands(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductBrand>().HasData(
                new ProductBrand { Id = 1, Name = "Alpinestars", Description = AlpinestarsDescription },
                new ProductBrand { Id = 2, Name = "BEL-RAY", Description = BelRayDescription },
                new ProductBrand { Id = 3, Name = "Boyesen", Description = BoyesenDescription },
                new ProductBrand { Id = 4, Name = "D.I.D", Description = DIDDescription },
                new ProductBrand { Id = 5, Name = "Galfer", Description = GalferDescription },
                new ProductBrand { Id = 6, Name = "HifloFiltro", Description = HifloFiltroDescription },
                new ProductBrand { Id = 7, Name = "Hinson", Description = HinsonDescription },
                new ProductBrand { Id = 8, Name = "KYB Suspension", Description = KYBDescription },
                new ProductBrand { Id = 9, Name = "Motorex", Description = MotorexDescription },
                new ProductBrand { Id = 10, Name = "MOTUL", Description = MotulDescription },
                new ProductBrand { Id = 11, Name = "Moto-Master", Description = MotoMasterDescription },
                new ProductBrand { Id = 12, Name = "NGK", Description = NGKDescription },
                new ProductBrand { Id = 13, Name = "O'NEAL", Description = ONealDescription },
                new ProductBrand { Id = 14, Name = "Showa", Description = ShowaDescription },
                new ProductBrand { Id = 15, Name = "THOR", Description = ThorDescription },
                new ProductBrand { Id = 16, Name = "Twin Air", Description = TwinAirDescription },
                new ProductBrand { Id = 17, Name = "Vertex", Description = VertexDescription },
                new ProductBrand { Id = 18, Name = "Wiseco", Description = WisecoDescription },
                new ProductBrand { Id = 19, Name = "YAMALUBE", Description = YamalubeDescription } 
            );
        }

        private static void SeedParts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>().HasData(
                // Engine
                new Part { Id = 1, BrandId = 17, Title = "High-Compression Forged Piston", Price = 455.00m, Description = "High-quality forged piston for 4-Stroke motorcycle engines. Rings and pin are included in the set.", IsAvailable = true, StockQuantity = 11, Type = PartType.Engine },
                new Part { Id = 2, BrandId = 18, Title = "Cast Piston", Price = 325.00m, Description = "High-performance cast piston. Piston rings are not included.", IsAvailable = true, StockQuantity = 6, Type = PartType.Engine },
                new Part { Id = 3, BrandId = 7, Title = "Engine Clutch Cover", Price = 99.99m, Description = "Protective cover for motorcycle engines made of titanium.", IsAvailable = true, StockQuantity = 4, Type = PartType.Engine },
                new Part { Id = 4, BrandId = 3, Title = "Top-End Gasket Set", Price = 89.99m, Description = "Complete gasket set for top-end engine rebuilds and maintenance.", IsAvailable = true, StockQuantity = 31, Type = PartType.Engine },
                new Part { Id = 5, BrandId = 3, Title = "Water Pump Cover", Price = 87.79m, Description = "Enhanced water pump cover for improved cooling efficiency.", IsAvailable = true, StockQuantity = 10, Type = PartType.Engine },
                new Part { Id = 6, BrandId = 12, Title = "8-Point Fuel Injector", Price = 289.99m, Description = "High-flow fuel injector for increased horsepower, throttle response and fuel efficiency.", IsAvailable = true, StockQuantity = 3, Type = PartType.Engine },
                new Part { Id = 7, BrandId = 17, Title = "Intake Valves Set", Price = 139.29m, Description = "A set of two high-quality intake valves that exceed OEM quality.", IsAvailable = true, StockQuantity = 7, Type = PartType.Engine },
                new Part { Id = 8, BrandId = 18, Title = "Fuel Pump", Price = 149.99m, Description = "Electric fuel pump for replacing the old one. Comes with all necessary components.", IsAvailable = true, StockQuantity = 12, Type = PartType.Engine },

                // Filter
                new Part { Id = 9, BrandId = 16, Title = "Air Filter", Price = 24.49m, Description = "Premium air filter for improved air flow and engine performance.", IsAvailable = true, StockQuantity = 27, Type = PartType.Filter },
                new Part { Id = 10, BrandId = 6, Title = "Oil Filter", Price = 10.99m, Description = "High-quality oil filter for efficient filtration and engine longevity.", IsAvailable = true, StockQuantity = 19, Type = PartType.Filter },
                new Part { Id = 11, BrandId = 16, Title = "Aluminium Oil Filter Cap", Price = 54.29m, Description = "High-quality oil filter for efficient filtration and engine longevity.", IsAvailable = true, StockQuantity = 8, Type = PartType.Filter },
                new Part { Id = 12, BrandId = 16, Title = "Fuel Filter (Gas Tank)", Price = 50.99m, Description = "Custom shaped adaptor for each model that fits securely under the gas cap, creating a leak-proof seal", IsAvailable = true, StockQuantity = 5, Type = PartType.Filter },

                // Brake
                new Part { Id = 13, BrandId = 5, Title = "Sintered Front Brake Pads", Price = 35.89m, Description = "Replacement brake pads offering reliable stopping performance.", IsAvailable = true, StockQuantity = 20, Type = PartType.Brake },
                new Part { Id = 14, BrandId = 11, Title = "Aluminium Brake Lever", Price = 71.99m, Description = "Comfortable and durable lever, made out of aluminium for improved control and comfort.", IsAvailable = true, StockQuantity = 14, Type = PartType.Brake },
                new Part { Id = 15, BrandId = 11, Title = "Front Brake Disc", Price = 89.99m, Description = "High-performance brake disc for superior stopping power.", IsAvailable = true, StockQuantity = 1, Type = PartType.Brake },
                new Part { Id = 16, BrandId = 11, Title = "Rear Brake Disc", Price = 77.29m, Description = "High-performance brake disc for superior stopping power.", IsAvailable = true, StockQuantity = 7, Type = PartType.Brake },

                // Suspension
                new Part { Id = 17, BrandId = 14, Title = "Shock Absorber", Price = 799.19m, Description = "Precision-engineered shock absorber for smooth ride experience.", IsAvailable = true, StockQuantity = 3, Type = PartType.Suspension },
                new Part { Id = 18, BrandId = 14, Title = "Front Fork Springs", Price = 429.99m, Description = "Upgraded front fork springs for improved suspension response and handling. Set of two.", IsAvailable = true, StockQuantity = 5, Type = PartType.Suspension },
                new Part { Id = 19, BrandId = 8, Title = "Fork Seal Kit", Price = 44.99m, Description = "Seal kit for motorcycle forks to prevent leaks and maintain suspension performance.", IsAvailable = true, StockQuantity = 18, Type = PartType.Suspension },
                new Part { Id = 20, BrandId = 8, Title = "HI-C Shock Absorber", Price = 1404.49m, Description = "The latest KYB technology is used to develop this shock, used by Yamaha Factory Racing drivers.", IsAvailable = true, StockQuantity = 2, Type = PartType.Suspension },
                new Part { Id = 21, BrandId = 14, Title = "Steering Stem Bearing Kit", Price = 125.50m, Description = "Designed as a drop-in replacement to upgrade OEM ball-type bearings to taper bearings.", IsAvailable = true, StockQuantity = 6, Type = PartType.Suspension },

                // Drivetrain
                new Part { Id = 22, BrandId = 4, Title = "114-Links Chain", Price = 119.99m, Description = "Durable motorcycle chain for smooth power transfer.", IsAvailable = true, StockQuantity = 10, Type = PartType.Drivetrain },
                new Part { Id = 23, BrandId = 4, Title = "120-Links Chain", Price = 129.99m, Description = "Durable motorcycle chain for smooth power transfer.", IsAvailable = true, StockQuantity = 7, Type = PartType.Drivetrain },
                new Part { Id = 24, BrandId = 4, Title = "52-Teeth Rear Sprocket", Price = 89.79m, Description = "Durable motorcycle chain for smooth power transfer.", IsAvailable = true, StockQuantity = 4, Type = PartType.Drivetrain },
                new Part { Id = 25, BrandId = 4, Title = "13-Teeth Front Sprocket", Price = 24.19m, Description = "Durable motorcycle chain for smooth power transfer.", IsAvailable = true, StockQuantity = 13, Type = PartType.Drivetrain },
                new Part { Id = 26, BrandId = 7, Title = "Complete Clutch Kit", Price = 2149.99m, Description = "Complete clutch kit for enhanced performance and durability.", IsAvailable = true, StockQuantity = 3, Type = PartType.Drivetrain },
                new Part { Id = 27, BrandId = 17, Title = "Clutch Plate Kit", Price = 339.69m, Description = "Complete clutch plate kit with friction plates and steel plates for smooth engagement.", IsAvailable = true, StockQuantity = 8, Type = PartType.Drivetrain }
            );
        }

        private static void SeedProductProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartSpecification>().HasData(
                //Material
                new PartSpecification { Id = 1, Name = "Material", Value = "Aluminium", PartId = 1 },
                new PartSpecification { Id = 2, Name = "Material", Value = "Titanium", PartId = 1 },
                new PartSpecification { Id = 3, Name = "Material", Value = "Foam", PartId = 1 },
                new PartSpecification { Id = 4, Name = "Material", Value = "Ferodo", PartId = 1 },
                new PartSpecification { Id = 5, Name = "Material", Value = "Impregnated Cork", PartId = 1 },
                new PartSpecification { Id = 6, Name = "Material", Value = "Steel", PartId = 2 },

                //Manufacture Method
                new PartSpecification { Id = 7, Name = "Manufacture Method", Value = "Cast", PartId = 1 },
                new PartSpecification { Id = 8, Name = "Manufacture Method", Value = "Forged", PartId = 1 },

                //Color
                new PartSpecification { Id = 9, Name = "Color", Value = "Red", PartId = 1 },
                new PartSpecification { Id = 10, Name = "Color", Value = "Blue", PartId = 1 },
                new PartSpecification { Id = 11, Name = "Color", Value = "Green", PartId = 1 },
                new PartSpecification { Id = 12, Name = "Color", Value = "Orange", PartId = 1 },
                new PartSpecification { Id = 13, Name = "Color", Value = "White", PartId = 1 },
                new PartSpecification { Id = 14, Name = "Color", Value = "Dark Gray", PartId = 1 },
                new PartSpecification { Id = 15, Name = "Color", Value = "Black", PartId = 1 },

                //Piston Diameter
                new PartSpecification { Id = 16, Name = "Piston Diameter", Value = "74.96mm", PartId = 1 },
                new PartSpecification { Id = 17, Name = "Piston Diameter", Value = "74.98mm", PartId = 1 },
                new PartSpecification { Id = 18, Name = "Piston Diameter", Value = "75.00mm", PartId = 1 },
                new PartSpecification { Id = 19, Name = "Piston Diameter", Value = "88.96mm", PartId = 1 },
                new PartSpecification { Id = 20, Name = "Piston Diameter", Value = "88.98mm", PartId = 1 },
                new PartSpecification { Id = 21, Name = "Piston Diameter", Value = "89.00mm", PartId = 1 },

                //Spring Rate
                new PartSpecification { Id = 22, Name = "Spring Rate", Value = "4.2kg/mm", PartId = 2 },
                new PartSpecification { Id = 23, Name = "Spring Rate", Value = "4.6kg/mm", PartId = 2 },
                new PartSpecification { Id = 24, Name = "Spring Rate", Value = "5.0kg/mm", PartId = 2 },

                //Disc Diameter
                new PartSpecification { Id = 25, Name = "Disc Diameter", Value = "240mm", PartId = 2 },
                new PartSpecification { Id = 26, Name = "Disc Diameter", Value = "270mm", PartId = 2 },

                //Seal Fitment
                new PartSpecification { Id = 27, Name = "Seal Fitment", Value = "48mm", PartId = 2 },
                new PartSpecification { Id = 28, Name = "Seal Fitment", Value = "50mm", PartId = 2 },

                //Oil Viscosity
                //new PartProperty { Id = 29, Name = "Viscosity", Value = "5W", OilId = 4 },
                //new PartProperty { Id = 30, Name = "Viscosity", Value = "10W40", OilId = 3 },
                //new PartProperty { Id = 31, Name = "Viscosity", Value = "10W40", OilId = 7 },
                //new PartProperty { Id = 32, Name = "Viscosity", Value = "15W60", OilId = 2 }
            );
        }

        private static void SeedOils(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Oil>().HasData(
                new Oil { Id = 1, BrandId = 9, Title = "2T Cross Power", Price = 28.99m, Description = "Premium 2-stroke oil for motorcycle engines.", IsAvailable = true, StockQuantity = 30, Type = OilType.Stroke2, PackageSize = 1.0 },
                new Oil { Id = 2, BrandId = 10, Title = "300V 15W60 1L", Price = 34.99m, Description = "Ester Core Premium 4-stroke oil for motorcycle engines.", IsAvailable = true, StockQuantity = 12, Type = OilType.Stroke4, PackageSize = 1.0 },
                new Oil { Id = 3, BrandId = 10, Title = "300V 10W40 4L", Price = 114.99m, Description = "Ester Core Premium 4-stroke oil for motorcycle engines.", IsAvailable = true, StockQuantity = 3, Type = OilType.Stroke4, PackageSize = 4.0 },
                new Oil { Id = 4, BrandId = 2, Title = "Fork Oil 5W", Price = 27.00m, Description = "Lightweight fork oil for smoother suspension stroke.", IsAvailable = true, StockQuantity = 8, Type = OilType.Suspension, PackageSize = 0.500 },
                new Oil { Id = 5, BrandId = 9, Title = "Performance Line: Shock Oil", Price = 29.99m, Description = "Performance Line Oils Series is used by MXGP Factory teams.", IsAvailable = true, StockQuantity = 8, Type = OilType.Suspension, PackageSize = 0.750 },
                new Oil { Id = 6, BrandId = 19, Title = "YAMALUBE 10W40", Price = 26.29m, Description = "The baseline 4-stroke engine oil for motorcycles.", IsAvailable = true, StockQuantity = 14, Type = OilType.Stroke4, PackageSize = 1.5 },
                new Oil { Id = 7, BrandId = 10, Title = "MotoCool -35°C 1L", Price = 26.29m, Description = "The baseline 4-stroke engine oil for motorcycles.", IsAvailable = true, StockQuantity = 14, Type = OilType.Coolant, PackageSize = 1.0 }
            );
        }

        private static void SeedGears(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gear>().HasData(
                new Gear { Id = 1, BrandId = 6, Title = "Helmet", Size = GearSize.M, Price = 99.99m, Description = "Premium motorcycle helmet for maximum protection.", IsAvailable = true, StockQuantity = 5, Type = GearType.Helmet },
                new Gear { Id = 2, BrandId = 7, Title = "Protective Jacket", Size = GearSize.L, Price = 149.99m, Description = "Durable protective jacket for safe riding.", IsAvailable = true, StockQuantity = 7, Type = GearType.ProtectiveGear }
            );
        }
    }
}