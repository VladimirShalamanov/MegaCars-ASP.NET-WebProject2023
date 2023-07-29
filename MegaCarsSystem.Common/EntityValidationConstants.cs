namespace MegaCarsSystem.Common
{
    public static class EntityValidationConstants
    {
        public class ApplicationUser
        {
            public const int FirstName_MinLength = 2;
            public const int FirstName_MaxLength = 25;

            public const int LastName_MinLength = 2;
            public const int LastName_MaxLength = 25;

            public const int Password_MinLength = 6;
            public const int Password_MaxLength = 100;
        }

        public class Dealer
        {
            public const int PhoneNumber_MinLength = 7;
            public const int PhoneNumber_MaxLength = 15;
        }

        public static class Category
        {
            public const int Name_MinLength = 5;
            public const int Name_MaxLength = 27;
        }

        public static class Engine
        {
            public const int EngineFuel_MinLength = 6;
            public const int EngineFuel_MaxLength = 8;
        }

        public static class Gearbox
        {
            public const int GearName_MinLength = 6;
            public const int GearName_MaxLength = 9;
        }

        public static class Car
        {
            public const int Brand_MinLength = 3;
            public const int Brand_MaxLength = 14;

            public const int Model_MinLength = 3;
            public const int Model_MaxLength = 55;

            public const string YearOfManufacture_RegEx = @"^(\d{4})$";
            public const int YearOfManufacture_MinValue = 1950;

            public const int Horsepower_MinValue = 20;
            public const int Horsepower_MaxValue = 5000;

            public const int Address_MinLength = 15;
            public const int Address_MaxLength = 150;

            public const int Description_MinLength = 50;
            public const int Description_MaxLength = 1000;

            public const int ImageUrl_MaxLength = 2048;

            public const string PricePerDay_MinValue = "0";
            public const string PricePerDay_MaxValue = "5000";
        }

        public static class Product
        {
            public const int Name_MaxLength = 40;

            public const int Description_MaxLength = 1000;

            public const int Image_MaxLength = 2048;

            public const string Price_MinValue = "0";
            public const string Price_MaxValue = "1000";
        }

        public static class Item
        {
            public const int Name_MaxLength = 40;

            public const int Image_MaxLength = 2048;

            public const string Price_MinValue = "0";
            public const string Price_MaxValue = "1000";
        }
    }
}