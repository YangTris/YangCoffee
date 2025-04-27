using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "ShippingAddress");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Orders",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

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

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress",
                table: "Orders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Orders",
                newName: "Address");

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

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { "0d333044-12a7-429c-b15f-9e2203b497a6", "images/Space Cadet_2.jpg", "1ec624d5-25d0-4a5c-9d47-925be2439e70" },
                    { "61c033c7-a9a9-43a8-8e85-1b4dcc56ccc8", "images/Decaf Fool's Gold.jpg", "ee38e0e9-e76b-462a-9141-13637859449c" },
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
                    { "bc77cde7-9240-41b6-8584-88eaee05ad35", 15.99m, "ee38e0e9-e76b-462a-9141-13637859449c", 2, 2, 1, "Comforting & Rich" },
                    { "c0f7e45c-3747-4577-b0c4-910a9787c440", 15.99m, "780905a8-1505-4635-a3ed-2872625bd071", 0, 0, 0, "Syrupy & Smooth" },
                    { "eb1cefbf-fa69-4d1c-997c-e2dd40d61b2b", 20.99m, "780905a8-1505-4635-a3ed-2872625bd071", 0, 0, 1, "Syrupy & Smooth" },
                    { "f08b20a0-197c-49b6-90fb-470b551fd9a5", 15.99m, "1ec624d5-25d0-4a5c-9d47-925be2439e70", 4, 1, 0, "Sweet & Smooth" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1e38e0e9-e76b-462a-9141-13637859449c",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7628), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7628), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1ec624d5-25d0-4a5c-9d47-925be2439e70",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7626), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7626), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "780905a8-1505-4635-a3ed-2872625bd071",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7618), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7622), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "ee38e0e9-e76b-462a-9141-13637859449c",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7631), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 23, 3, 53, 45, 299, DateTimeKind.Unspecified).AddTicks(7631), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a3f8cdb8-4db5-406c-928b-4c2a0e4f59e8", "37d0535e-1faa-4c34-94a7-c49b238ff949" },
                    { "c20e8a9b-c473-4a5a-a6da-7e431fb93e47", "fdc25666-c716-4110-a1ab-5b6ba804622b" }
                });
        }
    }
}
