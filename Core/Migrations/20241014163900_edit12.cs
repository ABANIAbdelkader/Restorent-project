using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class edit12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meals_chefs_Chef_id",
                table: "meals");

            migrationBuilder.DropIndex(
                name: "IX_meals_Chef_id",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "Chef_id",
                table: "meals");

            migrationBuilder.CreateTable(
                name: "chef_meal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chef_id = table.Column<int>(type: "int", nullable: false),
                    meal_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chef_meal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chef_meal_chefs_chef_id",
                        column: x => x.chef_id,
                        principalTable: "chefs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_chef_meal_meals_meal_id",
                        column: x => x.meal_id,
                        principalTable: "meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chef_meal_chef_id",
                table: "chef_meal",
                column: "chef_id");

            migrationBuilder.CreateIndex(
                name: "IX_chef_meal_meal_id",
                table: "chef_meal",
                column: "meal_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chef_meal");

            migrationBuilder.AddColumn<int>(
                name: "Chef_id",
                table: "meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_meals_Chef_id",
                table: "meals",
                column: "Chef_id");

            migrationBuilder.AddForeignKey(
                name: "FK_meals_chefs_Chef_id",
                table: "meals",
                column: "Chef_id",
                principalTable: "chefs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
