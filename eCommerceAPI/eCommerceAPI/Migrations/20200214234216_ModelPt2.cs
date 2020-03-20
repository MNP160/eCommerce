using Microsoft.EntityFrameworkCore.Migrations;

namespace farmersAPi.Migrations
{
    public partial class ModelPt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Toxins",
                columns: table => new
                {
                    ToxinId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toxins", x => x.ToxinId);
                });

            migrationBuilder.CreateTable(
                name: "USerToxins",
                columns: table => new
                {
                    UserToxinId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USerToxins", x => x.UserToxinId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toxins");

            migrationBuilder.DropTable(
                name: "USerToxins");
        }
    }
}
