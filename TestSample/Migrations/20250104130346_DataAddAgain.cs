using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestSample.Migrations
{
    /// <inheritdoc />
    public partial class DataAddAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2025, 1, 4, 16, 33, 46, 453, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2025, 1, 4, 16, 33, 46, 453, DateTimeKind.Local).AddTicks(4786));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2025, 1, 4, 16, 30, 23, 898, DateTimeKind.Local).AddTicks(4327));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2025, 1, 4, 16, 30, 23, 898, DateTimeKind.Local).AddTicks(4345));
        }
    }
}
