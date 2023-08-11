using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaCarsSystem.Data.Migrations
{
    public partial class seedExamData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("10cfcba3-9fc3-4605-837b-a1280071e0ce"), "Black T-shirt with great quality.", "https://images-na.ssl-images-amazon.com/images/I/61oFHwCIKrL._SLDPMOBCAROUSELAUTOCROP288221_MCnd_AC_SR462,693_.jpg", "T-shirt Supercar", 18.99m },
                    { new Guid("1d26bcd5-cc82-4f51-8b07-90f01bc27bc1"), "Red Jacket with great quality.", "https://shopf1apparel.com/cdn/shop/products/Hd360c9d9c1a64a089d0f91a3266b17f0d.jpg?v=1630395464", "Jacket Ferrari", 89.99m },
                    { new Guid("69aa41e1-193a-4b65-9f00-7b5220aeb388"), "Blue Cap with great quality.", "https://cdn.shopify.com/s/files/1/1435/8030/products/LB17CAP2BL_Lamborghini_Blue_Cap_1.jpg?v=1657622166&width=533", "Cap Lamborghini", 43.99m },
                    { new Guid("e8e2534c-b12f-40a5-810c-5ff3c01eea03"), "Мetal key holder for your keys.", "https://i.etsystatic.com/13582943/r/il/2f99a2/1700229685/il_fullxfull.1700229685_ooj3.jpg", "Keychain Turbine", 5.99m }
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
                values: new object[] { new Guid("2c5628be-a8ca-4cf0-bc0d-c441e6aa0c6e"), 0, "c9dbe5d3-8fe5-404f-b945-9420a12bde84", "user@user.com", false, "User", "Guest_Test", false, null, "user@user.com", "user@user.com", "AQAAAAEAACcQAAAAEN/e01hYbyWBgsB9PjaTcwwB+x1ttRhVSzuh0sq0pLujtjUs2bxj6nD9Nk9uQuJqIw==", null, false, "69e3f251-07fd-4285-a45e-38b7ca19966e", new Guid("88856b35-f932-4a23-9baf-2a8974418b22"), false, "user@user.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShoppingCartId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("993dc891-f1ee-4b53-984d-3a019f294bfd"), 0, "21da2adf-9b86-4245-a170-011e7889fdab", "dealer@dealer.com", false, "Dealer", "DeIsHere_Test", false, null, "dealer@dealer.com", "dealer@dealer.com", "AQAAAAEAACcQAAAAEHPv3g9SesUdiswvKhY0OlpiU1INRoWl+fAIROFDvchicbD333XxuRlfiI+uGgcOuw==", null, false, "5377a1ac-1c63-41aa-a52a-5341efa26c75", new Guid("61be485b-f019-4fd6-9c43-07f5aa896895"), false, "dealer@dealer.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShoppingCartId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("bcbd7654-ab17-4621-b75b-fc43ea4449db"), 0, "14c99fd3-605e-437f-a262-4f49295aaa20", "admin@admin.com", false, "Admin", "AdIsHere_Test", false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEP+vPe2XTclIxQ/vjPGpWKa7Yp6PKYB129CCN++QS2N/hL9OdFAY8OqJlKFGn1zaPA==", null, false, "ccac2527-68a4-4b16-9da5-0cf40b7b02cb", new Guid("1bca46f0-2eb4-43c7-8a76-7b006ceb109a"), false, "admin@admin.com" });

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
                values: new object[,]
                {
                    { new Guid("02640ce6-f8b8-4407-b27c-bcb3aff20765"), "ul. Ivan Vazov N3, Sofia, Bulgaria", "Audi", 5, new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "The 2022 Audi RS6 Avant delivers a powerful performance with 591 horsepower, 590 lb-ft of torque, and only needs 3.5 seconds to go from 0-60 mph. The performance continues with quattro® sport rear wheel differential, RS-tuned air suspension, and ceramic brakes.", 2, 2, 591, "https://web2.wheelz.me/wp-content/uploads/2021/11/ABT_RS6-S_red_HR22_23.jpg", "RS6 ", 760.00m, null, 2022 },
                    { new Guid("076c08fd-da24-4478-91bd-1b61ae22bf07"), "ul. Ivan Vazov N3, Sofia, Bulgaria", "Mercedes", 11, new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "The high-performance AMG G63 is powered by a twin-turbo 5.5L V8 that makes 563 horsepower, making the big off-roader almost unnaturally quick. The AMG G65 is powered by a 6.0L twin-turbo V12 that produces 621 horsepower and 738 lb-feet of torque. All three engine options are mated to a 7-speed automatic transmission.", 1, 2, 563, "https://assets.autobuzz.my/wp-content/uploads/2018/11/13210055/2018-Mercedes-AMG-G-63-Launched-in-Malaysia-29.jpg", "AMG G-63", 1490.00m, null, 2018 },
                    { new Guid("2f0a0eda-7432-4b70-8b02-b4e939b8c38a"), "ul. Ivan Vazov N3, Sofia, Bulgaria", "BMW", 1, new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "The M5 is powered by a 4.4-liter twin-turbo V-8 with 600 hp and 553 lb-ft of torque. M5 Competition models get a power bump to 617 hp. EPA fuel economy ratings are 15/21 mpg city/highway with the standard eight-speed automatic transmission. We've tested an M5 reaching 60 mph in as quick as 3.0 seconds.", 2, 2, 600, "https://www.thedrive.com/content/2021/09/IMG_3314.jpeg?quality=85&crop=16%3A9&auto=webp&optimize=high&quality=70&width=1440", "M5 Competition", 1250.00m, null, 2021 },
                    { new Guid("6c629b72-afe4-4f9c-a856-8804d88446ee"), "ul. Ivan Vazov N3, Sofia, Bulgaria", "Aston Martin", 7, new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "The Vantage is a rear wheel drive 2 door with 2 seats, powered by a 4.0L TWIN TURBO V8 engine that has 375 kW of power (at 6000 rpm) and 685 Nm of torque (at 2000 rpm) via an Eight-speed Automatic.", 2, 2, 503, "https://www.autocar.co.uk/sites/autocar.co.uk/files/1-aston-martin-vantage-2018-review-hero-front.jpg", "Vantage", 1100.00m, null, 2019 },
                    { new Guid("7e638245-94e0-4497-93d3-834d2590eeac"), "ul. Ivan Vazov N3, Sofia, Bulgaria", "Nissan", 6, new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "The 2020 GT-R's standard twin-turbo 3.8-liter V-6 makes a mighty 565 horsepower. It hooks up to a six-speed automatic transmission and all-wheel drive that conspire to put all that power to the pavement. At our test track, the GT-R launched itself from zero to 60 mph in a mere 2.9 seconds.", 2, 2, 565, "https://cdn.motor1.com/images/mgl/1MlwW/s1/2020-nissan-gt-r-nismo-review.jpg", "GT-R", 800.00m, null, 2020 },
                    { new Guid("9da6b21c-7fb9-4235-bfe3-74bb5514c043"), "ul. Ivan Vazov N3, Sofia, Bulgaria", "Bentley", 4, new Guid("4fd9d7ca-37c2-411e-8a03-b978fbb1c5f3"), "The Continental measures 1405mm (55.3 inches) in height, 4850mm (190.9 inches) in length, 1966mm (77.4 inches) in width with a 2851mm (112.2 inches) wheelbase that brings about a total of 2244kg (4947.2 lbs) of unladen weight. The Continental GT comes standard with 265/40 ZR21 front tyres and 305/35 ZR21 rear tyres.", 2, 2, 659, "https://cdn.carbuzz.com/gallery-images/840x560/538000/900/538901.jpg", "Continental GT", 1230.00m, null, 2021 }
                });
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
                keyValue: new Guid("02640ce6-f8b8-4407-b27c-bcb3aff20765"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("076c08fd-da24-4478-91bd-1b61ae22bf07"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("2f0a0eda-7432-4b70-8b02-b4e939b8c38a"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("6c629b72-afe4-4f9c-a856-8804d88446ee"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("7e638245-94e0-4497-93d3-834d2590eeac"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("9da6b21c-7fb9-4235-bfe3-74bb5514c043"));

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: new Guid("d08e602f-3c3f-4391-aaf6-b4867a639c13"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10cfcba3-9fc3-4605-837b-a1280071e0ce"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1d26bcd5-cc82-4f51-8b07-90f01bc27bc1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("69aa41e1-193a-4b65-9f00-7b5220aeb388"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8e2534c-b12f-40a5-810c-5ff3c01eea03"));

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
