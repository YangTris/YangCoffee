using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_seeding_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_UserId",
                table: "CartItems");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3f8cdb8-4db5-406c-928b-4c2a0e4f59e8", null, "Admin", "ADMIN" },
                    { "c20e8a9b-c473-4a5a-a6da-7e431fb93e47", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "37d0535e-1faa-4c34-94a7-c49b238ff949", 0, "6714ff92-dd53-44ee-b128-ed5c91687a77", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEMl6V+bAFRDwYEgRdF9L+8/sMt14e9DuWwpuT5xDQVDzyxwC0DOB+nJRmh5IL9uL6Q==", null, false, "", false, "admin@gmail.com" },
                    { "fdc25666-c716-4110-a1ab-5b6ba804622b", 0, "ef2db00f-0063-4b91-99c7-c7dace94da89", "IdentityUser", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEIUtgzhdn8FLWErRxMFvOP8XJPU8QOw8pm268LjTAgX/9RlKGifRtXkkL2t4UOAQEQ==", null, false, "", false, "user@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "4",
                column: "Name",
                value: "Decaf");

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { "0d333044-12a7-429c-b15f-9e2203b497a6", "images/Space Cadet_2.jpg", "1ec624d5-25d0-4a5c-9d47-925be2439e70" },
                    { "b41f46ef-2db8-420e-a02f-02c267c55761", "images/Space Cowboy1.jpg", "1e38e0e9-e76b-462a-9141-13637859449c" },
                    { "d8a6dc3c-49e0-40b7-9d68-853a6d396989", "images/House Espresso2.jpg", "780905a8-1505-4635-a3ed-2872625bd071" },
                    { "f9d3fd50-6d19-4158-8c74-102738110f1b", "images/Space Cadet_1.jpg", "1ec624d5-25d0-4a5c-9d47-925be2439e70" },
                    { "ffe22b83-2eab-468d-ba22-64a75b12b09c", "images/House Espresso1.jpg", "780905a8-1505-4635-a3ed-2872625bd071" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductVariantId", "Price", "ProductId", "Region", "RoastType", "Size", "Taste" },
                values: new object[,]
                {
                    { "75bfd1c0-6a43-4972-8a58-fc69cebfa72e", 25.99m, "780905a8-1505-4635-a3ed-2872625bd071", 0, 0, 2, "Syrupy & Smooth" },
                    { "887dd94e-0f4c-49f0-86bd-120e41ac76db", 35.99m, "1e38e0e9-e76b-462a-9141-13637859449c", 2, 2, 3, "Funky & Fruity" },
                    { "ba72334c-ba2c-4b9b-bcdc-c8e5c899f4a6", 20.99m, "1ec624d5-25d0-4a5c-9d47-925be2439e70", 4, 1, 1, "Sweet & Smooth" },
                    { "c0f7e45c-3747-4577-b0c4-910a9787c440", 15.99m, "780905a8-1505-4635-a3ed-2872625bd071", 0, 0, 0, "Syrupy & Smooth" },
                    { "eb1cefbf-fa69-4d1c-997c-e2dd40d61b2b", 20.99m, "780905a8-1505-4635-a3ed-2872625bd071", 0, 0, 1, "Syrupy & Smooth" },
                    { "f08b20a0-197c-49b6-90fb-470b551fd9a5", 15.99m, "1ec624d5-25d0-4a5c-9d47-925be2439e70", 4, 1, 0, "Sweet & Smooth" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1e38e0e9-e76b-462a-9141-13637859449c",
                columns: new[] { "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7628), new TimeSpan(0, 0, 0, 0, 0)), "Blast off with this delightfully soft and fruity coffee sourced from Mrs. Tigest Wako's small farm in the famous Yirgacheffe region of Ethiopia.", new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7628), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1ec624d5-25d0-4a5c-9d47-925be2439e70",
                columns: new[] { "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7626), new TimeSpan(0, 0, 0, 0, 0)), "Extra smooth, extra chocolaty-sweet, and dare we say...extraterrestrial? A splash of ripe cherry juiciness makes this crowd-pleasing cup every bit as delicious hot as it is cold.", new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7626), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "780905a8-1505-4635-a3ed-2872625bd071",
                columns: new[] { "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7618), new TimeSpan(0, 0, 0, 0, 0)), "No competition here: This much-awarded espresso blend puts its game face on in the form of semi-sweet, zesty, full-body flavored. Plays well with milk.", new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7622), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BasePrice", "CategoryId", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[] { "ee38e0e9-e76b-462a-9141-13637859449c", 25.99m, "4", new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7631), new TimeSpan(0, 0, 0, 0, 0)), "This decaf is heavy on chocolate flavor with a little fruity complexity in there as well; you won't feel like a fool drinking it.", "Decaf Fool's Gold", new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7631), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a3f8cdb8-4db5-406c-928b-4c2a0e4f59e8", "37d0535e-1faa-4c34-94a7-c49b238ff949" },
                    { "c20e8a9b-c473-4a5a-a6da-7e431fb93e47", "fdc25666-c716-4110-a1ab-5b6ba804622b" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ImageUrl", "ProductId" },
                values: new object[] { "61c033c7-a9a9-43a8-8e85-1b4dcc56ccc8", "images/Decaf Fool's Gold.jpg", "ee38e0e9-e76b-462a-9141-13637859449c" });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductVariantId", "Price", "ProductId", "Region", "RoastType", "Size", "Taste" },
                values: new object[] { "bc77cde7-9240-41b6-8584-88eaee05ad35", 15.99m, "ee38e0e9-e76b-462a-9141-13637859449c", 2, 2, 1, "Comforting & Rich" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a3f8cdb8-4db5-406c-928b-4c2a0e4f59e8", "37d0535e-1faa-4c34-94a7-c49b238ff949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c20e8a9b-c473-4a5a-a6da-7e431fb93e47", "fdc25666-c716-4110-a1ab-5b6ba804622b" });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "0d333044-12a7-429c-b15f-9e2203b497a6");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "61c033c7-a9a9-43a8-8e85-1b4dcc56ccc8");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "b41f46ef-2db8-420e-a02f-02c267c55761");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "d8a6dc3c-49e0-40b7-9d68-853a6d396989");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "f9d3fd50-6d19-4158-8c74-102738110f1b");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "ffe22b83-2eab-468d-ba22-64a75b12b09c");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "75bfd1c0-6a43-4972-8a58-fc69cebfa72e");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "887dd94e-0f4c-49f0-86bd-120e41ac76db");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "ba72334c-ba2c-4b9b-bcdc-c8e5c899f4a6");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "bc77cde7-9240-41b6-8584-88eaee05ad35");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "c0f7e45c-3747-4577-b0c4-910a9787c440");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "eb1cefbf-fa69-4d1c-997c-e2dd40d61b2b");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "f08b20a0-197c-49b6-90fb-470b551fd9a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3f8cdb8-4db5-406c-928b-4c2a0e4f59e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c20e8a9b-c473-4a5a-a6da-7e431fb93e47");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "37d0535e-1faa-4c34-94a7-c49b238ff949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fdc25666-c716-4110-a1ab-5b6ba804622b");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "ee38e0e9-e76b-462a-9141-13637859449c");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "CartItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                newName: "IX_CartItems_UserId");

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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "4",
                column: "Name",
                value: "Cold Brew");

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
                columns: new[] { "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 22, 7, 55, 1, 28, DateTimeKind.Unspecified).AddTicks(8408), new TimeSpan(0, 0, 0, 0, 0)), "High-quality French press for coffee brewing.", new DateTimeOffset(new DateTime(2025, 4, 22, 7, 55, 1, 28, DateTimeKind.Unspecified).AddTicks(8409), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1ec624d5-25d0-4a5c-9d47-925be2439e70",
                columns: new[] { "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 22, 7, 55, 1, 28, DateTimeKind.Unspecified).AddTicks(8405), new TimeSpan(0, 0, 0, 0, 0)), "Refreshing and healthy green tea.", new DateTimeOffset(new DateTime(2025, 4, 22, 7, 55, 1, 28, DateTimeKind.Unspecified).AddTicks(8406), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "780905a8-1505-4635-a3ed-2872625bd071",
                columns: new[] { "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 22, 7, 55, 1, 28, DateTimeKind.Unspecified).AddTicks(8396), new TimeSpan(0, 0, 0, 0, 0)), "Rich and aromatic Ethiopian coffee beans.", new DateTimeOffset(new DateTime(2025, 4, 22, 7, 55, 1, 28, DateTimeKind.Unspecified).AddTicks(8401), new TimeSpan(0, 0, 0, 0, 0)) });

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
    }
}
