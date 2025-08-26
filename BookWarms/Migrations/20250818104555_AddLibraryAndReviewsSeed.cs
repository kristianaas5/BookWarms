using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookWarms.Migrations
{
    /// <inheritdoc />
    public partial class AddLibraryAndReviewsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shelves");

            migrationBuilder.AddColumn<int>(
                name: "ShelfType",
                table: "Libraries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShelfType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShelfType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShelfType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ShelfType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ShelfType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 6,
                column: "ShelfType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 7,
                column: "ShelfType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 8,
                column: "ShelfType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 9,
                column: "ShelfType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 10,
                column: "ShelfType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "LibraryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "LibraryId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_ReadingStats_UserId",
                table: "ReadingStats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingStats_Libraries_UserId",
                table: "ReadingStats",
                column: "UserId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadingStats_Libraries_UserId",
                table: "ReadingStats");

            migrationBuilder.DropIndex(
                name: "IX_ReadingStats_UserId",
                table: "ReadingStats");

            migrationBuilder.DropColumn(
                name: "ShelfType",
                table: "Libraries");

            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryId = table.Column<int>(type: "int", nullable: false),
                    ShelfType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shelves_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "LibraryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "LibraryId",
                value: 3);

            migrationBuilder.InsertData(
                table: "Shelves",
                columns: new[] { "Id", "LibraryId", "ShelfType" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_LibraryId",
                table: "Shelves",
                column: "LibraryId");
        }
    }
}
