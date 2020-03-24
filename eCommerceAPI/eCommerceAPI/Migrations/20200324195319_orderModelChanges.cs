using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceAPI.Migrations
{
    public partial class orderModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isCashPayment",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isOrderComplete",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCashPayment",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "isOrderComplete",
                table: "Orders");
        }
    }
}
