using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class Edit15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chefs_meals_chefs_chef_id",
                table: "Chefs_meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Chefs_meals_meals_meal_id",
                table: "Chefs_meals");

            migrationBuilder.DropForeignKey(
                name: "FK_meals_meal_catigories_m_catigory_id",
                table: "meals");

            migrationBuilder.DropForeignKey(
                name: "FK_order_Meals_meals_MealId",
                table: "order_Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_order_Meals_orders_OrderId",
                table: "order_Meals");

            migrationBuilder.DeleteData(
                table: "admin",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Chefs_meals_chefs_chef_id",
                table: "Chefs_meals",
                column: "chef_id",
                principalTable: "chefs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chefs_meals_meals_meal_id",
                table: "Chefs_meals",
                column: "meal_id",
                principalTable: "meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_meals_meal_catigories_m_catigory_id",
                table: "meals",
                column: "m_catigory_id",
                principalTable: "meal_catigories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_Meals_meals_MealId",
                table: "order_Meals",
                column: "MealId",
                principalTable: "meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_Meals_orders_OrderId",
                table: "order_Meals",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropForeignKey(
                name: "FK_meals_meal_catigories_m_catigory_id",
                table: "meals");

            migrationBuilder.DropForeignKey(
                name: "FK_order_Meals_meals_MealId",
                table: "order_Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_order_Meals_orders_OrderId",
                table: "order_Meals");

            migrationBuilder.InsertData(
                table: "admin",
                columns: new[] { "id", "Card_Number", "Card_Password", "name" },
                values: new object[] { 1, 123, "hello", "jon" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_meals_meal_catigories_m_catigory_id",
                table: "meals",
                column: "m_catigory_id",
                principalTable: "meal_catigories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_order_Meals_meals_MealId",
                table: "order_Meals",
                column: "MealId",
                principalTable: "meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_order_Meals_orders_OrderId",
                table: "order_Meals",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
