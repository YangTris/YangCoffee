using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_DB_ProductRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRating_AspNetUsers_UserId",
                table: "ProductRating");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRating_Products_ProductId",
                table: "ProductRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRating",
                table: "ProductRating");

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

            migrationBuilder.RenameTable(
                name: "ProductRating",
                newName: "ProductRatings");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRating_UserId_ProductId",
                table: "ProductRatings",
                newName: "IX_ProductRatings_UserId_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRating_ProductId",
                table: "ProductRatings",
                newName: "IX_ProductRatings_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRatings",
                table: "ProductRatings",
                column: "ProductRatingId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ef386c5-d1fd-4a48-b244-4c8b46036ca4", null, "User", "USER" },
                    { "77d61071-d580-4c8b-a37f-08dfbe0b4f8d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "28531d53-fea2-45c9-a75c-67190248884a", 0, "c9a09204-08ca-41ab-8469-ce6c4db8cea4", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEN74j8ws/9hrFGDgIvjusqYKCYIOU+psFTIN7i2nyrPOomOlh5zO9bL5UxIIPAPieQ==", null, false, "", false, "admin@gmail.com" },
                    { "7f29f004-5e8c-4090-a755-c7ae1466474a", 0, "19746d74-7592-4fb7-8ede-b0f62458d8d6", "IdentityUser", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEGE+igPJdu3tTzD8Mdp0vdttigJasxsRAiIDZejrotCK1qE8VSwA8yr1X2kvd5EZ3g==", null, false, "", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { "2c710fa9-135e-4487-a1aa-12684fe2d7fd", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521222472_TRD00133_HUC_Bom_Senso_V2.png", "10000000000000000000000000" },
                    { "3bc62d22-8038-4169-bbe1-5f076639d911", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521212425_sighjyhliefukn8dygvd.png", "20000000000000000000000000" },
                    { "5e47dd8b-6345-4cea-99d4-58f3f0cc5f46", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521229043_WONdriftlessupdated_eda49ff4-e067-4393-9515-ef748e528bb6.png", "10000000000000000000000000" },
                    { "63543f1f-c597-417e-890c-87c3d3a2cf88", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521226038_w73vhyjhu1y3odxqvnjt.png", "30000000000000000000000000" },
                    { "6731fdf2-b8d4-48c5-a5b4-236f85aec475", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521209682_FamiliaPeixotoUpdated.png", "20000000000000000000000000" },
                    { "d095511a-dca9-496b-b1d6-fdb850ae1722", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521220065_TRD00132_SPA_High_Five_Blend_Main.png", "40000000000000000000000000" },
                    { "dd62a928-036d-4768-b5ae-3b4981f4c549", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521212425_sighjyhliefukn8dygvd.png", "30000000000000000000000000" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "10000000000000000000000000",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 10, 29, 43, 540, DateTimeKind.Unspecified).AddTicks(885), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 10, 29, 43, 540, DateTimeKind.Unspecified).AddTicks(890), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "20000000000000000000000000",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 10, 29, 43, 540, DateTimeKind.Unspecified).AddTicks(894), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 10, 29, 43, 540, DateTimeKind.Unspecified).AddTicks(895), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "30000000000000000000000000",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 10, 29, 43, 540, DateTimeKind.Unspecified).AddTicks(897), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 10, 29, 43, 540, DateTimeKind.Unspecified).AddTicks(897), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "40000000000000000000000000",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 10, 29, 43, 540, DateTimeKind.Unspecified).AddTicks(899), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 10, 29, 43, 540, DateTimeKind.Unspecified).AddTicks(899), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "77d61071-d580-4c8b-a37f-08dfbe0b4f8d", "28531d53-fea2-45c9-a75c-67190248884a" },
                    { "6ef386c5-d1fd-4a48-b244-4c8b46036ca4", "7f29f004-5e8c-4090-a755-c7ae1466474a" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRatings_AspNetUsers_UserId",
                table: "ProductRatings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRatings_Products_ProductId",
                table: "ProductRatings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRatings_AspNetUsers_UserId",
                table: "ProductRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRatings_Products_ProductId",
                table: "ProductRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRatings",
                table: "ProductRatings");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "77d61071-d580-4c8b-a37f-08dfbe0b4f8d", "28531d53-fea2-45c9-a75c-67190248884a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ef386c5-d1fd-4a48-b244-4c8b46036ca4", "7f29f004-5e8c-4090-a755-c7ae1466474a" });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "2c710fa9-135e-4487-a1aa-12684fe2d7fd");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "3bc62d22-8038-4169-bbe1-5f076639d911");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "5e47dd8b-6345-4cea-99d4-58f3f0cc5f46");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "63543f1f-c597-417e-890c-87c3d3a2cf88");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "6731fdf2-b8d4-48c5-a5b4-236f85aec475");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "d095511a-dca9-496b-b1d6-fdb850ae1722");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "dd62a928-036d-4768-b5ae-3b4981f4c549");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ef386c5-d1fd-4a48-b244-4c8b46036ca4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77d61071-d580-4c8b-a37f-08dfbe0b4f8d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28531d53-fea2-45c9-a75c-67190248884a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f29f004-5e8c-4090-a755-c7ae1466474a");

            migrationBuilder.RenameTable(
                name: "ProductRatings",
                newName: "ProductRating");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRatings_UserId_ProductId",
                table: "ProductRating",
                newName: "IX_ProductRating_UserId_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRatings_ProductId",
                table: "ProductRating",
                newName: "IX_ProductRating_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRating",
                table: "ProductRating",
                column: "ProductRatingId");

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "10000000000000000000000000",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8021), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8027), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "20000000000000000000000000",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8031), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8031), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "30000000000000000000000000",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8033), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8034), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "40000000000000000000000000",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8035), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 9, 7, 0, 850, DateTimeKind.Unspecified).AddTicks(8036), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a60b77d6-3232-46a2-a6eb-972365fa4948", "232da8e9-a269-4ef4-8d20-cdeaee3e83a1" },
                    { "b1b93ae0-9154-4e17-af76-abc16d8e9d82", "5849aed2-c281-4e75-9449-297f75ca8c3d" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRating_AspNetUsers_UserId",
                table: "ProductRating",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRating_Products_ProductId",
                table: "ProductRating",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
