using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class edit8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Card_Number",
                table: "managers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Card_Password",
                table: "managers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Card_Number",
                table: "chefs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Card_Password",
                table: "chefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Card_Number = table.Column<int>(type: "int", nullable: false),
                    Card_Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "admin",
                columns: new[] { "id", "Card_Number", "Card_Password", "name" },
                values: new object[] { 1, 123, "hello", "jon" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropColumn(
                name: "Card_Number",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "Card_Password",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "Card_Number",
                table: "chefs");

            migrationBuilder.DropColumn(
                name: "Card_Password",
                table: "chefs");
        }
    }
}
