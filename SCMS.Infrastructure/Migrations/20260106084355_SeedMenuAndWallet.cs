using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMenuAndWallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "ItemId", "CategoryId", "Description", "ImageUrl", "InventoryQuantity", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Cơm tấm sườn nướng than", "https://example.com/comsuon.jpg", 100, true, "Cơm sườn bì chả", 35000m },
                    { 2, 2, "Đường đen, ít đá", "https://example.com/trasua.jpg", 50, true, "Trà sữa trân châu", 25000m }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 43, 52, 731, DateTimeKind.Utc).AddTicks(4142), "$2a$11$GCjcwloeBKTpbGS20N9Fdeo8PtHRT8.oUErEBRj2SVwWAkK6Ag0R." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 43, 52, 937, DateTimeKind.Utc).AddTicks(9859), "$2a$11$0SNodnuFKpAv2cJyye4kgOGAg7qxlWkqcToNPeMS5cUGBZEPDC.s2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 43, 53, 166, DateTimeKind.Utc).AddTicks(9577), "$2a$11$DeWWFU2/8wxHQBhHuBxX9.6IaSESQARaiFbpIlYWP/tMcLnuafg0K" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 43, 53, 388, DateTimeKind.Utc).AddTicks(2077), "$2a$11$LY/GtJreAxOx7utvHu168eqgL6SOvGVDzmXKGtQx9I5kpVijPLLIO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 43, 53, 627, DateTimeKind.Utc).AddTicks(8346), "$2a$11$doWrYgFpOrDa1DL2F/9mfOXzgwRrFr//7OZyE6kllTdnXIdmFS3/a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 43, 53, 838, DateTimeKind.Utc).AddTicks(2694), "$2a$11$4gZh8qBO3sy/4YY0GjaPzeKw5dBmlAu3ymjp6MKD2dWj4laRBFMve" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 43, 54, 58, DateTimeKind.Utc).AddTicks(8018), "$2a$11$QFmwZkTpjRYfvCt35ycScu0tE7t4YBJsgynUsbGsk28FBYOd1X95m" });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "WalletId", "Balance", "UserId" },
                values: new object[] { 1, 500000m, 6 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "WalletId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 10, 18, 861, DateTimeKind.Utc).AddTicks(8650), "$2a$11$g6w8/pwmm1xLK8iVkrJfheeF3pSjf3UsBS13/rOZBWhio49H.2EKu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 10, 19, 73, DateTimeKind.Utc).AddTicks(8386), "$2a$11$hvV8nucZ0.fXHNXgfvdqXOQ4JnLznYTHcmCOFvF.4OXB3F.l7jm2O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 10, 19, 328, DateTimeKind.Utc).AddTicks(6137), "$2a$11$62C.SyP8oERSOOL28ht3SudTvOQU7iuq55DuN2iga49o3Z8Hnl/EW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 10, 19, 547, DateTimeKind.Utc).AddTicks(7059), "$2a$11$ukGFX4qWWZpWYnI.rXaFJOFJMzrA4AF4rTjqTkEIsfPt0rOsMaG72" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 10, 19, 774, DateTimeKind.Utc).AddTicks(8823), "$2a$11$obLc/BVJnSpg8O/t2uyBIel5z4FribhnP.RVjJHXAIOrbdvA2zuN2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 10, 20, 14, DateTimeKind.Utc).AddTicks(8521), "$2a$11$czcX.FzX2bjX2SUUl1TY2epWNURa/4L8/djcUPe5eo.UT9YQbQ4cu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 6, 8, 10, 20, 216, DateTimeKind.Utc).AddTicks(7190), "$2a$11$SdGIGbP2L6MipPaO8j55c.kARqBdpflWSy1XHfWpq8WlXz4nYDKMu" });
        }
    }
}
