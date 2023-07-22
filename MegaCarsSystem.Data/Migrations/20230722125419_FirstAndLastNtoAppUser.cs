using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaCarsSystem.Data.Migrations
{
    public partial class FirstAndLastNtoAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("99fb0b11-c310-46e9-a8a1-bcaa687b4779"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("a7db9161-0dae-4ec2-95c3-55ddd32107dc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a0e85d9-f953-44c0-b5b5-dcab77981d6d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e7878aa3-91b9-4537-b4ee-48070c9082af"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "TestF");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "TestL");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "AgentId", "Brand", "CategoryId", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[,]
                {
                    { new Guid("2198fcbd-2caa-479e-a01a-a821d55a1b55"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "Toyota", 3, "The car is a sports coupe type and is convenient for maneuvering in urban conditions.", 1, 1, 430, "https://performancedrive.com.au/wp-content/uploads/2020/02/2020-Toyota-GR-Supra-GT-scaled.jpg", "Supra", 900.00m, null, 2020 },
                    { new Guid("48c22722-657d-4906-a782-d1c22f3faa9c"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "McLaren", 6, "This is a sports car and is recommended to be driven carefully.", 2, 2, 560, "https://edge.pxcrush.net/cars/dealer/dro0hrehxv0n0250f55sf7nqy.jpg?pxc_expires=20231101025101&pxc_clear=1&pxc_signature=2e0f693b59a609c1f0f77e21ed5fbfed", "720S", 1500.00m, new Guid("30c3ed84-2725-45f3-95ae-5d93572dfe5b"), 2016 }
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "AgentId", "Brand", "CategoryId", "CreatedOn", "Description", "EngineId", "GearboxId", "Horsepower", "ImageUrl", "IsActive", "Model", "PricePerDay", "RenterId", "YearOfManufacture" },
                values: new object[,]
                {
                    { new Guid("99fb0b11-c310-46e9-a8a1-bcaa687b4779"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "McLaren", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a sports car and is recommended to be driven carefully.", 2, 2, 560, "https://edge.pxcrush.net/cars/dealer/dro0hrehxv0n0250f55sf7nqy.jpg?pxc_expires=20231101025101&pxc_clear=1&pxc_signature=2e0f693b59a609c1f0f77e21ed5fbfed", false, "720S", 1500.00m, new Guid("b96378d2-a1a1-44d4-479f-08db7649a045"), 2016 },
                    { new Guid("a7db9161-0dae-4ec2-95c3-55ddd32107dc"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "Toyota", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The car is a sports coupe type and is convenient for maneuvering in urban conditions.", 1, 1, 430, "https://performancedrive.com.au/wp-content/uploads/2020/02/2020-Toyota-GR-Supra-GT-scaled.jpg", false, "Supra", 900.00m, null, 2020 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0a0e85d9-f953-44c0-b5b5-dcab77981d6d"), "Мetal key holder for your keys.", "https://i.etsystatic.com/13582943/r/il/2f99a2/1700229685/il_fullxfull.1700229685_ooj3.jpg", "Keychain Turbine", 5.00m },
                    { new Guid("e7878aa3-91b9-4537-b4ee-48070c9082af"), "Black T-shirt with great quality.", "https://images-na.ssl-images-amazon.com/images/I/61oFHwCIKrL._SLDPMOBCAROUSELAUTOCROP288221_MCnd_AC_SR462,693_.jpg", "T-shirt Supercar", 18.00m }
                });
        }
    }
}
