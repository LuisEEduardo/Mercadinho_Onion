using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercadinho.Data.Migrations
{
    public partial class AtualizandoSchemasDasTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caixa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraRealizada = table.Column<bool>(type: "Bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Preco = table.Column<decimal>(type: "Decimal(38,17)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoDeCompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorTotalCarrinho = table.Column<decimal>(type: "Decimal(38,17)", nullable: false),
                    CaixaId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoDeCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoDeCompras_Caixa_CaixaId",
                        column: x => x.CaixaId,
                        principalTable: "Caixa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCarrinho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "INT", nullable: false),
                    CarrinhoDeComprasId = table.Column<int>(type: "INT", nullable: false),
                    Qtd = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCarrinho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCarrinho_CarrinhoDeCompras_CarrinhoDeComprasId",
                        column: x => x.CarrinhoDeComprasId,
                        principalTable: "CarrinhoDeCompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCarrinho_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoDeCompras_CaixaId",
                table: "CarrinhoDeCompras",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinho_CarrinhoDeComprasId",
                table: "ItemCarrinho",
                column: "CarrinhoDeComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinho_ProdutoId",
                table: "ItemCarrinho",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCarrinho");

            migrationBuilder.DropTable(
                name: "CarrinhoDeCompras");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Caixa");
        }
    }
}
