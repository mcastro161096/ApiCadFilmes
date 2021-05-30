using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCadFilmes.Migrations
{
    public partial class Correcao_filme_locacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Locacoes_LocacaoId",
                table: "Filmes");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_LocacaoId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                table: "Filmes");

            migrationBuilder.AlterColumn<string>(
                name: "CpfCliente",
                table: "Locacoes",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FilmeLocacao",
                columns: table => new
                {
                    FilmesId = table.Column<int>(type: "int", nullable: false),
                    LocacoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeLocacao", x => new { x.FilmesId, x.LocacoesId });
                    table.ForeignKey(
                        name: "FK_FilmeLocacao_Filmes_FilmesId",
                        column: x => x.FilmesId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmeLocacao_Locacoes_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "Locacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmeLocacao_LocacoesId",
                table: "FilmeLocacao",
                column: "LocacoesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmeLocacao");

            migrationBuilder.AlterColumn<string>(
                name: "CpfCliente",
                table: "Locacoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AddColumn<int>(
                name: "LocacaoId",
                table: "Filmes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_LocacaoId",
                table: "Filmes",
                column: "LocacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Locacoes_LocacaoId",
                table: "Filmes",
                column: "LocacaoId",
                principalTable: "Locacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
