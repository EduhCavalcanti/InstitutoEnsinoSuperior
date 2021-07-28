using Microsoft.EntityFrameworkCore.Migrations;

namespace InstitutoEnsinoSuperior.Migrations
{
    public partial class EntidadeAtualizada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Instituições_InstituicaoId",
                table: "Departamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instituições",
                table: "Instituições");

            migrationBuilder.RenameTable(
                name: "Instituições",
                newName: "Instituicoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instituicoes",
                table: "Instituicoes",
                column: "InstituicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Instituicoes_InstituicaoId",
                table: "Departamentos",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "InstituicaoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Instituicoes_InstituicaoId",
                table: "Departamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instituicoes",
                table: "Instituicoes");

            migrationBuilder.RenameTable(
                name: "Instituicoes",
                newName: "Instituições");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instituições",
                table: "Instituições",
                column: "InstituicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Instituições_InstituicaoId",
                table: "Departamentos",
                column: "InstituicaoId",
                principalTable: "Instituições",
                principalColumn: "InstituicaoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
