using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceAPI.Migrations
{
    public partial class thumbnails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "OrderDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
