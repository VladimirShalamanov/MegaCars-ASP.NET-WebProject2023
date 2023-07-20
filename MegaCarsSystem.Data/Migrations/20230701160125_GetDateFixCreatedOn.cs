using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaCarsSystem.Data.Migrations
{
    public partial class GetDateFixCreatedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("3dac2dad-14a1-4a52-b4da-3ed91be6d8d5"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("79977e38-55d2-4cef-976c-1e9bd89f64fe"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 26, 16, 18, 3, 695, DateTimeKind.Utc).AddTicks(1010));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "AgentId", "Brand", "CategoryId", "Description", "ImageUrl", "PricePerDay", "RenterId" },
                values: new object[] { new Guid("3240e8ce-eadc-4a3a-b8bc-55c81a8a7fd3"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "McLaren", 6, "This is a sports car and is recommended to be driven carefully.", "https://edge.pxcrush.net/cars/dealer/dro0hrehxv0n0250f55sf7nqy.jpg?pxc_expires=20231101025101&pxc_clear=1&pxc_signature=2e0f693b59a609c1f0f77e21ed5fbfed", 1500.00m, new Guid("b96378d2-a1a1-44d4-479f-08db7649a045") });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "AgentId", "Brand", "CategoryId", "Description", "ImageUrl", "PricePerDay", "RenterId" },
                values: new object[] { new Guid("c965dca0-f227-46e0-a9c8-45111330f19d"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "Toyota", 3, "The car is a sports coupe type and is convenient for maneuvering in urban conditions.", "https://performancedrive.com.au/wp-content/uploads/2020/02/2020-Toyota-GR-Supra-GT-scaled.jpg", 900.00m, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("3240e8ce-eadc-4a3a-b8bc-55c81a8a7fd3"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c965dca0-f227-46e0-a9c8-45111330f19d"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 26, 16, 18, 3, 695, DateTimeKind.Utc).AddTicks(1010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "AgentId", "Brand", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerDay", "RenterId" },
                values: new object[] { new Guid("3dac2dad-14a1-4a52-b4da-3ed91be6d8d5"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "McLaren", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a sports car and is recommended to be driven carefully.", "https://edge.pxcrush.net/cars/dealer/dro0hrehxv0n0250f55sf7nqy.jpg?pxc_expires=20231101025101&pxc_clear=1&pxc_signature=2e0f693b59a609c1f0f77e21ed5fbfed", 1500.00m, new Guid("b96378d2-a1a1-44d4-479f-08db7649a045") });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Address", "AgentId", "Brand", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerDay", "RenterId" },
                values: new object[] { new Guid("79977e38-55d2-4cef-976c-1e9bd89f64fe"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a6f8d35a-a59f-4227-9da1-4bba22b919e1"), "Toyota", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The car is a sports coupe type and is convenient for maneuvering in urban conditions.", "https://performancedrive.com.au/wp-content/uploads/2020/02/2020-Toyota-GR-Supra-GT-scaled.jpg", 900.00m, null });
        }
    }
}
