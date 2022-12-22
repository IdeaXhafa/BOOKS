using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOOKS.Migrations
{
    public partial class HuazimiDheRezervimi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Huazimi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPritjes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataKthimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Klienti_id = table.Column<int>(type: "int", nullable: false),
                    Libra_id = table.Column<int>(type: "int", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huazimi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rezervimi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Klienti_id = table.Column<int>(type: "int", nullable: false),
                    Libra_id = table.Column<int>(type: "int", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervimi", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Huazimi");

            migrationBuilder.DropTable(
                name: "Rezervimi");
        }
    }
}
