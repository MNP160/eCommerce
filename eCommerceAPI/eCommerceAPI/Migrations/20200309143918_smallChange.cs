using Microsoft.EntityFrameworkCore.Migrations;

namespace farmersAPi.Migrations
{
    public partial class smallChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Cathegories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Cathegories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
