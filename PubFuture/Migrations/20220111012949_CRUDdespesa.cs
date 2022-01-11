using Microsoft.EntityFrameworkCore.Migrations;

namespace PubFuture.Migrations
{
    public partial class CRUDdespesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Contas_ContaID",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "Despesas");

            migrationBuilder.AlterColumn<int>(
                name: "ContaID",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Contas_ContaID",
                table: "Despesas",
                column: "ContaID",
                principalTable: "Contas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Contas_ContaID",
                table: "Despesas");

            migrationBuilder.AlterColumn<int>(
                name: "ContaID",
                table: "Despesas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdConta",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Contas_ContaID",
                table: "Despesas",
                column: "ContaID",
                principalTable: "Contas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
