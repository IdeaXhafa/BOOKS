using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOOKS.Migrations
{
    public partial class SomeChangesDiqka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagesa_Clients_ClientId",
                table: "Pagesa");

            migrationBuilder.DropIndex(
                name: "IX_Pagesa_ClientId",
                table: "Pagesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Klientet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Klientet",
                table: "Klientet",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Klientet",
                table: "Klientet");

            migrationBuilder.RenameTable(
                name: "Klientet",
                newName: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "id");

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
    }
}
