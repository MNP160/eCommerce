using Microsoft.EntityFrameworkCore.Migrations;

namespace farmersAPi.Migrations
{
    public partial class fixingRelationshipToxinsProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Toxins",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Toxins_ProductId",
                table: "Toxins",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toxins_Products_ProductId",
                table: "Toxins",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toxins_Products_ProductId",
                table: "Toxins");

            migrationBuilder.DropIndex(
                name: "IX_Toxins_ProductId",
                table: "Toxins");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Toxins");
        }
    }
}
