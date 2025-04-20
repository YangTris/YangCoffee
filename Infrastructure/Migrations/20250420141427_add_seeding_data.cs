using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_seeding_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f7c497f1-ae7d-4d10-b67a-e6944292611b", null, "Admin", "ADMIN" },
                    { "f9b5c2d9-ca5a-46a0-8f9c-14716a52cc51", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "126cd1d9-1b88-4419-9b44-a818e309f57e", 0, "a4bb0c7e-8c11-4b54-9ad3-0ab30441395a", "IdentityUser", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEP6BLflQH7MHaT3sa9n+ahLNHViMnzyeZIe0Xb/FmALr665n5n6Vghorw2OmB4NPjw==", null, false, "", false, "user@gmail.com" },
                    { "b7314aaa-730e-41a8-93f3-928ee44a7fbf", 0, "9aff8f93-b6d4-4d58-a951-4ccf6b114111", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEM2OiVRgo1SPcfNWcv2DUhByEFCIhbQs5cL8AKaS5+DX31oyOpSOIt+kf+KyaunnKA==", null, false, "", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { "1", "Various types of coffee beans.", "Espresso" },
                    { "2", "Mixing flavor of many type of coffee", "Blends" },
                    { "3", "Different varieties of tea.", "Single Origins" },
                    { "4", "Coffee and tea accessories.", "Cold Brew" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ImageUrl", "ProductVariantId" },
                values: new object[,]
                {
                    { "4523c1b9-f58a-44ef-aebf-f758ab5c4ed9", "images/Space Cadet_2.jpg", "<ProductVariantId of Space Cadet Variant>" },
                    { "4f71b661-bf93-4a5c-a193-cea0c42da2b0", "images/House Espresso1.jpg", "<ProductVariantId of House Espresso Variant>" },
                    { "a31fb0d1-4169-49d2-a978-34e8c1bfa16e", "images/Space Cowboy1.jpg", "<ProductVariantId of Space Cowboy Variant>" },
                    { "b6b38775-33cd-4d9d-ac28-440eee18cf98", "images/House Espresso2.jpg", "<ProductVariantId of House Espresso Variant>" },
                    { "d71da609-8afc-43f9-84be-299894801727", "images/Space Cadet_1.jpg", "<ProductVariantId of Space Cadet Variant>" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductVariantId", "Price", "ProductId", "Region", "RoastType", "Size", "Taste" },
                values: new object[] { "9f890562-a4f0-4e71-a06a-9bb2d15e3efe", 15.99m, "<ProductId of House Espresso>", 0, 0, 1, "Syrupy & Smooth" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f9b5c2d9-ca5a-46a0-8f9c-14716a52cc51", "0a44d0b3-a1a2-4931-82a1-f227a86a228f" },
                    { "f7c497f1-ae7d-4d10-b67a-e6944292611b", "b7314aaa-730e-41a8-93f3-928ee44a7fbf" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BaseImageUrl", "BasePrice", "CategoryId", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { "2", "images/Space Cadet.jpg", 9.99m, "2", new DateTimeOffset(new DateTime(2025, 4, 20, 14, 14, 19, 816, DateTimeKind.Unspecified).AddTicks(4323), new TimeSpan(0, 0, 0, 0, 0)), "Refreshing and healthy green tea.", "Space Cadet", new DateTimeOffset(new DateTime(2025, 4, 20, 14, 14, 19, 816, DateTimeKind.Unspecified).AddTicks(4324), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "3", "images/Space Cowboy.jpg", 25.99m, "3", new DateTimeOffset(new DateTime(2025, 4, 20, 14, 14, 19, 816, DateTimeKind.Unspecified).AddTicks(4326), new TimeSpan(0, 0, 0, 0, 0)), "High-quality French press for coffee brewing.", "Space Cowboy", new DateTimeOffset(new DateTime(2025, 4, 20, 14, 14, 19, 816, DateTimeKind.Unspecified).AddTicks(4327), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "42161f36-47fd-4990-978a-a9139a5c5051", "images/House Espresso.jpg", 15.99m, "1", new DateTimeOffset(new DateTime(2025, 4, 20, 14, 14, 19, 816, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 0, 0, 0, 0)), "Rich and aromatic Ethiopian coffee beans.", "House Espresso", new DateTimeOffset(new DateTime(2025, 4, 20, 14, 14, 19, 816, DateTimeKind.Unspecified).AddTicks(4320), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductVariantId", "Price", "ProductId", "Region", "RoastType", "Size", "Taste" },
                values: new object[,]
                {
                    { "702ef471-b890-4b9c-8319-0819ccb3073a", 15.99m, "2", 4, 0, 0, "Sweet & Smooth" },
                    { "8565d9e6-4e63-4ef3-98f2-bd9e766f6948", 15.99m, "3", 2, 2, 3, "Funky & Fruity" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f9b5c2d9-ca5a-46a0-8f9c-14716a52cc51", "0a44d0b3-a1a2-4931-82a1-f227a86a228f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f7c497f1-ae7d-4d10-b67a-e6944292611b", "b7314aaa-730e-41a8-93f3-928ee44a7fbf" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "126cd1d9-1b88-4419-9b44-a818e309f57e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "4523c1b9-f58a-44ef-aebf-f758ab5c4ed9");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "4f71b661-bf93-4a5c-a193-cea0c42da2b0");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "a31fb0d1-4169-49d2-a978-34e8c1bfa16e");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "b6b38775-33cd-4d9d-ac28-440eee18cf98");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "d71da609-8afc-43f9-84be-299894801727");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "702ef471-b890-4b9c-8319-0819ccb3073a");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "8565d9e6-4e63-4ef3-98f2-bd9e766f6948");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "9f890562-a4f0-4e71-a06a-9bb2d15e3efe");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "42161f36-47fd-4990-978a-a9139a5c5051");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7c497f1-ae7d-4d10-b67a-e6944292611b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b5c2d9-ca5a-46a0-8f9c-14716a52cc51");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7314aaa-730e-41a8-93f3-928ee44a7fbf");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "3");
        }
    }
}
