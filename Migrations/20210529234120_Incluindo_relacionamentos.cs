using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCadFilmes.Migrations
{
    public partial class Incluindo_relacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Filmes");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Generos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Generos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Filmes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Filmes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Filmes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_GeneroId",
                table: "Filmes",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Generos_GeneroId",
                table: "Filmes",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Generos_GeneroId",
                table: "Filmes");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_GeneroId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Filmes");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Generos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Ativo",
                table: "Generos",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Filmes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "Ativo",
                table: "Filmes",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Filmes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Ativo", "DataCriacao", "Genero", "LocacaoId", "Nome" },
                values: new object[] { 1, 1, new DateTime(2021, 5, 27, 23, 11, 37, 481, DateTimeKind.Local).AddTicks(3601), "Ação", null, "Filme teste" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Ativo", "DataCriacao", "Nome" },
                values: new object[] { 1, 1, new DateTime(2021, 5, 27, 23, 11, 37, 484, DateTimeKind.Local).AddTicks(1205), "teste" });
        }
    }
}
