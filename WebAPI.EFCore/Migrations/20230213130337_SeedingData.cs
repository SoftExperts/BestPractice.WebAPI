using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CategoryOrder", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2023, 2, 13, 18, 3, 37, 681, DateTimeKind.Local).AddTicks(8879), "HTC" },
                    { 2, 4, new DateTime(2023, 2, 13, 18, 3, 37, 681, DateTimeKind.Local).AddTicks(8894), "LG" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "categories");
        }
    }
}
