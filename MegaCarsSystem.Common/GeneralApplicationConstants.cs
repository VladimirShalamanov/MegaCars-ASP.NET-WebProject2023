namespace MegaCarsSystem.Common
{
    public static class GeneralApplicationConstants
    {
        public const int ReleaseYear = 2023;

        // Products_Orders_Shipping
        public const decimal MinSumForFreeOrder = 50.00m;
        public const decimal Delivery = 5.00m;
        public const string PromoCodes = "summer20";

        // For the sorting part of the Аpp.
        public const int DefaultPage = 1;
        public const int EntitiesPerPage = 3;

        // Middleware
        public const string OnlineUsersCookieName = "IsOnline";
        public const int LastActivityMinutes_BeforeOffline = 10;

        // For implementation of User
        public const string UserId = "2c5628be-a8ca-4cf0-bc0d-c441e6aa0c6e";
        public const string UserFirstName = "User";
        public const string UserLastName = "Guest_Test";
        public const string UserEmail = "user@user.com";
        public const string UserPassword = "user1122";
        public const string UserShoppingCartId = "88856b35-f932-4a23-9baf-2a8974418b22";

        // For implementation of Dealer
        public const string UserDealerId = "993dc891-f1ee-4b53-984d-3a019f294bfd";
        public const string DealerId = "4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3";
        public const string DealerFirstName = "Dealer";
        public const string DealerLastName = "DeIsHere_Test";
        public const string DealerEmail = "dealer@dealer.com";
        public const string DealerPassword = "dealer1122";
        public const string DealerShoppingCartId = "61be485b-f019-4fd6-9c43-07f5aa896895";

        // For implementation of Admin
        public const string UserDealerId_Development = "bcbd7654-ab17-4621-b75b-fc43ea4449db";
        public const string DealerAdminId_Development = "d08e602f-3c3f-4391-aaf6-b4867a639c13";
        public const string AdminFirstName_Development = "Admin";
        public const string AdminLastName_Development = "AdIsHere_Test";
        public const string AdminEmail_Development = "admin@admin.com";
        public const string AdminPassword_Development = "admin1122";
        public const string AdminShoppingCartId_Development = "1bca46f0-2eb4-43c7-8a76-7b006ceb109a";

        // Role_Admin
        public const string AdminAreaName = "Admin";
        public const string AdminRoleName = "Administrator";


        // Memory Caching
        public const string UsersCacheKey = "UsersCache";
        public const string RentsCacheKey = "RentsCache";

        public const int UsersCacheDurationMinutes = 5;
        public const int RentsCacheDurationMinutes = 10;
    }
}