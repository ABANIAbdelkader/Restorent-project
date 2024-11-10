using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class Edit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "m_catigory_id",
                table: "meals",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "meal_catigories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meal_catigories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_meals_m_catigory_id",
                table: "meals",
                column: "m_catigory_id");

            migrationBuilder.AddForeignKey(
                name: "FK_meals_meal_catigories_m_catigory_id",
                table: "meals",
                column: "m_catigory_id",
                principalTable: "meal_catigories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meals_meal_catigories_m_catigory_id",
                table: "meals");

            migrationBuilder.DropTable(
                name: "meal_catigories");

            migrationBuilder.DropIndex(
                name: "IX_meals_m_catigory_id",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "m_catigory_id",
                table: "meals");
        }
    }
}
