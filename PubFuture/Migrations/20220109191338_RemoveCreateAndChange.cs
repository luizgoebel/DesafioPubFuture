using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PubFuture.Migrations
{
    public partial class RemoveCreateAndChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Change",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "Create",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "Change",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "Create",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "Change",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Create",
                table: "Contas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Change",
                table: "Receitas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Create",
                table: "Receitas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Change",
                table: "Despesas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Create",
                table: "Despesas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Change",
                table: "Contas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Create",
                table: "Contas",
                type: "datetime2",
                nullable: true);
        }
    }
}
