using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercadinho.Data.Migrations
{
    public partial class AddPropriedade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompraRealizada",
                table: "Caixa");

            migrationBuilder.AddColumn<int>(
                name: "StatusDaCompra",
                table: "CarrinhoDeCompras",
                type: "INT",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusDaCompra",
                table: "CarrinhoDeCompras");

            migrationBuilder.AddColumn<bool>(
                name: "CompraRealizada",
                table: "Caixa",
                type: "Bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
