using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBProject3.Migrations
{
    /// <inheritdoc />
    public partial class GenderAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderId);
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "GenderId", "Name" },
                values: new object[,]
                {
                    { 0, "Male" },
                    { 1, "Female" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_GenderId",
                table: "users",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Gender_GenderId",
                table: "users",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Gender_GenderId",
                table: "users");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_users_GenderId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "users");
        }
    }
}
