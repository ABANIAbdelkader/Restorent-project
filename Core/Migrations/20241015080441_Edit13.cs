using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class Edit13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chef_meal_chefs_chef_id",
                table: "chef_meal");

            migrationBuilder.DropForeignKey(
                name: "FK_chef_meal_meals_meal_id",
                table: "chef_meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_chef_meal",
                table: "chef_meal");

            migrationBuilder.RenameTable(
                name: "chef_meal",
                newName: "Chefs_meals");

            migrationBuilder.RenameIndex(
                name: "IX_chef_meal_meal_id",
                table: "Chefs_meals",
                newName: "IX_Chefs_meals_meal_id");

            migrationBuilder.RenameIndex(
                name: "IX_chef_meal_chef_id",
                table: "Chefs_meals",
                newName: "IX_Chefs_meals_chef_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chefs_meals",
                table: "Chefs_meals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chefs_meals_chefs_chef_id",
                table: "Chefs_meals",
                column: "chef_id",
                principalTable: "chefs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chefs_meals_meals_meal_id",
                table: "Chefs_meals",
                column: "meal_id",
                principalTable: "meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chefs_meals_chefs_chef_id",
                table: "Chefs_meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Chefs_meals_meals_meal_id",
                table: "Chefs_meals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chefs_meals",
                table: "Chefs_meals");

            migrationBuilder.RenameTable(
                name: "Chefs_meals",
                newName: "chef_meal");

            migrationBuilder.RenameIndex(
                name: "IX_Chefs_meals_meal_id",
                table: "chef_meal",
                newName: "IX_chef_meal_meal_id");

            migrationBuilder.RenameIndex(
                name: "IX_Chefs_meals_chef_id",
                table: "chef_meal",
                newName: "IX_chef_meal_chef_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_chef_meal",
                table: "chef_meal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_chef_meal_chefs_chef_id",
                table: "chef_meal",
                column: "chef_id",
                principalTable: "chefs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chef_meal_meals_meal_id",
                table: "chef_meal",
                column: "meal_id",
                principalTable: "meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
