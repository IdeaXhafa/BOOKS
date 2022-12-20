using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOOKS.Migrations
{
    public partial class ChangeditAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Klientet",
                table: "Klientet");

            migrationBuilder.RenameTable(
                name: "Klientet",
                newName: "Client");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Klientet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Klientet",
                table: "Klientet",
                column: "id");
        }
    }
}
