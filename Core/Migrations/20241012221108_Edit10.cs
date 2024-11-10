using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class Edit10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "image",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "image",
                table: "chefs");

            migrationBuilder.AddColumn<string>(
                name: "imagePath",
                table: "meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "imagePath",
                table: "managers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "imagePath",
                table: "chefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagePath",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "imagePath",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "imagePath",
                table: "chefs");

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "meals",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "managers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "chefs",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
