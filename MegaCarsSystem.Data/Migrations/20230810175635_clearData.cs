using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaCarsSystem.Data.Migrations
{
    public partial class clearData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c5628be-a8ca-4cf0-bc0d-c441e6aa0c6e"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("9944ed88-39e6-4c93-b830-1123d605ad30"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("a0f2c170-7aa4-449a-bb44-58888eae5178"));

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: new Guid("d08e602f-3c3f-4391-aaf6-b4867a639c13"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2b021055-52f6-480d-9a8d-361925b21212"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2c886ce2-11e7-4903-8e28-e9d3f2edaa69"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2b021055-52f6-480d-9a8d-361925b21212"), "Мetal key holder for your keys.", "https://i.etsystatic.com/13582943/r/il/2f99a2/1700229685/il_fullxfull.1700229685_ooj3.jpg", "Keychain Turbine", 5.00m },
                    { new Guid("2c886ce2-11e7-4903-8e28-e9d3f2edaa69"), "Black T-shirt with great quality.", "https://images-na.ssl-images-amazon.com/images/I/61oFHwCIKrL._SLDPMOBCAROUSELAUTOCROP288221_MCnd_AC_SR462,693_.jpg", "T-shirt Supercar", 18.00m }
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
                values: new object[] { new Guid("2c5628be-a8ca-4cf0-bc0d-c441e6aa0c6e"), 0, "7ad9267e-ebfa-49a9-b3a7-115df86978a4", "user@user.com", false, "User", "Guest_Test", false, null, "user@user.com", "user@user.com", "AQAAAAEAACcQAAAAEJiij4YEipau75/IkMyrfx+bg76cIvdlqBc4PC4DMnzy2RK40s6fNhcue6KolYNU0A==", null, false, "de246e87-5cb3-4858-8840-bb81dfb0da42", new Guid("88856b35-f932-4a23-9baf-2a8974418b22"), false, "user@user.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShoppingCartId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("993dc891-f1ee-4b53-984d-3a019f294bfd"), 0, "105df291-9924-4d21-a33a-405fed8c5d42", "dealer@dealer.com", false, "Dealer", "DeIsHere_Test", false, null, "dealer@dealer.com", "dealer@dealer.com", "AQAAAAEAACcQAAAAEN7kfnl4Op6NoGkOR5Y26WwdDFvtqQYNfnfdX78yj6hT32YVsLdG12qURhHvqOA5WQ==", null, false, "3c149317-791d-4144-8bfd-489ca8e4ab03", new Guid("61be485b-f019-4fd6-9c43-07f5aa896895"), false, "dealer@dealer.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShoppingCartId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("bcbd7654-ab17-4621-b75b-fc43ea4449db"), 0, "46ac5702-2220-4daf-954a-451d207903b1", "admin@admin.com", false, "Admin", "AdIsHere_Test", false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEOLclY5hQspOqoWmPw7SZmeXItqEQ40RPyvL+lTPIvvEKtp09yNG2e2zUqwhaaACZQ==", null, false, "e12c2544-be54-4931-8a11-533bd1213225", new Guid("1bca46f0-2eb4-43c7-8a76-7b006ceb109a"), false, "admin@admin.com" });

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
                columns: new[] { "Id", "Address", "Brand", "CategoryId", "CreatedOn", "DealerId", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "IsActive", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[] { new Guid("9944ed88-39e6-4c93-b830-1123d605ad30"), "Boyana Neighbourhood, Sofia, Bulgaria", "Toyota", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "The car is a sports coupe type and is convenient for maneuvering in urban conditions.", 1, 1, 430, "https://performancedrive.com.au/wp-content/uploads/2020/02/2020-Toyota-GR-Supra-GT-scaled.jpg", false, "Supra", 900.00m, null, 2020 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "Brand", "CategoryId", "CreatedOn", "DealerId", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "IsActive", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[] { new Guid("a0f2c170-7aa4-449a-bb44-58888eae5178"), "Boyana Neighbourhood, Sofia, Bulgaria", "McLaren", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "This is a sports car and is recommended to be driven carefully.", 2, 2, 560, "https://edge.pxcrush.net/cars/dealer/dro0hrehxv0n0250f55sf7nqy.jpg?pxc_expires=20231101025101&pxc_clear=1&pxc_signature=2e0f693b59a609c1f0f77e21ed5fbfed", false, "720S", 1500.00m, null, 2016 });
        }
    }
}
