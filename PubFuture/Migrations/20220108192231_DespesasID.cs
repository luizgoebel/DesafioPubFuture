using Microsoft.EntityFrameworkCore.Migrations;

namespace PubFuture.Migrations
{
    public partial class DespesasID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conta",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "Conta",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Despesas");

            migrationBuilder.RenameColumn(
                name: "DataRecebimentoEsperado",
                table: "Despesas",
                newName: "DataPagamentoEsperado");

            migrationBuilder.RenameColumn(
                name: "DataRecebimento",
                table: "Despesas",
                newName: "DataPagamento");

            migrationBuilder.AddColumn<int>(
                name: "ContaID",
                table: "Receitas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdConta",
                table: "Receitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContaID",
                table: "Despesas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdConta",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TipoConta",
                table: "Contas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstituicaoFinanceira",
                table: "Contas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_ContaID",
                table: "Receitas",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_ContaID",
                table: "Despesas",
                column: "ContaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Contas_ContaID",
                table: "Despesas",
                column: "ContaID",
                principalTable: "Contas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Contas_ContaID",
                table: "Receitas",
                column: "ContaID",
                principalTable: "Contas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Contas_ContaID",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Contas_ContaID",
                table: "Receitas");

            migrationBuilder.DropIndex(
                name: "IX_Receitas_ContaID",
                table: "Receitas");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_ContaID",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "ContaID",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "ContaID",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "Despesas");

            migrationBuilder.RenameColumn(
                name: "DataPagamentoEsperado",
                table: "Despesas",
                newName: "DataRecebimentoEsperado");

            migrationBuilder.RenameColumn(
                name: "DataPagamento",
                table: "Despesas",
                newName: "DataRecebimento");

            migrationBuilder.AddColumn<string>(
                name: "Conta",
                table: "Receitas",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Conta",
                table: "Despesas",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Despesas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoConta",
                table: "Contas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InstituicaoFinanceira",
                table: "Contas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
