using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Products;
using Microsoft.EntityFrameworkCore;
using static DirtX.Infrastructure.Shared.SeederConstants;

namespace DirtX.Infrastructure.Data.Seeders
{
    public static class ProductSeeder
    {
        public static void SeedProducts(ModelBuilder modelBuilder)
        {
            SeedProductCategories(modelBuilder);
            SeedProductBrands(modelBuilder);
            SeedPropertyTitles(modelBuilder);
            SeedProductProperties(modelBuilder);

            SeedAllProducts(modelBuilder);
        }

        private static void SeedProductCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name = "Part", Description = PartCategoryDescription },
                new ProductType { Id = 2, Name = "Oil", Description = OilCategoryDescription },
                new ProductType { Id = 3, Name = "Gear", Description = GearCategoryDescription }
            );
        }

        private static void SeedProductBrands(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductBrand>().HasData(
                new ProductBrand { Id = 1, Name = "Alpinestars", Description = AlpinestarsDescription, ImageUrl = AlpinestarsImage },
                new ProductBrand { Id = 2, Name = "BEL-RAY", Description = BelRayDescription, ImageUrl = BelRayImage },
                new ProductBrand { Id = 3, Name = "Boyesen", Description = BoyesenDescription, ImageUrl = BoyesenImage },
                new ProductBrand { Id = 4, Name = "D.I.D", Description = DidDescription, ImageUrl = DidImage },
                new ProductBrand { Id = 5, Name = "Galfer", Description = GalferDescription, ImageUrl = GalferImage },
                new ProductBrand { Id = 6, Name = "HifloFiltro", Description = HifloFiltroDescription, ImageUrl = HifloFiltroImage },
                new ProductBrand { Id = 7, Name = "Hinson", Description = HinsonDescription, ImageUrl = HinsonImage },
                new ProductBrand { Id = 8, Name = "KYB", Description = KybDescription, ImageUrl = KybImage },
                new ProductBrand { Id = 9, Name = "Motorex", Description = MotorexDescription, ImageUrl = MotorexImage },
                new ProductBrand { Id = 10, Name = "MOTUL", Description = MotulDescription, ImageUrl = MotulImage },
                new ProductBrand { Id = 11, Name = "Moto-Master", Description = MotoMasterDescription, ImageUrl = MotoMasterImage },
                new ProductBrand { Id = 12, Name = "NGK", Description = NgkDescription, ImageUrl = NgkImage },
                new ProductBrand { Id = 13, Name = "O'NEAL", Description = OnealDescription, ImageUrl = OnealImage },
                new ProductBrand { Id = 14, Name = "Showa", Description = ShowaDescription, ImageUrl = ShowaImage },
                new ProductBrand { Id = 15, Name = "THOR", Description = ThorDescription, ImageUrl = ThorImage },
                new ProductBrand { Id = 16, Name = "Twin Air", Description = TwinAirDescription, ImageUrl = TwinAirImage },
                new ProductBrand { Id = 17, Name = "Vertex", Description = VertexDescription, ImageUrl = VertexImage },
                new ProductBrand { Id = 18, Name = "Wiseco", Description = WisecoDescription, ImageUrl = WisecoImage },
                new ProductBrand { Id = 19, Name = "YAMALUBE", Description = YamalubeDescription, ImageUrl = YamalubeImage } 
            );
        }

        private static void SeedPropertyTitles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpecificationTitle>().HasData(
                new SpecificationTitle { Id = 1, Title = "Material" },
                new SpecificationTitle { Id = 2, Title = "Manufacture Method" },
                new SpecificationTitle { Id = 3, Title = "Color" },
                new SpecificationTitle { Id = 4, Title = "Diameter" },
                new SpecificationTitle { Id = 5, Title = "Spring Rate" },
                new SpecificationTitle { Id = 6, Title = "Seal Fitment" },
                new SpecificationTitle { Id = 7, Title = "Viscosity" },
                new SpecificationTitle { Id = 8, Title = "Package" },
                new SpecificationTitle { Id = 9, Title = "Size" }
            );
        }

        private static void SeedProductProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specification>().HasData(
                new Specification { Id = 1, TitleId = 1, Value = "Aluminum" },
                new Specification { Id = 2, TitleId = 1, Value = "Titanium" },
                new Specification { Id = 3, TitleId = 1, Value = "Foam" },
                new Specification { Id = 4, TitleId = 1, Value = "Ferodo" },
                new Specification { Id = 5, TitleId = 1, Value = "Impregnated Cork" },
                new Specification { Id = 6, TitleId = 1, Value = "Steel" },
                new Specification { Id = 7, TitleId = 2, Value = "Cast" },
                new Specification { Id = 8, TitleId = 2, Value = "Forged" },
                new Specification { Id = 9, TitleId = 3, Value = "Red" },
                new Specification { Id = 10, TitleId = 3, Value = "Blue" },
                new Specification { Id = 11, TitleId = 3, Value = "Green" },
                new Specification { Id = 12, TitleId = 3, Value = "Yellow" },
                new Specification { Id = 13, TitleId = 3, Value = "Orange" },
                new Specification { Id = 14, TitleId = 3, Value = "White" },
                new Specification { Id = 15, TitleId = 3, Value = "Gray" },
                new Specification { Id = 16, TitleId = 3, Value = "Black" },
                new Specification { Id = 17, TitleId = 4, Value = "74.98mm" },
                new Specification { Id = 18, TitleId = 4, Value = "75.00mm" },
                new Specification { Id = 19, TitleId = 4, Value = "88.96mm" },
                new Specification { Id = 20, TitleId = 4, Value = "88.98mm" },
                new Specification { Id = 21, TitleId = 4, Value = "89.00mm" },
                new Specification { Id = 22, TitleId = 5, Value = "4.2kg/mm" },
                new Specification { Id = 23, TitleId = 5, Value = "4.6kg/mm" },
                new Specification { Id = 24, TitleId = 5, Value = "5.0kg/mm" },
                new Specification { Id = 25, TitleId = 4, Value = "220mm" },
                new Specification { Id = 26, TitleId = 4, Value = "270mm" },
                new Specification { Id = 27, TitleId = 6, Value = "48mm" },
                new Specification { Id = 28, TitleId = 6, Value = "50mm" },
                new Specification { Id = 29, TitleId = 7, Value = "5W" },
                new Specification { Id = 30, TitleId = 7, Value = "10W40" },
                new Specification { Id = 31, TitleId = 7, Value = "15W60" },
                new Specification { Id = 32, TitleId = 1, Value = "Polyester Mesh" },
                new Specification { Id = 33, TitleId = 1, Value = "Cotton" },
                new Specification { Id = 34, TitleId = 8, Value = "1L" },
                new Specification { Id = 35, TitleId = 8, Value = "4L" },
                new Specification { Id = 36, TitleId = 8, Value = "0.5L" },
                new Specification { Id = 37, TitleId = 8, Value = "0.75L" },
                new Specification { Id = 38, TitleId = 8, Value = "S" },
                new Specification { Id = 39, TitleId = 8, Value = "M" },
                new Specification { Id = 40, TitleId = 8, Value = "L" },
                new Specification { Id = 41, TitleId = 8, Value = "43" },
                new Specification { Id = 42, TitleId = 8, Value = "45" }
            );
        }

        private static void SeedAllProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                // Engine
                new Product { Id = 1, BrandId = 17, TypeId = 1, Title = "High-Compression Forged Piston", Price = 455.00m, Description = "High-quality forged piston for 4-Stroke motorcycle engines. Rings and pin are included in the set.", IsAvailable = true, StockQuantity = 11, Category = ProductCategory.Engine, ImageUrl = "https://i.ibb.co/jTnS3W0/Product-High-Comp-Piston.jpg" },
                new Product { Id = 2, BrandId = 18, TypeId = 1, Title = "Cast Piston", Price = 325.00m, Description = "High-performance cast piston. Piston rings are not included.", IsAvailable = true, StockQuantity = 6, Category = ProductCategory.Engine, ImageUrl = "https://i.ibb.co/m6fQKSx/Product-Forged-Piston.jpg" },
                new Product { Id = 3, BrandId = 7, TypeId = 1, Title = "Engine Clutch Cover", Price = 99.99m, Description = "Protective cover for motorcycle engines made of titanium.", IsAvailable = true, StockQuantity = 4, Category = ProductCategory.Engine, ImageUrl = "https://i.ibb.co/1RXqkVy/Product-Engine-Cover.png" },
                new Product { Id = 4, BrandId = 3, TypeId = 1, Title = "Top-End Gasket Set", Price = 89.99m, Description = "Complete gasket set for top-end engine rebuilds and maintenance.", IsAvailable = true, StockQuantity = 31, Category = ProductCategory.Engine, ImageUrl = "https://i.ibb.co/Yj4MJ6r/Product-Top-End-Gasket.jpg" },
                new Product { Id = 5, BrandId = 3, TypeId = 1, Title = "Water Pump Cover", Price = 87.79m, Description = "Enhanced water pump cover for improved cooling efficiency.", IsAvailable = true, StockQuantity = 10, Category = ProductCategory.Engine, ImageUrl = "https://i.ibb.co/ZHQ36hf/Product-Water-Pump-Cover.jpg" },
                new Product { Id = 6, BrandId = 12, TypeId = 1, Title = "8-Point Fuel Injector", Price = 289.99m, Description = "High-flow fuel injector for increased horsepower, throttle response and fuel efficiency.", IsAvailable = true, StockQuantity = 3, Category = ProductCategory.Engine, ImageUrl = "https://i.ibb.co/dmkcV30/Product-Fuel-Injector.jpg" },
                new Product { Id = 7, BrandId = 17, TypeId = 1, Title = "Intake Valves Set", Price = 139.29m, Description = "A set of two high-quality intake valves that exceed OEM quality.", IsAvailable = true, StockQuantity = 7, Category = ProductCategory.Engine, ImageUrl = "https://i.ibb.co/fG9XLdn/Product-Intake-Valves.jpg" },
                new Product { Id = 8, BrandId = 18, TypeId = 1, Title = "Fuel Pump", Price = 149.99m, Description = "Electric fuel pump for replacing the old one. Comes with all necessary components.", IsAvailable = true, StockQuantity = 12, Category = ProductCategory.Engine, ImageUrl = "https://i.ibb.co/LnW1Y4k/Product-Fuel-Pump.jpg" },

                // Filter
                new Product { Id = 9, BrandId = 16, TypeId = 1, Title = "Air Filter", Price = 24.49m, Description = "Premium air filter for improved air flow and engine performance.", IsAvailable = true, StockQuantity = 27, Category = ProductCategory.Filters, ImageUrl = "https://i.ibb.co/vqg672F/Product-Air-Filter.jpg" },
                new Product { Id = 10, BrandId = 6, TypeId = 1, Title = "Product Filter", Price = 10.99m, Description = "High-quality oil filter for efficient filtration and engine longevity.", IsAvailable = true, StockQuantity = 19, Category = ProductCategory.Filters, ImageUrl = "https://i.ibb.co/kG1KnVN/Product-Product-Filter.jpg" },
                new Product { Id = 11, BrandId = 16, TypeId = 1, Title = "Aluminum Product Filter Cap", Price = 54.29m, Description = "High-quality oil filter for efficient filtration and engine longevity.", IsAvailable = true, StockQuantity = 8, Category = ProductCategory.Filters, ImageUrl = "https://i.ibb.co/V2qj6c0/Product-Product-Filter-Cap.jpg" },
                new Product { Id = 12, BrandId = 16, TypeId = 1, Title = "Fuel Filter (Gas Tank)", Price = 50.99m, Description = "Custom shaped adaptor for each model that fits securely under the gas cap, creating a leak-proof seal.", IsAvailable = true, StockQuantity = 5, Category = ProductCategory.Filters, ImageUrl = "https://i.ibb.co/s1YdYwt/Product-Fuel-Filter-Tank.jpg" },

                // Brake
                new Product { Id = 13, BrandId = 5, TypeId = 1, Title = "Sintered Front Brake Pads", Price = 35.89m, Description = "Replacement brake pads offering reliable stopping performance.", IsAvailable = true, StockQuantity = 20, Category = ProductCategory.Braking_System, ImageUrl = "https://i.ibb.co/tc2m4jh/Product-Brake-Pads.jpg" },
                new Product { Id = 14, BrandId = 11, TypeId = 1, Title = "Aluminum Brake Lever", Price = 71.99m, Description = "Comfortable and durable lever, made out of aluminum for improved control and comfort.", IsAvailable = true, StockQuantity = 14, Category = ProductCategory.Braking_System, ImageUrl = "https://i.ibb.co/1RqcRGm/Product-Brake-Lever.jpg" },
                new Product { Id = 15, BrandId = 11, TypeId = 1, Title = "Front Brake Disc", Price = 89.99m, Description = "High-performance brake disc for superior stopping power.", IsAvailable = true, StockQuantity = 1, Category = ProductCategory.Braking_System, ImageUrl = "https://i.ibb.co/DG6HpM4/Product-Front-Brake-Disc.jpg" },
                new Product { Id = 16, BrandId = 11, TypeId = 1, Title = "Rear Brake Disc", Price = 77.29m, Description = "High-performance brake disc for superior stopping power.", IsAvailable = true, StockQuantity = 7, Category = ProductCategory.Braking_System, ImageUrl = "https://i.ibb.co/BNPMF26/Product-Rear-Brake-Disc.jpg" },

                // Suspension
                new Product { Id = 17, BrandId = 14, TypeId = 1, Title = "Shock Absorber", Price = 799.19m, Description = "Precision-engineered shock absorber for smooth ride experience.", IsAvailable = true, StockQuantity = 3, Category = ProductCategory.Suspension, ImageUrl = "https://i.ibb.co/LRQphRW/Product-Shock-Absorber.jpg" },
                new Product { Id = 18, BrandId = 14, TypeId = 1, Title = "Front Fork Springs", Price = 429.99m, Description = "Upgraded front fork springs for improved suspension response and handling. Set of two.", IsAvailable = true, StockQuantity = 5, Category = ProductCategory.Suspension, ImageUrl = "https://i.ibb.co/yyZK9tT/Product-Fork-Springs.jpg" },
                new Product { Id = 19, BrandId = 8, TypeId = 1, Title = "Fork Seal Kit", Price = 44.99m, Description = "Seal kit for motorcycle forks to prevent leaks and maintain suspension performance.", IsAvailable = true, StockQuantity = 18, Category = ProductCategory.Suspension, ImageUrl = "https://i.ibb.co/7jy1dvG/Product-Fork-Seals.jpg" },
                new Product { Id = 20, BrandId = 8, TypeId = 1, Title = "HI-C Shock Absorber", Price = 1404.49m, Description = "The latest KYB technology is used to develop this shock, used by Yamaha Factory Racing drivers.", IsAvailable = true, StockQuantity = 2, Category = ProductCategory.Suspension, ImageUrl = "https://i.ibb.co/LtFwYZ3/Product-KYB-Shock.jpg" },
                new Product { Id = 21, BrandId = 14, TypeId = 1, Title = "Steering Stem Bearing Kit", Price = 125.50m, Description = "Designed as a drop-in replacement to upgrade OEM ball-type bearings to taper bearings.", IsAvailable = true, StockQuantity = 6, Category = ProductCategory.Suspension, ImageUrl = "https://i.ibb.co/VCWrYtY/Product-Steering-Bearings.jpg" },

                // Drivetrain
                new Product { Id = 22, BrandId = 4, TypeId = 1, Title = "114-Links Chain", Price = 119.99m, Description = "Durable motorcycle chain for smooth power transfer.", IsAvailable = true, StockQuantity = 10, Category = ProductCategory.Drivetrain, ImageUrl = "https://i.ibb.co/9tCHFWY/Product-Chain.jpg",  },
                new Product { Id = 23, BrandId = 4, TypeId = 1, Title = "120-Links Chain", Price = 129.99m, Description = "Durable motorcycle chain for smooth power transfer.", IsAvailable = true, StockQuantity = 7, Category = ProductCategory.Drivetrain, ImageUrl = "https://i.ibb.co/9tCHFWY/Product-Chain.jpg" },
                new Product { Id = 24, BrandId = 4, TypeId = 1, Title = "52-Teeth Rear Sprocket", Price = 89.79m, Description = "Quality rear sprocked made out of aluminum.", IsAvailable = true, StockQuantity = 4, Category = ProductCategory.Drivetrain, ImageUrl = "https://i.ibb.co/xGz2dVn/Product-Rear-Sprocket.png" },
                new Product { Id = 25, BrandId = 4, TypeId = 1, Title = "13-Teeth Front Sprocket", Price = 24.19m, Description = "Standart-sized front sprocked with self-cleaning properties.", IsAvailable = true, StockQuantity = 13, Category = ProductCategory.Drivetrain, ImageUrl = "https://i.ibb.co/9pKtqn6/Product-Front-Sprocket.jpg" },
                new Product { Id = 26, BrandId = 7, TypeId = 1, Title = "Complete Clutch Kit", Price = 2149.99m, Description = "Complete clutch kit for enhanced performance and durability.", IsAvailable = true, StockQuantity = 3, Category = ProductCategory.Drivetrain, ImageUrl = "https://i.ibb.co/y0KwgV5/Product-Clutch-Kit.jpg" },
                new Product { Id = 27, BrandId = 17, TypeId = 1, Title = "Clutch Plate Kit", Price = 339.69m, Description = "Clutch plate kit with friction plates and steel plates for smooth engagement.", IsAvailable = true, StockQuantity = 8, Category = ProductCategory.Drivetrain, ImageUrl = "https://i.ibb.co/9qGztRG/Product-Clutch-Plates.jpg" },

                // Oils
                new Product { Id = 28, BrandId = 9, TypeId = 2, Title = "2T Cross Power", Price = 28.99m, Description = "Premium 2-stroke oil for motorcycle engines.", IsAvailable = true, StockQuantity = 30, Category = ProductCategory.Two_Stroke, ImageUrl = "https://i.ibb.co/Cm7S8dG/Product-Cross-Power-2-T.jpg" },
                new Product { Id = 29, BrandId = 10, TypeId = 2, Title = "300V 15W60 1L", Price = 34.99m, Description = "Ester Core Premium 4-stroke oil for motorcycle engines.", IsAvailable = true, StockQuantity = 12, Category = ProductCategory.Four_Stroke, ImageUrl = "https://i.ibb.co/9Nyc55B/Product-Motul-300-V-1-L.jpg" },
                new Product { Id = 30, BrandId = 10, TypeId = 2, Title = "300V 10W40 4L", Price = 114.99m, Description = "Ester Core Premium 4-stroke oil for motorcycle engines.", IsAvailable = true, StockQuantity = 3, Category = ProductCategory.Four_Stroke, ImageUrl = "https://i.ibb.co/3ywBxpQ/Product-Motul-300-V-4-L.jpg" },
                new Product { Id = 31, BrandId = 2, TypeId = 2, Title = "Fork Product 5W", Price = 27.00m, Description = "Lightweight fork oil for smoother suspension stroke.", IsAvailable = true, StockQuantity = 8, Category = ProductCategory.Suspension, ImageUrl = "https://i.ibb.co/W52svBD/Product-Bel-Ray-Fork-5-W.jpg" },
                new Product { Id = 32, BrandId = 9, TypeId = 2, Title = "Performance Line: Shock Product", Price = 29.99m, Description = "Performance Line Products Series is used by MXGP Factory teams.", IsAvailable = true, StockQuantity = 8, Category = ProductCategory.Suspension, ImageUrl = "https://i.ibb.co/f1fW4j5/Product-Motorex-Shock-Product.jpg" },
                new Product { Id = 33, BrandId = 19, TypeId = 2, Title = "YAMALUBE 10W40", Price = 26.29m, Description = "The baseline 4-stroke engine oil for motorcycles.", IsAvailable = true, StockQuantity = 14, Category = ProductCategory.Four_Stroke, ImageUrl = "https://i.ibb.co/2dRRzHy/Product-Yamalube-10w40.jpg" },
                new Product { Id = 34, BrandId = 10, TypeId = 2, Title = "AutoCool -35°C 1L", Price = 26.29m, Description = "The most efficient coolant on the market.", IsAvailable = true, StockQuantity = 14, Category = ProductCategory.Coolant, ImageUrl = "https://i.ibb.co/9rgYKcv/Product-Motul-Antifreeze.jpg" },
                new Product { Id = 35, BrandId = 10, TypeId = 2, Title = "TransProduct Expert 10W40", Price = 28.29m, Description = "More throttle, less grinding gears.", IsAvailable = true, StockQuantity = 4, Category = ProductCategory.Transmission, ImageUrl = "https://i.ibb.co/zntBCFg/Product-Transmission-Motul.jpg" },

                // Riding Gear
                new Product { Id = 36, BrandId = 1, TypeId = 3, Title = "SM5", Price = 899.99m, Description = "Alpinestars' premium class lightweight motorcycle helmet for maximum protection.", IsAvailable = true, StockQuantity = 2, Category = ProductCategory.Helmet, ImageUrl = "https://i.ibb.co/rs2c1Pd/Product-SM5-Helmet.jpg" },
                new Product { Id = 37, BrandId = 13, TypeId = 3, Title = "3-Series", Price = 279.99m, Description = "High-quality full-face racing helmet with aerodynamic design.", IsAvailable = true, StockQuantity = 7, Category = ProductCategory.Helmet, ImageUrl = "https://i.ibb.co/YkHnz4F/Product-3-Series-Oneal.jpg" },
                new Product { Id = 38, BrandId = 1, TypeId = 3, Title = "Bionic Action V2", Price = 319.99m, Description = "Durable protective vest for safe riding.", IsAvailable = true, StockQuantity = 4, Category = ProductCategory.Protective_Gear, ImageUrl = "https://i.ibb.co/RhPrZB3/Product-Bionic-Action.jpg" },
                new Product { Id = 39, BrandId = 15, TypeId = 3, Title = "AsteriX Knee Braces", Price = 179.99m, Description = "Knee protection that allows for some movement while protecting the knee cap and shin.", IsAvailable = true, StockQuantity = 10, Category = ProductCategory.Protective_Gear, ImageUrl = "https://i.ibb.co/JrJSf2y/Product-Asterix-Knee.jpg" },
                new Product { Id = 40, BrandId = 13, TypeId = 3, Title = "50th Anniversary Jersey", Price = 79.99m, Description = "Limited anniversary edition jersey.", IsAvailable = true, StockQuantity = 3, Category = ProductCategory.Outfit, ImageUrl = "https://i.ibb.co/bRsz5gz/Product-Jersey-50th.jpg" },
                new Product { Id = 41, BrandId = 15, TypeId = 3, Title = "Prime Ace Complete Outfit", Price = 259.99m, Description = "A complete outfit of THOR's middle-class 'Prime Ace' line.", IsAvailable = true, StockQuantity = 5, Category = ProductCategory.Outfit, ImageUrl = "https://i.ibb.co/hcZKcsB/Product-Thor-Outfit.jpg" },
                new Product { Id = 42, BrandId = 1, TypeId = 3, Title = "Tech10", Price = 1099.99m, Description = "The most advanced riding boots on the market.", IsAvailable = true, StockQuantity = 2, Category = ProductCategory.Boots, ImageUrl = "https://i.ibb.co/pzGDVTv/Product-Tech10-Boots.jpg" },
                new Product { Id = 43, BrandId = 13, TypeId = 3, Title = "Blitz XR", Price = 559.99m, Description = "Motocross/Enduro boots with waterproof lining and reinforced toe.", IsAvailable = true, StockQuantity = 6, Category = ProductCategory.Boots, ImageUrl = "https://i.ibb.co/34RRszr/Product-Blitz-Thor.jpg" },
                new Product { Id = 44, BrandId = 13, TypeId = 3, Title = "B20 Goggles", Price = 129.99m, Description = "Motocross goggles with flippers.", IsAvailable = true, StockQuantity = 6, Category = ProductCategory.Accessory, ImageUrl = "https://i.ibb.co/sHzPG34/Product-B20-Goggles.jpg" },
                new Product { Id = 45, BrandId = 13, TypeId = 3, Title = "Element Gloves", Price = 39.99m, Description = "Universal offroad gloves.", IsAvailable = true, StockQuantity = 11, Category = ProductCategory.Accessory, ImageUrl = "https://i.ibb.co/4Rf2r40/Product-Element-Gloves.jpg" }
            );
        }
    }
}