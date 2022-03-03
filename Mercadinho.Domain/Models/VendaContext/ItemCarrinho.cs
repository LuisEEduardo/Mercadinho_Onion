using Mercearia.Models.SharedContext;

namespace Mercearia.Models.VendaContext
{
    public class ItemCarrinho : Base
    {
        private ItemCarrinho(Produto produto, int qtd)
            : base()
        {
            Produto = produto;
            Qtd = qtd;
        }

        public ItemCarrinho CriarCarrinho(Produto produto, int qtd)
        {
            var itemCarrinho = new ItemCarrinho(produto, qtd);
            return itemCarrinho;
        }

        public Produto Produto { get; private set; }
        public int ProdutoId { get; private set; }
        public CarrinhoDeCompras CarrinhoDeCompras { get; private set; }
        public int CarrinhoDeComprasId { get; private set; }
        public int Qtd { get; private set; }
        
        public double ValorTotalItem()
        {
            return Qtd * Produto.Preco;
        }

        public void AddQtdProduto(int qtd)
        {
            if (qtd > 0)
            {
                Qtd += qtd;
            }
        }

        public void RemoveQtdProduto(int qtd)
        {
            if (qtd > 0)
            {
                Qtd -= qtd;
            }
        }
    }
}