using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookWarms.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "PageCount", "Title" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "A novel set in the Roaring Twenties.", "Classic", 180, "The Great Gatsby" },
                    { 2, "George Orwell", "A story about a totalitarian regime.", "Dystopian", 328, "1984" }
                });

            migrationBuilder.InsertData(
                table: "ReadingStats",
                columns: new[] { "Id", "BooksRead", "PagesRead", "UserId", "Year" },
                values: new object[] { 1, 2, 508, 1, 2025 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Username" },
                values: new object[] { 1, "krisistoyanova2008@gmail.com", "1234", "Kristiana" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Date", "Rating", "ReviewText", "UserId" },
                values: new object[] { 1, 1, new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "A timeless classic!", 1 });

            migrationBuilder.InsertData(
                table: "Shelves",
                columns: new[] { "Id", "BookId", "ShelfType", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 0, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReadingStats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
