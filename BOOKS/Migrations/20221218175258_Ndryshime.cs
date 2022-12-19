using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOOKS.Migrations
{
    public partial class Ndryshime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Klienti_id",
                table: "Pagesa",
                newName: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagesa_ClientId",
                table: "Pagesa",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagesa_Clients_ClientId",
                table: "Pagesa",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagesa_Clients_ClientId",
                table: "Pagesa");

            migrationBuilder.DropIndex(
                name: "IX_Pagesa_ClientId",
                table: "Pagesa");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Pagesa",
                newName: "Klienti_id");
        }
    }
}
