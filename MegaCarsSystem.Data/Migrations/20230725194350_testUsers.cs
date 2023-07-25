using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaCarsSystem.Data.Migrations
{
    public partial class testUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("2198fcbd-2caa-479e-a01a-a821d55a1b55"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("48c22722-657d-4906-a782-d1c22f3faa9c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("259323d7-32d3-4635-8c59-15bc697a04a3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fe4b625f-4167-4a62-880e-aeb68162345b"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6435e52c-1508-46ae-b585-49c797a9e607"), 0, "858c038a-5419-4189-aea1-54b596833c8b", "guest@guest.com", false, "Guest", "GuIsHere_Test", false, null, "guest@guest.com", "guest@guest.com", "AQAAAAEAACcQAAAAEMQ7QIjBLr3jJsRqlQPGOl3RHi+eemOAUSJM5UzXz9nxEnV7N4RGTonKmzCO/fSILw==", null, false, "1f0eec96-7514-43b6-a3dd-89608fd36f6b", false, "guest@guest.com" },
                    { new Guid("85ce132c-35cc-4b6a-8081-ec74aad74ea3"), 0, "4aaa4948-060a-488b-bc55-3b31f494f7d1", "agent@agent.com", false, "Agent", "AgIsHere_Test", false, null, "agent@agent.com", "agent@agent.com", "AQAAAAEAACcQAAAAEAKzmzQznzACz9PjiHXHoNsPjiuqN4oYPeTHn7NlZcw8S2BaCApZNsc9uaYbJ0hyXw==", null, false, "72b26ce2-d826-479d-a849-0bb294a6b20a", false, "agent@agent.com" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "AgentId", "Brand", "CategoryId", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[,]
                {
                    { new Guid("730120f3-b7a9-481f-8aca-e1bedb15044f"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "Toyota", 3, "The car is a sports coupe type and is convenient for maneuvering in urban conditions.", 1, 1, 430, "https://performancedrive.com.au/wp-content/uploads/2020/02/2020-Toyota-GR-Supra-GT-scaled.jpg", "Supra", 900.00m, null, 2020 },
                    { new Guid("ecec9150-af9e-4994-9cd7-02aa957453a2"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "McLaren", 6, "This is a sports car and is recommended to be driven carefully.", 2, 2, 560, "https://edge.pxcrush.net/cars/dealer/dro0hrehxv0n0250f55sf7nqy.jpg?pxc_expires=20231101025101&pxc_clear=1&pxc_signature=2e0f693b59a609c1f0f77e21ed5fbfed", "720S", 1500.00m, new Guid("30c3ed84-2725-45f3-95ae-5d93572dfe5b"), 2016 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("f75dd2f6-e500-4175-9ac9-2c13d90677fd"), "Black T-shirt with great quality.", "https://images-na.ssl-images-amazon.com/images/I/61oFHwCIKrL._SLDPMOBCAROUSELAUTOCROP288221_MCnd_AC_SR462,693_.jpg", "T-shirt Supercar", 18.00m },
                    { new Guid("fdf06808-b548-49d9-91bd-8638fa29ccd0"), "Мetal key holder for your keys.", "https://i.etsystatic.com/13582943/r/il/2f99a2/1700229685/il_fullxfull.1700229685_ooj3.jpg", "Keychain Turbine", 5.00m }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("8054bc54-c38b-4ba4-96ed-ea58995c326b"), "+359888777666", new Guid("85ce132c-35cc-4b6a-8081-ec74aad74ea3") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("8054bc54-c38b-4ba4-96ed-ea58995c326b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6435e52c-1508-46ae-b585-49c797a9e607"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("730120f3-b7a9-481f-8aca-e1bedb15044f"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("ecec9150-af9e-4994-9cd7-02aa957453a2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f75dd2f6-e500-4175-9ac9-2c13d90677fd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fdf06808-b548-49d9-91bd-8638fa29ccd0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("85ce132c-35cc-4b6a-8081-ec74aad74ea3"));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "AgentId", "Brand", "CategoryId", "CreatedOn", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "IsActive", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[,]
                {
                    { new Guid("2198fcbd-2caa-479e-a01a-a821d55a1b55"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "Toyota", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The car is a sports coupe type and is convenient for maneuvering in urban conditions.", 1, 1, 430, "https://performancedrive.com.au/wp-content/uploads/2020/02/2020-Toyota-GR-Supra-GT-scaled.jpg", false, "Supra", 900.00m, null, 2020 },
                    { new Guid("48c22722-657d-4906-a782-d1c22f3faa9c"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "McLaren", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a sports car and is recommended to be driven carefully.", 2, 2, 560, "https://edge.pxcrush.net/cars/dealer/dro0hrehxv0n0250f55sf7nqy.jpg?pxc_expires=20231101025101&pxc_clear=1&pxc_signature=2e0f693b59a609c1f0f77e21ed5fbfed", false, "720S", 1500.00m, new Guid("30c3ed84-2725-45f3-95ae-5d93572dfe5b"), 2016 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("259323d7-32d3-4635-8c59-15bc697a04a3"), "Black T-shirt with great quality.", "https://images-na.ssl-images-amazon.com/images/I/61oFHwCIKrL._SLDPMOBCAROUSELAUTOCROP288221_MCnd_AC_SR462,693_.jpg", "T-shirt Supercar", 18.00m },
                    { new Guid("fe4b625f-4167-4a62-880e-aeb68162345b"), "Мetal key holder for your keys.", "https://i.etsystatic.com/13582943/r/il/2f99a2/1700229685/il_fullxfull.1700229685_ooj3.jpg", "Keychain Turbine", 5.00m }
                });
        }
    }
}
