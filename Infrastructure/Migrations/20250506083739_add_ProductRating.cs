using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_ProductRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5f5f653-b99a-4386-89fe-df8a4f648ced", "07cc4645-0e6e-4c54-bd73-7b29f0f43d91" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b12c236e-71ac-44b3-bd96-bc6b9f1c61de", "812cb417-f054-45fb-853c-5521bf1dfffa" });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "1dc26aee-1906-493f-ac1d-bd17b9842f4c");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "42697d79-1b58-42a9-9294-9bb0df906f15");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "c676a71a-cee1-4ddc-8876-550bcbc27515");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "c8b37d49-55d2-4532-8a61-621bbdc122a1");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "cfbcc452-03cf-4748-9b4c-c15ef55eecc2");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "db71938d-8681-47ca-9311-38fbe4a9b99d");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "2327e2ca-04e4-42b6-9ab0-2b315c804f78");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "5ace253a-2384-4813-bed4-edf1d0faea1f");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "6cc1d192-436f-4116-b6f5-809a8ce4e4ba");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "9afe29a9-4e66-42d2-a2bc-90e5b7f94cea");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "b6510274-c5cc-485f-9818-1b10ea05e84e");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "c4791eac-cad6-47fd-a054-7ebbd0d0d289");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "e82df5d8-43b9-4243-b1b2-abc9523f5427");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5f5f653-b99a-4386-89fe-df8a4f648ced");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b12c236e-71ac-44b3-bd96-bc6b9f1c61de");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "07cc4645-0e6e-4c54-bd73-7b29f0f43d91");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "812cb417-f054-45fb-853c-5521bf1dfffa");

            migrationBuilder.CreateTable(
                name: "ProductRating",
                columns: table => new
                {
                    ProductRatingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRating", x => x.ProductRatingId);
                    table.ForeignKey(
                        name: "FK_ProductRating_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRating_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "189deef4-29cb-4003-9778-dba5205e2c58", null, "Admin", "ADMIN" },
                    { "635ea78b-7342-4a09-8a88-31abed328086", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00211442-2868-4a9a-9e68-58e5e7758806", 0, "6777b472-86f2-40f5-a555-044f56db3bb4", "IdentityUser", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEL5g2TsKvRPe/PO0RqXm5IdG8I6deBXNGOytCOlglrjFB9BZt0xFtd7m7b4RAqTCUw==", null, false, "", false, "user@gmail.com" },
                    { "1a0453c8-2e51-482a-88a5-1957a44a9bdd", 0, "4ead1138-3bd6-4643-8593-1e683e6aa6fa", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEMLt+xxaMR6wKRKTsKAMmS6RO8x5hf2A/1vdVBacSxDNW8+6+PfdrrxEwlUOmegNdg==", null, false, "", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { "24ef8f35-7328-454e-a5b2-fab946ba10ef", "images/House Espresso2.jpg", "780905a8-1505-4635-a3ed-2872625bd071" },
                    { "35dd2f1f-fa72-431f-9235-a52bff9807fc", "images/Space Cadet_1.jpg", "1ec624d5-25d0-4a5c-9d47-925be2439e70" },
                    { "8eb7b4b4-fa00-4ccf-9d1e-1dbde248e4c1", "images/Space Cowboy1.jpg", "1e38e0e9-e76b-462a-9141-13637859449c" },
                    { "972f4d45-21dc-44e8-88ea-b32c9a909d66", "images/House Espresso1.jpg", "780905a8-1505-4635-a3ed-2872625bd071" },
                    { "baf68520-d8d0-4e77-a412-1f28b244de02", "images/Decaf Fool's Gold.jpg", "ee38e0e9-e76b-462a-9141-13637859449c" },
                    { "de9fc892-6c6b-472d-9a31-899c4f2ad86d", "images/Space Cadet_2.jpg", "1ec624d5-25d0-4a5c-9d47-925be2439e70" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductVariantId", "Price", "ProductId", "Region", "RoastType", "Size", "Taste" },
                values: new object[,]
                {
                    { "230911de-b98f-48b9-851d-cad740f98765", 20.99m, "1ec624d5-25d0-4a5c-9d47-925be2439e70", 4, 1, 1, "Sweet & Smooth" },
                    { "24a1198d-43d2-49d1-9456-b7fe73989783", 25.99m, "780905a8-1505-4635-a3ed-2872625bd071", 0, 0, 2, "Syrupy & Smooth" },
                    { "86da4df6-a6c1-47d4-b83c-83be8b93a118", 35.99m, "1e38e0e9-e76b-462a-9141-13637859449c", 2, 2, 3, "Funky & Fruity" },
                    { "96a7265a-8d97-48ec-817e-b25487842ef4", 15.99m, "ee38e0e9-e76b-462a-9141-13637859449c", 2, 2, 1, "Comforting & Rich" },
                    { "ad29883c-ec71-48d9-b120-c4bbc86e7b54", 15.99m, "780905a8-1505-4635-a3ed-2872625bd071", 0, 0, 0, "Syrupy & Smooth" },
                    { "c43333f8-f79b-4471-87a1-094d3816ebbe", 20.99m, "780905a8-1505-4635-a3ed-2872625bd071", 0, 0, 1, "Syrupy & Smooth" },
                    { "f5425a73-22d2-46af-b736-f579f8eab0e3", 15.99m, "1ec624d5-25d0-4a5c-9d47-925be2439e70", 4, 1, 0, "Sweet & Smooth" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1e38e0e9-e76b-462a-9141-13637859449c",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3597), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3598), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1ec624d5-25d0-4a5c-9d47-925be2439e70",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3594), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3595), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "780905a8-1505-4635-a3ed-2872625bd071",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3585), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3591), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "ee38e0e9-e76b-462a-9141-13637859449c",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3601), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "635ea78b-7342-4a09-8a88-31abed328086", "00211442-2868-4a9a-9e68-58e5e7758806" },
                    { "189deef4-29cb-4003-9778-dba5205e2c58", "1a0453c8-2e51-482a-88a5-1957a44a9bdd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRating_ProductId",
                table: "ProductRating",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRating_UserId_ProductId",
                table: "ProductRating",
                columns: new[] { "UserId", "ProductId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRating");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "635ea78b-7342-4a09-8a88-31abed328086", "00211442-2868-4a9a-9e68-58e5e7758806" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "189deef4-29cb-4003-9778-dba5205e2c58", "1a0453c8-2e51-482a-88a5-1957a44a9bdd" });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "24ef8f35-7328-454e-a5b2-fab946ba10ef");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "35dd2f1f-fa72-431f-9235-a52bff9807fc");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "8eb7b4b4-fa00-4ccf-9d1e-1dbde248e4c1");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "972f4d45-21dc-44e8-88ea-b32c9a909d66");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "baf68520-d8d0-4e77-a412-1f28b244de02");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "de9fc892-6c6b-472d-9a31-899c4f2ad86d");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "230911de-b98f-48b9-851d-cad740f98765");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "24a1198d-43d2-49d1-9456-b7fe73989783");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "86da4df6-a6c1-47d4-b83c-83be8b93a118");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "96a7265a-8d97-48ec-817e-b25487842ef4");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "ad29883c-ec71-48d9-b120-c4bbc86e7b54");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "c43333f8-f79b-4471-87a1-094d3816ebbe");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "f5425a73-22d2-46af-b736-f579f8eab0e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "189deef4-29cb-4003-9778-dba5205e2c58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "635ea78b-7342-4a09-8a88-31abed328086");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00211442-2868-4a9a-9e68-58e5e7758806");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a0453c8-2e51-482a-88a5-1957a44a9bdd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a5f5f653-b99a-4386-89fe-df8a4f648ced", null, "Admin", "ADMIN" },
                    { "b12c236e-71ac-44b3-bd96-bc6b9f1c61de", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "07cc4645-0e6e-4c54-bd73-7b29f0f43d91", 0, "63763cac-100c-468c-9d54-61991c4e9c64", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEJUv/b40ndz1drC//RT9svvIcI7qw4vFWZKShXK80qfN/0zm6G0OI8sCyBFLmc8ifw==", null, false, "", false, "admin@gmail.com" },
                    { "812cb417-f054-45fb-853c-5521bf1dfffa", 0, "dd33f9da-61b0-422f-9bd2-443ff8d988e8", "IdentityUser", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEJTc+chSWPYtfsC5cu8yT3974harWVZdJQLuUugn0fN04LYqFNGJ82OmWnuDCNcmCA==", null, false, "", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { "1dc26aee-1906-493f-ac1d-bd17b9842f4c", "images/Space Cowboy1.jpg", "1e38e0e9-e76b-462a-9141-13637859449c" },
                    { "42697d79-1b58-42a9-9294-9bb0df906f15", "images/House Espresso1.jpg", "780905a8-1505-4635-a3ed-2872625bd071" },
                    { "c676a71a-cee1-4ddc-8876-550bcbc27515", "images/Space Cadet_1.jpg", "1ec624d5-25d0-4a5c-9d47-925be2439e70" },
                    { "c8b37d49-55d2-4532-8a61-621bbdc122a1", "images/Space Cadet_2.jpg", "1ec624d5-25d0-4a5c-9d47-925be2439e70" },
                    { "cfbcc452-03cf-4748-9b4c-c15ef55eecc2", "images/House Espresso2.jpg", "780905a8-1505-4635-a3ed-2872625bd071" },
                    { "db71938d-8681-47ca-9311-38fbe4a9b99d", "images/Decaf Fool's Gold.jpg", "ee38e0e9-e76b-462a-9141-13637859449c" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductVariantId", "Price", "ProductId", "Region", "RoastType", "Size", "Taste" },
                values: new object[,]
                {
                    { "2327e2ca-04e4-42b6-9ab0-2b315c804f78", 15.99m, "1ec624d5-25d0-4a5c-9d47-925be2439e70", 4, 1, 0, "Sweet & Smooth" },
                    { "5ace253a-2384-4813-bed4-edf1d0faea1f", 25.99m, "780905a8-1505-4635-a3ed-2872625bd071", 0, 0, 2, "Syrupy & Smooth" },
                    { "6cc1d192-436f-4116-b6f5-809a8ce4e4ba", 20.99m, "780905a8-1505-4635-a3ed-2872625bd071", 0, 0, 1, "Syrupy & Smooth" },
                    { "9afe29a9-4e66-42d2-a2bc-90e5b7f94cea", 35.99m, "1e38e0e9-e76b-462a-9141-13637859449c", 2, 2, 3, "Funky & Fruity" },
                    { "b6510274-c5cc-485f-9818-1b10ea05e84e", 15.99m, "ee38e0e9-e76b-462a-9141-13637859449c", 2, 2, 1, "Comforting & Rich" },
                    { "c4791eac-cad6-47fd-a054-7ebbd0d0d289", 20.99m, "1ec624d5-25d0-4a5c-9d47-925be2439e70", 4, 1, 1, "Sweet & Smooth" },
                    { "e82df5d8-43b9-4243-b1b2-abc9523f5427", 15.99m, "780905a8-1505-4635-a3ed-2872625bd071", 0, 0, 0, "Syrupy & Smooth" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1e38e0e9-e76b-462a-9141-13637859449c",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 27, 5, 5, 39, 571, DateTimeKind.Unspecified).AddTicks(1400), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 27, 5, 5, 39, 571, DateTimeKind.Unspecified).AddTicks(1401), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1ec624d5-25d0-4a5c-9d47-925be2439e70",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 27, 5, 5, 39, 571, DateTimeKind.Unspecified).AddTicks(1397), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 27, 5, 5, 39, 571, DateTimeKind.Unspecified).AddTicks(1398), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "780905a8-1505-4635-a3ed-2872625bd071",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 27, 5, 5, 39, 571, DateTimeKind.Unspecified).AddTicks(1391), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 27, 5, 5, 39, 571, DateTimeKind.Unspecified).AddTicks(1395), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "ee38e0e9-e76b-462a-9141-13637859449c",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 27, 5, 5, 39, 571, DateTimeKind.Unspecified).AddTicks(1402), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 27, 5, 5, 39, 571, DateTimeKind.Unspecified).AddTicks(1403), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a5f5f653-b99a-4386-89fe-df8a4f648ced", "07cc4645-0e6e-4c54-bd73-7b29f0f43d91" },
                    { "b12c236e-71ac-44b3-bd96-bc6b9f1c61de", "812cb417-f054-45fb-853c-5521bf1dfffa" }
                });
        }
    }
}
