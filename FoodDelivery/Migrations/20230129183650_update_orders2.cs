using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDelivery.Migrations
{
    public partial class update_orders2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemsIds",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
