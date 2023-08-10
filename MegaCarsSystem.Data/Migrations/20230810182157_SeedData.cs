using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaCarsSystem.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("6082f25d-aee4-414e-80e2-4abed39275a4"), "Black T-shirt with great quality.", "https://images-na.ssl-images-amazon.com/images/I/61oFHwCIKrL._SLDPMOBCAROUSELAUTOCROP288221_MCnd_AC_SR462,693_.jpg", "T-shirt Supercar", 18.00m },
                    { new Guid("64ba4529-de18-4017-8876-d1714cac6092"), "Мetal key holder for your keys.", "https://i.etsystatic.com/13582943/r/il/2f99a2/1700229685/il_fullxfull.1700229685_ooj3.jpg", "Keychain Turbine", 5.00m }
                });

            migrationBuilder.InsertData(
                table: "ShopCarts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("1bca46f0-2eb4-43c7-8a76-7b006ceb109a"), new Guid("bcbd7654-ab17-4621-b75b-fc43ea4449db") },
                    { new Guid("61be485b-f019-4fd6-9c43-07f5aa896895"), new Guid("993dc891-f1ee-4b53-984d-3a019f294bfd") },
                    { new Guid("88856b35-f932-4a23-9baf-2a8974418b22"), new Guid("2c5628be-a8ca-4cf0-bc0d-c441e6aa0c6e") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShoppingCartId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2c5628be-a8ca-4cf0-bc0d-c441e6aa0c6e"), 0, "e4168580-1382-49e0-9fdb-a16d806d588a", "user@user.com", false, "User", "Guest_Test", false, null, "user@user.com", "user@user.com", "AQAAAAEAACcQAAAAECfZNQL78Rt6ocXoYvKX2/6rN9yoiWVZFIBTDU+WVEwpwdX+zZ6VpCd6fJkW7+KjFw==", null, false, "1d221c9b-6ee1-4b03-8772-83ce22647537", new Guid("88856b35-f932-4a23-9baf-2a8974418b22"), false, "user@user.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShoppingCartId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("993dc891-f1ee-4b53-984d-3a019f294bfd"), 0, "45b7836c-f716-46e0-955e-d97f417f6c37", "dealer@dealer.com", false, "Dealer", "DeIsHere_Test", false, null, "dealer@dealer.com", "dealer@dealer.com", "AQAAAAEAACcQAAAAEFiqDjyprlMVHu0iieRmLXYoov3T4vpy+CyXV7prWxrt+f57UYgKK2faYDP+oFL7zw==", null, false, "d58ac461-599e-4b09-ad08-8b2c3c595464", new Guid("61be485b-f019-4fd6-9c43-07f5aa896895"), false, "dealer@dealer.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShoppingCartId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("bcbd7654-ab17-4621-b75b-fc43ea4449db"), 0, "bf005e36-373d-4c06-8bab-4ab46e53152d", "admin@admin.com", false, "Admin", "AdIsHere_Test", false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEIopKxya5J7+HHCZVoZgconaGTYi/LHxaKySdvoyr5pb6+RnmJ8fsPb/XQV/x8ruLA==", null, false, "bfeb9457-e377-4772-9bd4-a8360d9735f5", new Guid("1bca46f0-2eb4-43c7-8a76-7b006ceb109a"), false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "+359888777666", new Guid("993dc891-f1ee-4b53-984d-3a019f294bfd") });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("d08e602f-3c3f-4391-aaf6-b4867a639c13"), "+359333222111", new Guid("bcbd7654-ab17-4621-b75b-fc43ea4449db") });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "Brand", "CategoryId", "DealerId", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[] { new Guid("2aad0c39-ee7f-49e6-b583-1c2d9507739f"), "Boyana Neighbourhood, Sofia, Bulgaria", "McLaren", 6, new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "This is a sports car and is recommended to be driven carefully.", 2, 2, 560, "https://edge.pxcrush.net/cars/dealer/dro0hrehxv0n0250f55sf7nqy.jpg?pxc_expires=20231101025101&pxc_clear=1&pxc_signature=2e0f693b59a609c1f0f77e21ed5fbfed", "720S", 1500.00m, null, 2016 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "Brand", "CategoryId", "DealerId", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[] { new Guid("7883647f-d64b-4271-908a-95689d532ff5"), "Boyana Neighbourhood, Sofia, Bulgaria", "Toyota", 3, new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "The car is a sports coupe type and is convenient for maneuvering in urban conditions.", 1, 1, 430, "https://performancedrive.com.au/wp-content/uploads/2020/02/2020-Toyota-GR-Supra-GT-scaled.jpg", "Supra", 900.00m, null, 2020 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c5628be-a8ca-4cf0-bc0d-c441e6aa0c6e"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("2aad0c39-ee7f-49e6-b583-1c2d9507739f"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("7883647f-d64b-4271-908a-95689d532ff5"));

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: new Guid("d08e602f-3c3f-4391-aaf6-b4867a639c13"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6082f25d-aee4-414e-80e2-4abed39275a4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64ba4529-de18-4017-8876-d1714cac6092"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bcbd7654-ab17-4621-b75b-fc43ea4449db"));

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"));

            migrationBuilder.DeleteData(
                table: "ShopCarts",
                keyColumn: "Id",
                keyValue: new Guid("88856b35-f932-4a23-9baf-2a8974418b22"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("993dc891-f1ee-4b53-984d-3a019f294bfd"));

            migrationBuilder.DeleteData(
                table: "ShopCarts",
                keyColumn: "Id",
                keyValue: new Guid("1bca46f0-2eb4-43c7-8a76-7b006ceb109a"));

            migrationBuilder.DeleteData(
                table: "ShopCarts",
                keyColumn: "Id",
                keyValue: new Guid("61be485b-f019-4fd6-9c43-07f5aa896895"));
        }
    }
}
