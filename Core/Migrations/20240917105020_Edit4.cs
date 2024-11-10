using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class Edit4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_meals_Meal_Id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_Meal_Id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Meal_Id",
                table: "orders");

            migrationBuilder.CreateTable(
                name: "Order_Meal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Meal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Meal_meals_MealId",
                        column: x => x.MealId,
                        principalTable: "meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Meal_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Meal_MealId",
                table: "Order_Meal",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Meal_OrderId",
                table: "Order_Meal",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Meal");

            migrationBuilder.AddColumn<int>(
                name: "Meal_Id",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orders_Meal_Id",
                table: "orders",
                column: "Meal_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_meals_Meal_Id",
                table: "orders",
                column: "Meal_Id",
                principalTable: "meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
