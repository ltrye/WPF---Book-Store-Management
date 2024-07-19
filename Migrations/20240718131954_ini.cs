using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Management.Migrations
{
    /// <inheritdoc />
    public partial class ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Stock" },
                values: new object[] { new DateTime(2024, 7, 18, 20, 19, 54, 654, DateTimeKind.Local).AddTicks(9635), 50 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Stock" },
                values: new object[] { new DateTime(2024, 7, 18, 20, 19, 54, 654, DateTimeKind.Local).AddTicks(9637), 50 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 19, 54, 654, DateTimeKind.Local).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 19, 54, 654, DateTimeKind.Local).AddTicks(9573));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 19, 54, 654, DateTimeKind.Local).AddTicks(9574));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 19, 54, 654, DateTimeKind.Local).AddTicks(9575));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 19, 54, 654, DateTimeKind.Local).AddTicks(9576));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 19, 54, 654, DateTimeKind.Local).AddTicks(9577));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Stock" },
                values: new object[] { new DateTime(2024, 7, 18, 20, 7, 44, 976, DateTimeKind.Local).AddTicks(2588), 0 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Stock" },
                values: new object[] { new DateTime(2024, 7, 18, 20, 7, 44, 976, DateTimeKind.Local).AddTicks(2592), 0 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 7, 44, 976, DateTimeKind.Local).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 7, 44, 976, DateTimeKind.Local).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 7, 44, 976, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 7, 44, 976, DateTimeKind.Local).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 7, 44, 976, DateTimeKind.Local).AddTicks(2528));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 7, 44, 976, DateTimeKind.Local).AddTicks(2529));
        }
    }
}
