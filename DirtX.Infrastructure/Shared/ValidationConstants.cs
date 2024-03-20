namespace DirtX.Infrastructure.Shared
{
    public static class ValidationConstants
    {
        // MOTORCYCLE AND USED MOTORCYCLE CONSTANTS
        public const int MakeTitleMinLength = 2;
        public const int MakeTitleMaxLength = 100;

        public const int ModelTitleMinLength = 2;
        public const int ModelTitleMaxLength = 100;

        public const int EngineVolumeMin = 0;
        public const int EngineVolumeMax = 1500;

        public const int YearMinRange = 1980;
        public const int YearMaxRange = 2025;

        public const int UsedMotoMinPrice = 100;
        public const int UsedMotoMaxPrice = 99000;
        public const int UsedMotoImageMaxSize = 1048576;
        public const int UsedMotoDescriptionMinLength = 25;
        public const int UsedMotoDescriptionMaxLength = 5000;
        public const string UsedMotoContactRegEx = @"^08\d{8}$";

        // PRODUCT CONSTANTS
        public const int ProductTitleMinLength = 2;
        public const int ProductTitleMaxLength = 100;
        public const string ProductMinPrice = "0";
        public const string ProductMaxPrice = "99000";
        public const int ProductDescriptionMinLength = 25;
        public const int ProductDescriptionMaxLength = 5000;
        public const int ProductImageMaxSize = 1048576;

        // PRODUCT BRAND
        public const int BrandNameMinLength = 1;
        public const int BrandNameMaxLength = 100;
        public const int BrandDescriptionMinLength = 25;
        public const int BrandDescriptionMaxLength = 3000;
        public const int BrandImageMaxSize = 1048576;

        // OIL SPECIFIC CONSTANTS
        public const int OilPackageSizeMin = 0;
        public const int OilPackageSizeMax = 300;

        // SPECIFICATION CONSTANTS
        public const int SpecificationValueMinLength = 1;
        public const int SpecificationValueMaxLength = 50;

        // SPECIFICATION TITLES CONSTANTS
        public const int SpecificationTitleMinLength = 1;
        public const int SpecificationTitleMaxLength = 70;

        // TRAILER AND TRAILER RENT CONSTANTS
        public const int TrailerTypeMinLength = 5;
        public const int TrailerTypeMaxLength = 40;
        public const string TrailerMinCostPerDay = "10";
        public const string TrailerMaxCostPerDay = "100";
        public const int TrailerMinCapacity = 1;
        public const int TrailerMaxCapacity = 5;
        public const int TrailerMinLoad = 100;
        public const int TrailerMaxLoad = 2000;
        public const string TrailerRentMinTotalCost = "10";
        public const string TrailerRentMaxTotalCost = "1000";
        
        /*

         */

        //TODO - ADD ORDER CATEGORY TOOO
    }
}
