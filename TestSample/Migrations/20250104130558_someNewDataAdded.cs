using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestSample.Migrations
{
    /// <inheritdoc />
    public partial class someNewDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2025, 1, 4, 16, 35, 58, 372, DateTimeKind.Local).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2025, 1, 4, 16, 35, 58, 372, DateTimeKind.Local).AddTicks(2089));

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Content", "CreatedTime", "Title" },
                values: new object[,]
                {
                    { 3, "This post explores how earth was shaped.", new DateTime(2025, 1, 4, 16, 35, 58, 372, DateTimeKind.Local).AddTicks(2090), "How earth got shaped" },
                    { 4, "This post explores the points of living.", new DateTime(2025, 1, 4, 16, 35, 58, 372, DateTimeKind.Local).AddTicks(2091), "The Point of living" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4);

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
    }
}
