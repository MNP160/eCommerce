using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceAPI.Migrations
{
    public partial class ordersModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCashPayment",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsOrderComplete",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Stage",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stage",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsCashPayment",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOrderComplete",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
