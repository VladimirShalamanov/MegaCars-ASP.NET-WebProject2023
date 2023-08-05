using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaCarsSystem.Data.Migrations
{
    public partial class clearSeeds : Migration
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
                keyValue: new Guid("232fd1f0-e06d-47c0-9a35-2041279f312f"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("acb65da4-762f-4cb9-976a-8b806721d4af"));

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: new Guid("d08e602f-3c3f-4391-aaf6-b4867a639c13"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4103a975-2edd-45d9-a80c-941f03baab96"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9827aac8-741a-4537-9ea8-473b8321a264"));

            migrationBuilder.DeleteData(
                table: "ShopCarts",
                keyColumn: "Id",
                keyValue: new Guid("1bca46f0-2eb4-43c7-8a76-7b006ceb109a"));

            migrationBuilder.DeleteData(
                table: "ShopCarts",
                keyColumn: "Id",
                keyValue: new Guid("61be485b-f019-4fd6-9c43-07f5aa896895"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bcbd7654-ab17-4621-b75b-fc43ea4449db"));

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("993dc891-f1ee-4b53-984d-3a019f294bfd"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2c5628be-a8ca-4cf0-bc0d-c441e6aa0c6e"), 0, "c401e667-5131-4046-bd92-b95e56f90c6c", "user@user.com", false, "User", "Guest_Test", false, null, "user@user.com", "user@user.com", "AQAAAAEAACcQAAAAEF6xS1GYDfpy6LB9IPpQBVQaZ8tbdM9bvrclGDWB8z3N2DQ0Cc/dQLNDFwRDOkFwiw==", null, false, "8dec6e67-4c4b-4635-ab13-21f0e3865e09", false, "user@user.com" },
                    { new Guid("993dc891-f1ee-4b53-984d-3a019f294bfd"), 0, "ca8a1265-2a2b-4a48-a7db-e62d154ccf4b", "agent@agent.com", false, "Agent", "AgIsHere_Test", false, null, "agent@agent.com", "agent@agent.com", "AQAAAAEAACcQAAAAEFG/bfv90S81RpwIyxMj7BdSoa8cdaXXy6/o5FC+PE5tZzz+em1dXumTmJ3u4/w1hQ==", null, false, "6ce59d6d-0b0c-4d2c-a0f3-5e4f6bdd761a", false, "agent@agent.com" },
                    { new Guid("bcbd7654-ab17-4621-b75b-fc43ea4449db"), 0, "dbaa5c93-be83-4927-8b8a-f98a2e190089", "admin@admin.com", false, "Admin", "AdIsHere_Test", false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEIE3jNAaArQU72DxxdowRiQItvRo9uIkeq1k5FhizEd8Rf8Mmn4PB+rnEBThFfUFXQ==", null, false, "7c88c5cb-c78d-4401-8b52-0dd21e545809", false, "admin@admin.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("4103a975-2edd-45d9-a80c-941f03baab96"), "Мetal key holder for your keys.", "https://i.etsystatic.com/13582943/r/il/2f99a2/1700229685/il_fullxfull.1700229685_ooj3.jpg", "Keychain Turbine", 5.00m },
                    { new Guid("9827aac8-741a-4537-9ea8-473b8321a264"), "Black T-shirt with great quality.", "https://images-na.ssl-images-amazon.com/images/I/61oFHwCIKrL._SLDPMOBCAROUSELAUTOCROP288221_MCnd_AC_SR462,693_.jpg", "T-shirt Supercar", 18.00m }
                });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "+359888777666", new Guid("993dc891-f1ee-4b53-984d-3a019f294bfd") },
                    { new Guid("d08e602f-3c3f-4391-aaf6-b4867a639c13"), "+359333222111", new Guid("bcbd7654-ab17-4621-b75b-fc43ea4449db") }
                });

            migrationBuilder.InsertData(
                table: "ShopCarts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("1bca46f0-2eb4-43c7-8a76-7b006ceb109a"), new Guid("bcbd7654-ab17-4621-b75b-fc43ea4449db") },
                    { new Guid("61be485b-f019-4fd6-9c43-07f5aa896895"), new Guid("993dc891-f1ee-4b53-984d-3a019f294bfd") }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "Brand", "CategoryId", "CreatedOn", "DealerId", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "IsActive", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[] { new Guid("232fd1f0-e06d-47c0-9a35-2041279f312f"), "Boyana Neighbourhood, Sofia, Bulgaria", "Toyota", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "The car is a sports coupe type and is convenient for maneuvering in urban conditions.", 1, 1, 430, "https://performancedrive.com.au/wp-content/uploads/2020/02/2020-Toyota-GR-Supra-GT-scaled.jpg", false, "Supra", 900.00m, null, 2020 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "Brand", "CategoryId", "CreatedOn", "DealerId", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "IsActive", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[] { new Guid("acb65da4-762f-4cb9-976a-8b806721d4af"), "Boyana Neighbourhood, Sofia, Bulgaria", "McLaren", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "This is a sports car and is recommended to be driven carefully.", 2, 2, 560, "https://edge.pxcrush.net/cars/dealer/dro0hrehxv0n0250f55sf7nqy.jpg?pxc_expires=20231101025101&pxc_clear=1&pxc_signature=2e0f693b59a609c1f0f77e21ed5fbfed", false, "720S", 1500.00m, null, 2016 });
        }
    }
}
