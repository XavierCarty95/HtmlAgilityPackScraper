using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilityFramework.Migrations.StockData
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StockRecord = table.Column<DateTime>(nullable: false),
                    Symbol = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    Change = table.Column<string>(nullable: true),
                    PercentChange = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
