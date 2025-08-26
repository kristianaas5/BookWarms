using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookWarms.Migrations
{
    /// <inheritdoc />
    public partial class AddLibraryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelves_Books_BookId",
                table: "Shelves");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelves_Users_UserId",
                table: "Shelves");

            migrationBuilder.DropIndex(
                name: "IX_Shelves_BookId",
                table: "Shelves");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Shelves",
                newName: "LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Shelves_UserId",
                table: "Shelves",
                newName: "IX_Shelves_LibraryId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reviews",
                newName: "LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                newName: "IX_Reviews_LibraryId");

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libraries_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libraries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "BookId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 },
                    { 5, 5, 3 },
                    { 6, 6, 3 },
                    { 7, 7, 4 },
                    { 8, 8, 4 },
                    { 9, 9, 5 },
                    { 10, 10, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "LibraryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2,
                column: "LibraryId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_BookId",
                table: "Libraries",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_UserId",
                table: "Libraries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Libraries_LibraryId",
                table: "Reviews",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelves_Libraries_LibraryId",
                table: "Shelves",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Libraries_LibraryId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelves_Libraries_LibraryId",
                table: "Shelves");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.RenameColumn(
                name: "LibraryId",
                table: "Shelves",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Shelves_LibraryId",
                table: "Shelves",
                newName: "IX_Shelves_UserId");

            migrationBuilder.RenameColumn(
                name: "LibraryId",
                table: "Reviews",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_LibraryId",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Shelves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "UserId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "BookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "UserId" },
                values: new object[] { 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_BookId",
                table: "Shelves",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelves_Books_BookId",
                table: "Shelves",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelves_Users_UserId",
                table: "Shelves",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
