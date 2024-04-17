namespace DirtX.Infrastructure.Shared
{
    public static class ValidationConstants
    {
        public const int ImageMaxSize = 1048576;
        public const int ImageMinLength = 3;
        public const int ImageMaxLength = 1000;

        public const int MakeTitleMinLength = 2;
        public const int MakeTitleMaxLength = 100;

        public const int ModelTitleMinLength = 2;
        public const int ModelTitleMaxLength = 100;

        public const int EngineVolumeMin = 0;
        public const int EngineVolumeMax = 2000;

        public const int YearMinRange = 1980;
        public const int YearMaxRange = 2025;

        public const int UsedMotoMinPrice = 100;
        public const int UsedMotoMaxPrice = 99999;
        public const int UsedMotoDescriptionMinLength = 25;
        public const int UsedMotoDescriptionMaxLength = 5000;
        public const string UsedMotoContactRegEx = @"^08\d{8}$";

        public const int ProductTitleMinLength = 2;
        public const int ProductTitleMaxLength = 100;
        public const string ProductMinPrice = "0";
        public const string ProductMaxPrice = "99999";
        public const int ProductDescriptionMinLength = 25;
        public const int ProductDescriptionMaxLength = 5000;
        public const int ProductImageMaxSize = 1048576;
        public const int ProductQtyMin = 1;
        public const int ProductQtyMax = 99;

        public const int BrandNameMinLength = 1;
        public const int BrandNameMaxLength = 100;
        public const int BrandDescriptionMinLength = 25;
        public const int BrandDescriptionMaxLength = 3000;
        public const int BrandImageMaxSize = 1048576;

        public const int ProductTypeTitleMinLength = 2;
        public const int ProductTypeTitleMaxLength = 100;
        public const int ProductTypeDescriptionMinLength = 25;
        public const int ProductTypeDescriptionMaxLength = 1000;

        public const int SpecificationValueMinLength = 1;
        public const int SpecificationValueMaxLength = 50;
        public const int SpecificationTitleMinLength = 1;
        public const int SpecificationTitleMaxLength = 70;

        public const int UserFirstNameMinLength = 1;
        public const int UserFirstNameMaxLength = 99;
        public const int UserLastNameMinLength = 1;
        public const int UserLastNameMaxLength = 99;
        public const int UserCountryMinLength = 1;
        public const int UserCountryMaxLength = 99;
        public const int UserCityMinLength = 1;
        public const int UserCityMaxLength = 99;
        public const int UserAddressMinLength = 1;
        public const int UserAddressMaxLength = 300;

        public const string LengthMustBeBetween = "{0} length must be between {2} and {1}.";
        public const string FieldIsRequired = "The field is required!";
    }
}
