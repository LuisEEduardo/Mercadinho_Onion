using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercadinho.Data.Migrations
{
    public partial class AddClassPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoDeCompras_Caixa_CaixaId",
                table: "CarrinhoDeCompras");

            migrationBuilder.DropTable(
                name: "Caixa");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhoDeCompras_CaixaId",
                table: "CarrinhoDeCompras");

            migrationBuilder.DropColumn(
                name: "CaixaId",
                table: "CarrinhoDeCompras");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrinhoId = table.Column<int>(type: "INT", nullable: false),
                    DataDaCompra = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "Decimal", nullable: false),
                    FormaPagamento = table.Column<int>(type: "INT", nullable: false),
                    PagamentoConfirmado = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_CarrinhoDeCompras_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "CarrinhoDeCompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CarrinhoId",
                table: "Pedido",
                column: "CarrinhoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "CaixaId",
                table: "CarrinhoDeCompras",
                type: "INT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Caixa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoDeCompras_CaixaId",
                table: "CarrinhoDeCompras",
                column: "CaixaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoDeCompras_Caixa_CaixaId",
                table: "CarrinhoDeCompras",
                column: "CaixaId",
                principalTable: "Caixa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
