using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_seedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "ee38e0e9-e76b-462a-9141-13637859449c");

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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a60b77d6-3232-46a2-a6eb-972365fa4948", null, "Admin", "ADMIN" },
                    { "b1b93ae0-9154-4e17-af76-abc16d8e9d82", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "232da8e9-a269-4ef4-8d20-cdeaee3e83a1", 0, "88e46c9f-0708-43ea-a2cc-d347a39093f3", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENq9Qjp+ziTvquA8h5K+6jXG3ttOr+05WqJkzp40H/SJSAfzJQZfjOyKg6B0aowq2Q==", null, false, "", false, "admin@gmail.com" },
                    { "5849aed2-c281-4e75-9449-297f75ca8c3d", 0, "342f74d2-2a28-458f-be0b-961edcbeb639", "IdentityUser", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAELvjnsHmnZERdfoh7K5unZ58qu8LuTnqWil5aXnABMpykFlVs3HehVuHyANtG8Zbjw==", null, false, "", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { "00000000000000000000000001", "Various types of coffee beans.", "Espresso" },
                    { "00000000000000000000000002", "Mixing flavor of many type of coffee", "Blends" },
                    { "00000000000000000000000003", "Different varieties of tea.", "Single Origins" },
                    { "00000000000000000000000004", "Coffee and tea accessories.", "Decaf" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a60b77d6-3232-46a2-a6eb-972365fa4948", "232da8e9-a269-4ef4-8d20-cdeaee3e83a1" },
                    { "b1b93ae0-9154-4e17-af76-abc16d8e9d82", "5849aed2-c281-4e75-9449-297f75ca8c3d" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BasePrice", "CategoryId", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { "10000000000000000000000000", 15.99m, "00000000000000000000000001", new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8021), new TimeSpan(0, 0, 0, 0, 0)), "No competition here: This much-awarded espresso blend puts its game face on in the form of semi-sweet, zesty, full-body flavored. Plays well with milk.", "House Espresso", new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8027), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "20000000000000000000000000", 9.99m, "00000000000000000000000002", new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8031), new TimeSpan(0, 0, 0, 0, 0)), "Extra smooth, extra chocolaty-sweet, and dare we say...extraterrestrial? A splash of ripe cherry juiciness makes this crowd-pleasing cup every bit as delicious hot as it is cold.", "Space Cadet", new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8031), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "30000000000000000000000000", 25.99m, "00000000000000000000000003", new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8033), new TimeSpan(0, 0, 0, 0, 0)), "Blast off with this delightfully soft and fruity coffee sourced from Mrs. Tigest Wako's small farm in the famous Yirgacheffe region of Ethiopia.", "Space Cowboy", new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8034), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "40000000000000000000000000", 25.99m, "00000000000000000000000004", new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8035), new TimeSpan(0, 0, 0, 0, 0)), "This decaf is heavy on chocolate flavor with a little fruity complexity in there as well; you won't feel like a fool drinking it.", "Decaf Fool's Gold", new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8036), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { "0023df9f-fb52-4a19-bb38-2b263cda8fe9", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521212425_sighjyhliefukn8dygvd.png", "20000000000000000000000000" },
                    { "773abed7-adec-4f88-87fa-d2f0ae403abd", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521212425_sighjyhliefukn8dygvd.png", "30000000000000000000000000" },
                    { "a86e0467-c8e0-4004-9dc6-b66d1642e29f", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521222472_TRD00133_HUC_Bom_Senso_V2.png", "10000000000000000000000000" },
                    { "a99907b9-2e2b-4bea-be1c-3bfbafd3f511", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521220065_TRD00132_SPA_High_Five_Blend_Main.png", "40000000000000000000000000" },
                    { "bac06d65-2326-454a-9725-0e39157754af", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521226038_w73vhyjhu1y3odxqvnjt.png", "30000000000000000000000000" },
                    { "f06f9465-6414-4628-b055-ba92b66a9190", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521209682_FamiliaPeixotoUpdated.png", "20000000000000000000000000" },
                    { "f9be4094-e10e-4880-b8ad-1903c8713401", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521229043_WONdriftlessupdated_eda49ff4-e067-4393-9515-ef748e528bb6.png", "10000000000000000000000000" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductVariantId", "Price", "ProductId", "Region", "RoastType", "Size", "Taste" },
                values: new object[,]
                {
                    { "00000000000000000000000001", 20.99m, "10000000000000000000000000", 0, 0, 1, "Syrupy & Smooth" },
                    { "00000000000000000000000002", 25.99m, "20000000000000000000000000", 0, 0, 2, "Syrupy & Smooth" },
                    { "00000000000000000000000003", 15.99m, "30000000000000000000000000", 0, 0, 0, "Syrupy & Smooth" },
                    { "00000000000000000000000004", 15.99m, "40000000000000000000000000", 4, 1, 0, "Sweet & Smooth" },
                    { "00000000000000000000000005", 20.99m, "10000000000000000000000000", 4, 1, 1, "Sweet & Smooth" },
                    { "00000000000000000000000006", 35.99m, "20000000000000000000000000", 2, 2, 3, "Funky & Fruity" },
                    { "00000000000000000000000007", 15.99m, "30000000000000000000000000", 2, 2, 1, "Comforting & Rich" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a60b77d6-3232-46a2-a6eb-972365fa4948", "232da8e9-a269-4ef4-8d20-cdeaee3e83a1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b1b93ae0-9154-4e17-af76-abc16d8e9d82", "5849aed2-c281-4e75-9449-297f75ca8c3d" });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "0023df9f-fb52-4a19-bb38-2b263cda8fe9");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "773abed7-adec-4f88-87fa-d2f0ae403abd");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "a86e0467-c8e0-4004-9dc6-b66d1642e29f");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "a99907b9-2e2b-4bea-be1c-3bfbafd3f511");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "bac06d65-2326-454a-9725-0e39157754af");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "f06f9465-6414-4628-b055-ba92b66a9190");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "f9be4094-e10e-4880-b8ad-1903c8713401");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "00000000000000000000000001");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "00000000000000000000000002");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "00000000000000000000000003");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "00000000000000000000000004");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "00000000000000000000000005");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "00000000000000000000000006");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "ProductVariantId",
                keyValue: "00000000000000000000000007");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a60b77d6-3232-46a2-a6eb-972365fa4948");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1b93ae0-9154-4e17-af76-abc16d8e9d82");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "232da8e9-a269-4ef4-8d20-cdeaee3e83a1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5849aed2-c281-4e75-9449-297f75ca8c3d");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "10000000000000000000000000");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "20000000000000000000000000");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "30000000000000000000000000");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "40000000000000000000000000");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "00000000000000000000000001");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "00000000000000000000000002");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "00000000000000000000000003");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "00000000000000000000000004");

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
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { "1", "Various types of coffee beans.", "Espresso" },
                    { "2", "Mixing flavor of many type of coffee", "Blends" },
                    { "3", "Different varieties of tea.", "Single Origins" },
                    { "4", "Coffee and tea accessories.", "Decaf" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "635ea78b-7342-4a09-8a88-31abed328086", "00211442-2868-4a9a-9e68-58e5e7758806" },
                    { "189deef4-29cb-4003-9778-dba5205e2c58", "1a0453c8-2e51-482a-88a5-1957a44a9bdd" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BasePrice", "CategoryId", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { "1e38e0e9-e76b-462a-9141-13637859449c", 25.99m, "3", new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3597), new TimeSpan(0, 0, 0, 0, 0)), "Blast off with this delightfully soft and fruity coffee sourced from Mrs. Tigest Wako's small farm in the famous Yirgacheffe region of Ethiopia.", "Space Cowboy", new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3598), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "1ec624d5-25d0-4a5c-9d47-925be2439e70", 9.99m, "2", new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3594), new TimeSpan(0, 0, 0, 0, 0)), "Extra smooth, extra chocolaty-sweet, and dare we say...extraterrestrial? A splash of ripe cherry juiciness makes this crowd-pleasing cup every bit as delicious hot as it is cold.", "Space Cadet", new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3595), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "780905a8-1505-4635-a3ed-2872625bd071", 15.99m, "1", new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3585), new TimeSpan(0, 0, 0, 0, 0)), "No competition here: This much-awarded espresso blend puts its game face on in the form of semi-sweet, zesty, full-body flavored. Plays well with milk.", "House Espresso", new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3591), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "ee38e0e9-e76b-462a-9141-13637859449c", 25.99m, "4", new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 0, 0, 0, 0)), "This decaf is heavy on chocolate flavor with a little fruity complexity in there as well; you won't feel like a fool drinking it.", "Decaf Fool's Gold", new DateTimeOffset(new DateTime(2025, 5, 6, 8, 37, 35, 597, DateTimeKind.Unspecified).AddTicks(3601), new TimeSpan(0, 0, 0, 0, 0)) }
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
        }
    }
}
