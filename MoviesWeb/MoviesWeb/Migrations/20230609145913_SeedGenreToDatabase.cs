using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenreToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "GenreTable",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "GenreTable",
                columns: new[] { "Id", "CreationDate", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 9, 15, 59, 13, 762, DateTimeKind.Local).AddTicks(3617), "A popular movie genre characterised by thrilling, high-energy and adrenaline-pumping content.", "Action" },
                    { 2, new DateTime(2023, 6, 9, 15, 59, 13, 762, DateTimeKind.Local).AddTicks(3673), "A genre of film that aims to entertain and amuse the audience through humor and light-hearted storytelling.", "Comedy" },
                    { 3, new DateTime(2023, 6, 9, 15, 59, 13, 762, DateTimeKind.Local).AddTicks(3675), "A genre of film that explores imaginative and speculative concepts often based on scientific and technological advancements.", "Sci-Fi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "GenreTable",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
