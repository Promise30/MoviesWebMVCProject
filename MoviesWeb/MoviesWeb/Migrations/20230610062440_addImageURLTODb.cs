using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWeb.Migrations
{
    /// <inheritdoc />
    public partial class addImageURLTODb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "MovieTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "MovieTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 6, 10, 7, 24, 40, 484, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 6, 10, 7, 24, 40, 484, DateTimeKind.Local).AddTicks(1902));

            migrationBuilder.UpdateData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 6, 10, 7, 24, 40, 484, DateTimeKind.Local).AddTicks(1904));

            migrationBuilder.UpdateData(
                table: "MovieTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GenreId", "ImageURL" },
                values: new object[] { 1, "" });

            migrationBuilder.UpdateData(
                table: "MovieTable",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GenreId", "ImageURL" },
                values: new object[] { 3, "" });

            migrationBuilder.UpdateData(
                table: "MovieTable",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GenreId", "ImageURL" },
                values: new object[] { 2, "" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieTable_GenreId",
                table: "MovieTable",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTable_GenreTable_GenreId",
                table: "MovieTable",
                column: "GenreId",
                principalTable: "GenreTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTable_GenreTable_GenreId",
                table: "MovieTable");

            migrationBuilder.DropIndex(
                name: "IX_MovieTable_GenreId",
                table: "MovieTable");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "MovieTable");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "MovieTable");

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
        }
    }
}
