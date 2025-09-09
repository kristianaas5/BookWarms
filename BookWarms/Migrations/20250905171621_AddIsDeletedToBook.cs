using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWarms.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Libraries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 51,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 52,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 53,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 54,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 55,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 56,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 57,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 58,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 59,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 60,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 61,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 62,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 63,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 64,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 65,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 66,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 67,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 68,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 69,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 70,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 71,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 72,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 73,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 74,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 75,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 76,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 77,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 78,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 79,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 80,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 81,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 82,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 83,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 84,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 85,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 86,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 87,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 88,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 89,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 90,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 91,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 92,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 93,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 94,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 95,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 96,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 97,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 98,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 99,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 100,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Libraries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Books");
        }
    }
}
