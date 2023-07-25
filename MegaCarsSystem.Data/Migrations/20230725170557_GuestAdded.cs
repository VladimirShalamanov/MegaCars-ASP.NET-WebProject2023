using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaCarsSystem.Data.Migrations
{
    public partial class GuestAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("058e52cd-e704-4925-a372-e29d5fcf5aab"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("0f78802f-c333-4840-a6b4-31e63438cab4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62c83bb8-d684-45f9-a634-d1b7cb2e9172"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e3cc4e47-318f-4876-8332-03956ebc7501"));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "TestL",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "TestF",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c8456483-8aa7-4064-912d-967070b2b115"), 0, "53b2671c-e5a3-474d-b0a2-6df30f8d226e", "guest@guest.com", false, "Guest", "User_Test", false, null, "guest@guest.com", "guest@guest.com", "AQAAAAEAACcQAAAAECtgDb0kZ16RFXKcngvCO9QfudsoswtbS4F/Dvx6cIdlylvVhqsWt2XboSgcX7n2Ew==", null, false, null, false, "guest@guest.com" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "AgentId", "Brand", "CategoryId", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[,]
                {
                    { new Guid("32245362-18fb-48f9-918a-6f4c56931ed0"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "Toyota", 3, "The car is a sports coupe type and is convenient for maneuvering in urban conditions.", 1, 1, 430, "https://performancedrive.com.au/wp-content/uploads/2020/02/2020-Toyota-GR-Supra-GT-scaled.jpg", "Supra", 900.00m, null, 2020 },
                    { new Guid("f7286bed-2ae8-4ada-89aa-56f9df21b8b7"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "McLaren", 6, "This is a sports car and is recommended to be driven carefully.", 2, 2, 560, "https://edge.pxcrush.net/cars/dealer/dro0hrehxv0n0250f55sf7nqy.jpg?pxc_expires=20231101025101&pxc_clear=1&pxc_signature=2e0f693b59a609c1f0f77e21ed5fbfed", "720S", 1500.00m, new Guid("30c3ed84-2725-45f3-95ae-5d93572dfe5b"), 2016 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2a3ea786-886f-442e-8c46-f45a8acf885c"), "Black T-shirt with great quality.", "https://images-na.ssl-images-amazon.com/images/I/61oFHwCIKrL._SLDPMOBCAROUSELAUTOCROP288221_MCnd_AC_SR462,693_.jpg", "T-shirt Supercar", 18.00m },
                    { new Guid("3677a188-23a4-4a07-99f1-1b107c5c8538"), "Мetal key holder for your keys.", "https://i.etsystatic.com/13582943/r/il/2f99a2/1700229685/il_fullxfull.1700229685_ooj3.jpg", "Keychain Turbine", 5.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c8456483-8aa7-4064-912d-967070b2b115"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("32245362-18fb-48f9-918a-6f4c56931ed0"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("f7286bed-2ae8-4ada-89aa-56f9df21b8b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2a3ea786-886f-442e-8c46-f45a8acf885c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3677a188-23a4-4a07-99f1-1b107c5c8538"));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldDefaultValue: "TestL");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldDefaultValue: "TestF");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "AgentId", "Brand", "CategoryId", "CreatedOn", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "IsActive", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[,]
                {
                    { new Guid("058e52cd-e704-4925-a372-e29d5fcf5aab"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "Toyota", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The car is a sports coupe type and is convenient for maneuvering in urban conditions.", 1, 1, 430, "https://performancedrive.com.au/wp-content/uploads/2020/02/2020-Toyota-GR-Supra-GT-scaled.jpg", false, "Supra", 900.00m, null, 2020 },
                    { new Guid("0f78802f-c333-4840-a6b4-31e63438cab4"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "McLaren", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a sports car and is recommended to be driven carefully.", 2, 2, 560, "https://edge.pxcrush.net/cars/dealer/dro0hrehxv0n0250f55sf7nqy.jpg?pxc_expires=20231101025101&pxc_clear=1&pxc_signature=2e0f693b59a609c1f0f77e21ed5fbfed", false, "720S", 1500.00m, new Guid("30c3ed84-2725-45f3-95ae-5d93572dfe5b"), 2016 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("62c83bb8-d684-45f9-a634-d1b7cb2e9172"), "Мetal key holder for your keys.", "https://i.etsystatic.com/13582943/r/il/2f99a2/1700229685/il_fullxfull.1700229685_ooj3.jpg", "Keychain Turbine", 5.00m },
                    { new Guid("e3cc4e47-318f-4876-8332-03956ebc7501"), "Black T-shirt with great quality.", "https://images-na.ssl-images-amazon.com/images/I/61oFHwCIKrL._SLDPMOBCAROUSELAUTOCROP288221_MCnd_AC_SR462,693_.jpg", "T-shirt Supercar", 18.00m }
                });
        }
    }
}
