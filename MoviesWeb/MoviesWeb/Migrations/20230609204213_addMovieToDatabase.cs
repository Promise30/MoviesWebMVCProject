using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesWeb.Migrations
{
    /// <inheritdoc />
    public partial class addMovieToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTable", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 6, 9, 21, 42, 13, 738, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 6, 9, 21, 42, 13, 738, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 6, 9, 21, 42, 13, 738, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.InsertData(
                table: "MovieTable",
                columns: new[] { "Id", "Description", "Director", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "A movie which revolves around the life of Scott Howard, a high school student who discovers he is a werewolf and has to deal with the challenges of balancing his newfound abilities with his everyday teenage life.", "Rod Daniel", 8.0m, new DateTime(2011, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teen Wolf" },
                    { 2, "The series follows Barry Allen, a forensic scientist who gains superhuman speed after being struck by lightning and being exposed to chemicals in his lab.", "Greg Berlanti, Geoff Johns $ Andrew Kreisberg", 8.5m, new DateTime(2014, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Flash" },
                    { 3, "The series depicts the life, challenges and experiences of a young Chris Rock, growing up in the 1980s in a predominantly African-American neighbourhood of Brooklyn, New York.", "Chris Rock & Ali LeRoi", 9.0m, new DateTime(2009, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Everybody Hates Chris" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTable");

            migrationBuilder.UpdateData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 6, 9, 15, 59, 13, 762, DateTimeKind.Local).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 6, 9, 15, 59, 13, 762, DateTimeKind.Local).AddTicks(3673));

            migrationBuilder.UpdateData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 6, 9, 15, 59, 13, 762, DateTimeKind.Local).AddTicks(3675));
        }
    }
}
