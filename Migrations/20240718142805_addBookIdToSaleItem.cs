using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Management.Migrations
{
    /// <inheritdoc />
    public partial class addBookIdToSaleItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "SaleItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 21, 28, 5, 315, DateTimeKind.Local).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 21, 28, 5, 315, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 21, 28, 5, 315, DateTimeKind.Local).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 21, 28, 5, 315, DateTimeKind.Local).AddTicks(3506));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 21, 28, 5, 315, DateTimeKind.Local).AddTicks(3508));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 21, 28, 5, 315, DateTimeKind.Local).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 21, 28, 5, 315, DateTimeKind.Local).AddTicks(3510));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 21, 28, 5, 315, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.CreateIndex(
                name: "IX_SaleItem_BookId",
                table: "SaleItem",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItem_Books_BookId",
                table: "SaleItem",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItem_Books_BookId",
                table: "SaleItem");

            migrationBuilder.DropIndex(
                name: "IX_SaleItem_BookId",
                table: "SaleItem");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "SaleItem");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 19, 54, 654, DateTimeKind.Local).AddTicks(9635));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 18, 20, 19, 54, 654, DateTimeKind.Local).AddTicks(9637));

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
    }
}
