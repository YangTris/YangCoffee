using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Cart_and_CartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserId",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f3744b36-59bb-4b17-804f-3549e61828f4", "03108024-09e9-429c-92f8-dc2ebb6cfbdd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6df63964-00cc-4a71-992d-05bfd29d7bec", "0d970ea5-100d-4f4c-9de9-d05defdce6f8" });

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

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "CartItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                newName: "IX_CartItems_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "69fd56b6-4332-4c85-9232-56df06d20b78", null, "User", "USER" },
                    { "cea37379-127e-4717-87d7-83d5d0d8bf5a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d5c1e357-382b-4d70-9153-96f825a8cc2b", 0, "29ce23bd-3f66-46bc-b098-a09f52afc252", "IdentityUser", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEAnIVBLDQugc2nHDVyrxRjvXvIWBTgoMchfwe3fZ2ytWsDzsHS7ZtGdnp6lYL6tkvg==", null, false, "", false, "user@gmail.com" },
                    { "e3041fc7-b72a-46e4-8afc-2c180ace64bb", 0, "5df03fab-543a-42e8-ac67-679094d48ef6", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKZquVbU08eIhIK6/QFfhs0flVkTvaxAdYvlQDwpeOGB57a8qqFKjlQUZveQBXxlVQ==", null, false, "", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { "5ff3a598-29ea-4672-a1c5-f74f7b19dff3", "images/Space Cowboy1.jpg", "1e38e0e9-e76b-462a-9141-13637859449c" },
                    { "a0a939e2-7fa9-49ee-afa4-bf99c0c0ea38", "images/Space Cadet_1.jpg", "1ec624d5-25d0-4a5c-9d47-925be2439e70" },
                    { "a15d6ba4-688d-469e-a16d-dbb0bec00b75", "images/House Espresso2.jpg", "780905a8-1505-4635-a3ed-2872625bd071" },
                    { "b3de0b75-a1db-4516-8b9b-da544a13ca65", "images/House Espresso1.jpg", "780905a8-1505-4635-a3ed-2872625bd071" },
                    { "de7b45ea-bb1b-49a8-9f41-b67b594bc716", "images/Space Cadet_2.jpg", "1ec624d5-25d0-4a5c-9d47-925be2439e70" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductVariantId", "Price", "ProductId", "Region", "RoastType", "Size", "Taste" },
                values: new object[,]
                {
                    { "0350cfd2-2ad8-4d78-af2e-1a74dea5ec38", 15.99m, "780905a8-1505-4635-a3ed-2872625bd071", 0, 0, 1, "Syrupy & Smooth" },
                    { "4e392981-17ac-4c7c-8295-d0a593da4ce6", 15.99m, "1ec624d5-25d0-4a5c-9d47-925be2439e70", 4, 0, 0, "Sweet & Smooth" },
                    { "7ab5b713-2d74-4416-8e35-f705fe7f200e", 15.99m, "1e38e0e9-e76b-462a-9141-13637859449c", 2, 2, 3, "Funky & Fruity" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1e38e0e9-e76b-462a-9141-13637859449c",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 22, 7, 55, 1, 28, DateTimeKind.Unspecified).AddTicks(8408), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 22, 7, 55, 1, 28, DateTimeKind.Unspecified).AddTicks(8409), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1ec624d5-25d0-4a5c-9d47-925be2439e70",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 22, 7, 55, 1, 28, DateTimeKind.Unspecified).AddTicks(8405), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 22, 7, 55, 1, 28, DateTimeKind.Unspecified).AddTicks(8406), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "780905a8-1505-4635-a3ed-2872625bd071",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 22, 7, 55, 1, 28, DateTimeKind.Unspecified).AddTicks(8396), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 22, 7, 55, 1, 28, DateTimeKind.Unspecified).AddTicks(8401), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "69fd56b6-4332-4c85-9232-56df06d20b78", "d5c1e357-382b-4d70-9153-96f825a8cc2b" },
                    { "cea37379-127e-4717-87d7-83d5d0d8bf5a", "e3041fc7-b72a-46e4-8afc-2c180ace64bb" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_UserId",
                table: "CartItems",
                column: "UserId",
                principalTable: "Carts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_UserId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "69fd56b6-4332-4c85-9232-56df06d20b78", "d5c1e357-382b-4d70-9153-96f825a8cc2b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cea37379-127e-4717-87d7-83d5d0d8bf5a", "e3041fc7-b72a-46e4-8afc-2c180ace64bb" });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "5ff3a598-29ea-4672-a1c5-f74f7b19dff3");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "a0a939e2-7fa9-49ee-afa4-bf99c0c0ea38");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "a15d6ba4-688d-469e-a16d-dbb0bec00b75");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "b3de0b75-a1db-4516-8b9b-da544a13ca65");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "de7b45ea-bb1b-49a8-9f41-b67b594bc716");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "0350cfd2-2ad8-4d78-af2e-1a74dea5ec38");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "4e392981-17ac-4c7c-8295-d0a593da4ce6");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "7ab5b713-2d74-4416-8e35-f705fe7f200e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69fd56b6-4332-4c85-9232-56df06d20b78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cea37379-127e-4717-87d7-83d5d0d8bf5a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5c1e357-382b-4d70-9153-96f825a8cc2b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e3041fc7-b72a-46e4-8afc-2c180ace64bb");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CartItems",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                newName: "IX_CartItems_CartId");

            migrationBuilder.AddColumn<string>(
                name: "CartId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "CartId");

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1e38e0e9-e76b-462a-9141-13637859449c",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 21, 2, 43, 56, 401, DateTimeKind.Unspecified).AddTicks(7623), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 21, 2, 43, 56, 401, DateTimeKind.Unspecified).AddTicks(7624), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1ec624d5-25d0-4a5c-9d47-925be2439e70",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 21, 2, 43, 56, 401, DateTimeKind.Unspecified).AddTicks(7621), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 21, 2, 43, 56, 401, DateTimeKind.Unspecified).AddTicks(7622), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "780905a8-1505-4635-a3ed-2872625bd071",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 21, 2, 43, 56, 401, DateTimeKind.Unspecified).AddTicks(7612), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 21, 2, 43, 56, 401, DateTimeKind.Unspecified).AddTicks(7618), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f3744b36-59bb-4b17-804f-3549e61828f4", "03108024-09e9-429c-92f8-dc2ebb6cfbdd" },
                    { "6df63964-00cc-4a71-992d-05bfd29d7bec", "0d970ea5-100d-4f4c-9de9-d05defdce6f8" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
