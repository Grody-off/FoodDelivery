using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDelivery.Migrations
{
    public partial class add_foreign_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AddressForeignKey",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AddressForeignKey",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserForeignKey",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProductForeignKey",
                table: "OrderItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressForeignKey",
                table: "Users",
                column: "AddressForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressForeignKey",
                table: "Orders",
                column: "AddressForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserForeignKey",
                table: "Orders",
                column: "UserForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductForeignKey",
                table: "OrderItems",
                column: "ProductForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductForeignKey",
                table: "OrderItems",
                column: "ProductForeignKey",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressForeignKey",
                table: "Orders",
                column: "AddressForeignKey",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserForeignKey",
                table: "Orders",
                column: "UserForeignKey",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_AddressForeignKey",
                table: "Users",
                column: "AddressForeignKey",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductForeignKey",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressForeignKey",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserForeignKey",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_AddressForeignKey",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressForeignKey",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AddressForeignKey",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserForeignKey",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductForeignKey",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "AddressForeignKey",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressForeignKey",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserForeignKey",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductForeignKey",
                table: "OrderItems");
        }
    }
}
