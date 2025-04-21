using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeding_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductVariants_ProductVariantId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "BaseImageUrl",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductVariantId",
                table: "ProductImages",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductVariantId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6df63964-00cc-4a71-992d-05bfd29d7bec", null, "Admin", "ADMIN" },
                    { "f3744b36-59bb-4b17-804f-3549e61828f4", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "03108024-09e9-429c-92f8-dc2ebb6cfbdd", 0, "e8a94504-950b-4ea0-b43a-30a5fefedd49", "IdentityUser", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEF2SRKaP7eko50LbIZi0Oy1em7Bfc9tWMcM7VfbI6Yr5cBzGq4Tgvg8A7rHEDwOugQ==", null, false, "", false, "user@gmail.com" },
                    { "0d970ea5-100d-4f4c-9de9-d05defdce6f8", 0, "5a6e9f06-8e73-4c25-bd3f-f3401ba79f06", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEPjkMAhQSl1iilGSh7zinEbahIr1wLwtN2ynWO0wM0BAWWfV3wSiGikkbMjfMTqQjw==", null, false, "", false, "admin@gmail.com" }
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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f3744b36-59bb-4b17-804f-3549e61828f4", "03108024-09e9-429c-92f8-dc2ebb6cfbdd" },
                    { "6df63964-00cc-4a71-992d-05bfd29d7bec", "0d970ea5-100d-4f4c-9de9-d05defdce6f8" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BasePrice", "CategoryId", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { "1e38e0e9-e76b-462a-9141-13637859449c", 25.99m, "3", new DateTimeOffset(new DateTime(2025, 4, 21, 2, 43, 56, 401, DateTimeKind.Unspecified).AddTicks(7623), new TimeSpan(0, 0, 0, 0, 0)), "High-quality French press for coffee brewing.", "Space Cowboy", new DateTimeOffset(new DateTime(2025, 4, 21, 2, 43, 56, 401, DateTimeKind.Unspecified).AddTicks(7624), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "1ec624d5-25d0-4a5c-9d47-925be2439e70", 9.99m, "2", new DateTimeOffset(new DateTime(2025, 4, 21, 2, 43, 56, 401, DateTimeKind.Unspecified).AddTicks(7621), new TimeSpan(0, 0, 0, 0, 0)), "Refreshing and healthy green tea.", "Space Cadet", new DateTimeOffset(new DateTime(2025, 4, 21, 2, 43, 56, 401, DateTimeKind.Unspecified).AddTicks(7622), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "780905a8-1505-4635-a3ed-2872625bd071", 15.99m, "1", new DateTimeOffset(new DateTime(2025, 4, 21, 2, 43, 56, 401, DateTimeKind.Unspecified).AddTicks(7612), new TimeSpan(0, 0, 0, 0, 0)), "Rich and aromatic Ethiopian coffee beans.", "House Espresso", new DateTimeOffset(new DateTime(2025, 4, 21, 2, 43, 56, 401, DateTimeKind.Unspecified).AddTicks(7618), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { "1a0e7d05-6b27-4b31-a64d-21acf674f117", "images/House Espresso1.jpg", "780905a8-1505-4635-a3ed-2872625bd071" },
                    { "209121d9-5925-4d0d-a1b4-f19910ad8400", "images/Space Cadet_1.jpg", "1ec624d5-25d0-4a5c-9d47-925be2439e70" },
                    { "24fa386d-31c3-4af1-8419-9c75c4ca684b", "images/Space Cadet_2.jpg", "1ec624d5-25d0-4a5c-9d47-925be2439e70" },
                    { "2c647d5f-e724-4d73-b7b4-03175c4a4d23", "images/House Espresso2.jpg", "780905a8-1505-4635-a3ed-2872625bd071" },
                    { "88b4662a-abd8-4f17-9c71-2ae409293b61", "images/Space Cowboy1.jpg", "1e38e0e9-e76b-462a-9141-13637859449c" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductVariantId", "Price", "ProductId", "Region", "RoastType", "Size", "Taste" },
                values: new object[,]
                {
                    { "18977b5e-b2c6-46b8-be67-26920a2802f1", 15.99m, "1ec624d5-25d0-4a5c-9d47-925be2439e70", 4, 0, 0, "Sweet & Smooth" },
                    { "c0203709-dd05-41e7-8e28-767a7a594102", 15.99m, "1e38e0e9-e76b-462a-9141-13637859449c", 2, 2, 3, "Funky & Fruity" },
                    { "edaefb73-0674-4013-af6a-e4a528ddab35", 15.99m, "780905a8-1505-4635-a3ed-2872625bd071", 0, 0, 1, "Syrupy & Smooth" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f3744b36-59bb-4b17-804f-3549e61828f4", "03108024-09e9-429c-92f8-dc2ebb6cfbdd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6df63964-00cc-4a71-992d-05bfd29d7bec", "0d970ea5-100d-4f4c-9de9-d05defdce6f8" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "1a0e7d05-6b27-4b31-a64d-21acf674f117");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "209121d9-5925-4d0d-a1b4-f19910ad8400");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "24fa386d-31c3-4af1-8419-9c75c4ca684b");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "2c647d5f-e724-4d73-b7b4-03175c4a4d23");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "88b4662a-abd8-4f17-9c71-2ae409293b61");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "18977b5e-b2c6-46b8-be67-26920a2802f1");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "c0203709-dd05-41e7-8e28-767a7a594102");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "edaefb73-0674-4013-af6a-e4a528ddab35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6df63964-00cc-4a71-992d-05bfd29d7bec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3744b36-59bb-4b17-804f-3549e61828f4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03108024-09e9-429c-92f8-dc2ebb6cfbdd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d970ea5-100d-4f4c-9de9-d05defdce6f8");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1e38e0e9-e76b-462a-9141-13637859449c");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1ec624d5-25d0-4a5c-9d47-925be2439e70");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "780905a8-1505-4635-a3ed-2872625bd071");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "3");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductImages",
                newName: "ProductVariantId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductVariantId");

            migrationBuilder.AddColumn<string>(
                name: "BaseImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductVariants_ProductVariantId",
                table: "ProductImages",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "ProductVariantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
