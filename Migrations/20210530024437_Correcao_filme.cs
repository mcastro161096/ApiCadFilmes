using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCadFilmes.Migrations
{
    public partial class Correcao_filme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Generos_GeneroId",
                table: "Filmes");

            migrationBuilder.AlterColumn<int>(
                name: "GeneroId",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Generos_GeneroId",
                table: "Filmes",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Generos_GeneroId",
                table: "Filmes");

            migrationBuilder.AlterColumn<int>(
                name: "GeneroId",
                table: "Filmes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Generos_GeneroId",
                table: "Filmes",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
