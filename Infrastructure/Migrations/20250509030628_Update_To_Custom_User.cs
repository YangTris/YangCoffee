using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_To_Custom_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58672820-cb9c-40f0-819a-e362ad34b90a", null, "Admin", "ADMIN" },
                    { "de7e9214-7b1b-4250-be4a-6a0ae6e946cb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d397a542-0263-4e0c-9c96-e8bf652daca4", 0, "6249fb67-ff20-44c4-9c92-57a578bdb9ad", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEEremnOwYP+JNC+5PFqHkb9c8gVjv/TZG/HRimJTxOEJbV+RV2QSY8YldgZ+Gk4PYQ==", null, false, "9632bae7-ca32-4da2-9114-1433bc362d12", false, "admin@gmail.com" },
                    { "fae46a23-3340-44a1-b6f8-d27c3bf13b61", 0, "dfc96e88-a8d6-47e4-90fa-e995ce328551", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEPRWJr/eE75ihE5uXTbbhLoX5ajHOA+Wrdaoy2AeJtm2HISBqQnByahXKIrFCmrNbw==", null, false, "ced7d549-7f1d-49b1-b042-2b66479d6b67", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { "06953b57-903d-4046-8d4f-f377e82979b3", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521229043_WONdriftlessupdated_eda49ff4-e067-4393-9515-ef748e528bb6.png", "10000000000000000000000000" },
                    { "09f2ac74-d424-4206-99e4-8267b81b8796", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521226038_w73vhyjhu1y3odxqvnjt.png", "30000000000000000000000000" },
                    { "3246cd67-6d06-4108-ad37-076950124200", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521209682_FamiliaPeixotoUpdated.png", "20000000000000000000000000" },
                    { "47275a99-3a3c-4228-9ba4-85da1ae0a309", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521212425_sighjyhliefukn8dygvd.png", "20000000000000000000000000" },
                    { "60b82773-4ce6-4664-a74b-de5c64fba87c", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521220065_TRD00132_SPA_High_Five_Blend_Main.png", "40000000000000000000000000" },
                    { "90b55d88-c769-4fa4-95ab-afac212cbf1d", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521222472_TRD00133_HUC_Bom_Senso_V2.png", "10000000000000000000000000" },
                    { "dd7b6206-e039-4f68-8323-d8cedab11da5", "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521212425_sighjyhliefukn8dygvd.png", "30000000000000000000000000" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "10000000000000000000000000",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 9, 3, 6, 25, 497, DateTimeKind.Unspecified).AddTicks(4466), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 9, 3, 6, 25, 497, DateTimeKind.Unspecified).AddTicks(4473), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "20000000000000000000000000",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 9, 3, 6, 25, 497, DateTimeKind.Unspecified).AddTicks(4477), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 9, 3, 6, 25, 497, DateTimeKind.Unspecified).AddTicks(4478), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "30000000000000000000000000",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 9, 3, 6, 25, 497, DateTimeKind.Unspecified).AddTicks(4480), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 9, 3, 6, 25, 497, DateTimeKind.Unspecified).AddTicks(4481), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "40000000000000000000000000",
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 9, 3, 6, 25, 497, DateTimeKind.Unspecified).AddTicks(4483), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 9, 3, 6, 25, 497, DateTimeKind.Unspecified).AddTicks(4483), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "58672820-cb9c-40f0-819a-e362ad34b90a", "d397a542-0263-4e0c-9c96-e8bf652daca4" },
                    { "de7e9214-7b1b-4250-be4a-6a0ae6e946cb", "fae46a23-3340-44a1-b6f8-d27c3bf13b61" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "58672820-cb9c-40f0-819a-e362ad34b90a", "d397a542-0263-4e0c-9c96-e8bf652daca4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "de7e9214-7b1b-4250-be4a-6a0ae6e946cb", "fae46a23-3340-44a1-b6f8-d27c3bf13b61" });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "06953b57-903d-4046-8d4f-f377e82979b3");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "09f2ac74-d424-4206-99e4-8267b81b8796");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "3246cd67-6d06-4108-ad37-076950124200");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "47275a99-3a3c-4228-9ba4-85da1ae0a309");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "60b82773-4ce6-4664-a74b-de5c64fba87c");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "90b55d88-c769-4fa4-95ab-afac212cbf1d");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: "dd7b6206-e039-4f68-8323-d8cedab11da5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58672820-cb9c-40f0-819a-e362ad34b90a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de7e9214-7b1b-4250-be4a-6a0ae6e946cb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d397a542-0263-4e0c-9c96-e8bf652daca4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fae46a23-3340-44a1-b6f8-d27c3bf13b61");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

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
        }
    }
}
