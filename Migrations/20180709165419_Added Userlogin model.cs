using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApp1.API.Migrations
{
    public partial class AddedUserloginmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Close",
                table: "Values",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Userlogins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    PwdHash = table.Column<byte[]>(nullable: true),
                    PwdSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userlogins", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Userlogins");

            migrationBuilder.DropColumn(
                name: "Close",
                table: "Values");
        }
    }
}
