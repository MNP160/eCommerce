using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace farmersAPi.Migrations
{
    public partial class updatedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cathegories_CathegoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USerToxins",
                table: "USerToxins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toxins",
                table: "Toxins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cathegories",
                table: "Cathegories");

            migrationBuilder.DropColumn(
                name: "UserToxinId",
                table: "USerToxins");

            migrationBuilder.DropColumn(
                name: "ToxinId",
                table: "Toxins");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CathegoryId",
                table: "Cathegories");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "USerToxins",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "USerToxins",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Toxins",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Toxins",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Products",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cathegories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cathegories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_USerToxins",
                table: "USerToxins",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toxins",
                table: "Toxins",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cathegories",
                table: "Cathegories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cathegories_CathegoryId",
                table: "Products",
                column: "CathegoryId",
                principalTable: "Cathegories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cathegories_CathegoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USerToxins",
                table: "USerToxins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toxins",
                table: "Toxins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cathegories",
                table: "Cathegories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "USerToxins");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "USerToxins");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Toxins");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Toxins");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cathegories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cathegories");

            migrationBuilder.AddColumn<int>(
                name: "UserToxinId",
                table: "USerToxins",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ToxinId",
                table: "Toxins",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CathegoryId",
                table: "Cathegories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USerToxins",
                table: "USerToxins",
                column: "UserToxinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toxins",
                table: "Toxins",
                column: "ToxinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cathegories",
                table: "Cathegories",
                column: "CathegoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cathegories_CathegoryId",
                table: "Products",
                column: "CathegoryId",
                principalTable: "Cathegories",
                principalColumn: "CathegoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
