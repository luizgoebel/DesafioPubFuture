using Microsoft.EntityFrameworkCore.Migrations;

namespace PubFuture.Migrations
{
    public partial class NomeDBalteradoContaID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Contas_ContaID",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "Receitas");

            migrationBuilder.AlterColumn<int>(
                name: "ContaID",
                table: "Receitas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Contas_ContaID",
                table: "Receitas",
                column: "ContaID",
                principalTable: "Contas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Contas_ContaID",
                table: "Receitas");

            migrationBuilder.AlterColumn<int>(
                name: "ContaID",
                table: "Receitas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdConta",
                table: "Receitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Contas_ContaID",
                table: "Receitas",
                column: "ContaID",
                principalTable: "Contas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
