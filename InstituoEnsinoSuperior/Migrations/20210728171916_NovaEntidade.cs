using Microsoft.EntityFrameworkCore.Migrations;

namespace InstitutoEnsinoSuperior.Migrations
{
    public partial class NovaEntidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Instituições",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Departamentos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InstituicaoId",
                table: "Departamentos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_InstituicaoId",
                table: "Departamentos",
                column: "InstituicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Instituições_InstituicaoId",
                table: "Departamentos",
                column: "InstituicaoId",
                principalTable: "Instituições",
                principalColumn: "InstituicaoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Instituições_InstituicaoId",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_InstituicaoId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "InstituicaoId",
                table: "Departamentos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Instituições",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Departamentos",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
