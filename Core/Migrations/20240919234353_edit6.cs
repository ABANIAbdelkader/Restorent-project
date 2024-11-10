using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class edit6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Meal_meals_MealId",
                table: "Order_Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Meal_orders_OrderId",
                table: "Order_Meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Meal",
                table: "Order_Meal");

            migrationBuilder.RenameTable(
                name: "Order_Meal",
                newName: "order_Meals");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Meal_OrderId",
                table: "order_Meals",
                newName: "IX_order_Meals_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Meal_MealId",
                table: "order_Meals",
                newName: "IX_order_Meals_MealId");

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "meals",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "Card_number",
                table: "managers",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Card_password",
                table: "managers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "managers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "Card_number",
                table: "chefs",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Card_password",
                table: "chefs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "chefs",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_Meals",
                table: "order_Meals",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_Meals_meals_MealId",
                table: "order_Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_order_Meals_orders_OrderId",
                table: "order_Meals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_Meals",
                table: "order_Meals");

            migrationBuilder.DropColumn(
                name: "image",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "Card_number",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "Card_password",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "image",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "Card_number",
                table: "chefs");

            migrationBuilder.DropColumn(
                name: "Card_password",
                table: "chefs");

            migrationBuilder.DropColumn(
                name: "image",
                table: "chefs");

            migrationBuilder.RenameTable(
                name: "order_Meals",
                newName: "Order_Meal");

            migrationBuilder.RenameIndex(
                name: "IX_order_Meals_OrderId",
                table: "Order_Meal",
                newName: "IX_Order_Meal_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_order_Meals_MealId",
                table: "Order_Meal",
                newName: "IX_Order_Meal_MealId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Meal",
                table: "Order_Meal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Meal_meals_MealId",
                table: "Order_Meal",
                column: "MealId",
                principalTable: "meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Meal_orders_OrderId",
                table: "Order_Meal",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
