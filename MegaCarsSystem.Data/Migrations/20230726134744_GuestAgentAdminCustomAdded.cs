using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaCarsSystem.Data.Migrations
{
    public partial class GuestAgentAdminCustomAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("94e03edf-87a7-4e38-9916-58ef44614d4b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ce774e8a-4a03-4fe2-a536-4816d0e72e90"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("993dc891-f1ee-4b53-984d-3a019f294bfd"), 0, "2aa0dd53-c0d6-4861-8c37-497e36957086", "agent@agent.com", false, "Agent", "AgIsHere_Test", false, null, "agent@agent.com", "agent@agent.com", "AQAAAAEAACcQAAAAEFK9PxU9E5HU4/wcHjoeCLA6uzZjRlMJbgRo1G1JOUn5qbrL+2JY9kYsP/IJW7rtFg==", null, false, "f79fd500-2a06-4e93-a7c9-a24756f34d5b", false, "agent@agent.com" },
                    { new Guid("bcbd7654-ab17-4621-b75b-fc43ea4449db"), 0, "85e86f45-5e3c-492b-ad9b-d55d688f9be7", "admin@admin.com", false, "Admin", "AdIsHere_Test", false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEM5mJi9ufeKA6wJgCyXLdRTzIsVd2et+SaqWYuGOpKMFft4MfFrQgT5g00D3eEs5Ng==", null, false, "0f10c68c-c4ff-4fa0-a162-9a8e057313dc", false, "admin@admin.com" },
                    { new Guid("e0d951f3-c82a-4a21-aa27-d101e22da11a"), 0, "f1856d3d-fe4a-4c22-93ad-42ae92990427", "guest@guest.com", false, "Guest", "GuIsHere_Test", false, null, "guest@guest.com", "guest@guest.com", "AQAAAAEAACcQAAAAEIpJ0KP4t9uTj4aeWVLxnYmgcUhkY1R8te3ikiPpfU84yQ9RjVI3IaDq/dQ5PFwO+g==", null, false, "134c7f6c-8ed7-4880-be6f-287b736c4756", false, "guest@guest.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("8d9b7be2-8ce7-48cd-b7c2-7fc344e2dc19"), "Black T-shirt with great quality.", "https://images-na.ssl-images-amazon.com/images/I/61oFHwCIKrL._SLDPMOBCAROUSELAUTOCROP288221_MCnd_AC_SR462,693_.jpg", "T-shirt Supercar", 18.00m },
                    { new Guid("b8a206cf-9ea1-49c2-9a32-accbaf00a84f"), "Мetal key holder for your keys.", "https://i.etsystatic.com/13582943/r/il/2f99a2/1700229685/il_fullxfull.1700229685_ooj3.jpg", "Keychain Turbine", 5.00m }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "+359888777666", new Guid("993dc891-f1ee-4b53-984d-3a019f294bfd") });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("d08e602f-3c3f-4391-aaf6-b4867a639c13"), "+359333222111", new Guid("bcbd7654-ab17-4621-b75b-fc43ea4449db") });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "AgentId", "Brand", "CategoryId", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[] { new Guid("b79ac80b-e44b-4148-b459-3786ee245de4"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "Toyota", 3, "The car is a sports coupe type and is convenient for maneuvering in urban conditions.", 1, 1, 430, "https://performancedrive.com.au/wp-content/uploads/2020/02/2020-Toyota-GR-Supra-GT-scaled.jpg", "Supra", 900.00m, null, 2020 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "AgentId", "Brand", "CategoryId", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[] { new Guid("c8ea5812-8509-44cf-ac28-456e5e801085"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "McLaren", 6, "This is a sports car and is recommended to be driven carefully.", 2, 2, 560, "https://edge.pxcrush.net/cars/dealer/dro0hrehxv0n0250f55sf7nqy.jpg?pxc_expires=20231101025101&pxc_clear=1&pxc_signature=2e0f693b59a609c1f0f77e21ed5fbfed", "720S", 1500.00m, null, 2016 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("d08e602f-3c3f-4391-aaf6-b4867a639c13"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e0d951f3-c82a-4a21-aa27-d101e22da11a"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("b79ac80b-e44b-4148-b459-3786ee245de4"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c8ea5812-8509-44cf-ac28-456e5e801085"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8d9b7be2-8ce7-48cd-b7c2-7fc344e2dc19"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b8a206cf-9ea1-49c2-9a32-accbaf00a84f"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bcbd7654-ab17-4621-b75b-fc43ea4449db"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("993dc891-f1ee-4b53-984d-3a019f294bfd"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[] { new Guid("94e03edf-87a7-4e38-9916-58ef44614d4b"), "Мetal key holder for your keys.", "https://i.etsystatic.com/13582943/r/il/2f99a2/1700229685/il_fullxfull.1700229685_ooj3.jpg", "Keychain Turbine", 5.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[] { new Guid("ce774e8a-4a03-4fe2-a536-4816d0e72e90"), "Black T-shirt with great quality.", "https://images-na.ssl-images-amazon.com/images/I/61oFHwCIKrL._SLDPMOBCAROUSELAUTOCROP288221_MCnd_AC_SR462,693_.jpg", "T-shirt Supercar", 18.00m });
        }
    }
}
