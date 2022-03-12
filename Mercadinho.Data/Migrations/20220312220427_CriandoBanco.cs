using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercadinho.Data.Migrations
{
    public partial class CriandoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhoDeCompras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorTotalCarrinho = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoDeCompras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Preco = table.Column<decimal>(type: "Decimal(38,17)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCarrinho",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId1 = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    CarrinhoDeComprasId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CarrinhoDeComprasId = table.Column<int>(type: "int", nullable: false),
                    Qtd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCarrinho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCarrinho_CarrinhoDeCompras_CarrinhoDeComprasId1",
                        column: x => x.CarrinhoDeComprasId1,
                        principalTable: "CarrinhoDeCompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCarrinho_Produto_ProdutoId1",
                        column: x => x.ProdutoId1,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinho_CarrinhoDeComprasId1",
                table: "ItemCarrinho",
                column: "CarrinhoDeComprasId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinho_ProdutoId1",
                table: "ItemCarrinho",
                column: "ProdutoId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCarrinho");

            migrationBuilder.DropTable(
                name: "CarrinhoDeCompras");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
