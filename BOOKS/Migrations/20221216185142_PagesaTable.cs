using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOOKS.Migrations
{
    public partial class PagesaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagesa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shuma = table.Column<int>(type: "int", nullable: false),
                    Klienti_id = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DataEPageses = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataESkadimit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagesa", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagesa");
        }
    }
}
