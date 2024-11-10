using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class Edit3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_clients_Client_Id",
                table: "orders");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropIndex(
                name: "IX_orders_Client_Id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Client_Id",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "CardNumber",
                table: "managers",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "managers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CardNumber",
                table: "chefs",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "chefs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "chefs");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "chefs");

            migrationBuilder.AddColumn<int>(
                name: "Client_Id",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_Client_Id",
                table: "orders",
                column: "Client_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_clients_Client_Id",
                table: "orders",
                column: "Client_Id",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
