using System.Collections.Generic;
using System.Linq;
using Mercearia.Models.SharedContext;

namespace Mercearia.Models.VendaContext
{
    public class CarrinhoDeCompras : Base
    {
        private CarrinhoDeCompras()
        {
            Itens = new List<ItemCarrinho>();
        }

        public CarrinhoDeCompras CriarCarrinhoDeCompras()
        {
            var carrinhoDeCompras = new CarrinhoDeCompras();
            return carrinhoDeCompras;
        }

        public IList<ItemCarrinho> Itens { get; private set; }
        public double ValorTotalCarrinho { get; set; }

        public double CalcularValorDoCarrinho()
        {        
            double valorTotal = 0; 
            foreach (var item in Itens)
                valorTotal += item.ValorTotalItem(); 

            return valorTotal;
        }

        public void AddItens(ItemCarrinho item)
        {
            var itemDoCarrinho = Itens.FirstOrDefault(i => i.Produto.Nome == item.Produto.Nome);

            if (itemDoCarrinho is null)
                Itens.Add(item);
            else
            {
                itemDoCarrinho.AddQtdProduto(item.Qtd);
                RemoveItemDaLista(item);
                Itens.Add(itemDoCarrinho);
            }
        }

        public void RemoveItemDaLista(ItemCarrinho item)
        {
            Itens.Remove(item);
        }

        public void LimparCarrinho()
        {
            Itens.Clear();
        }

         public void AddQtdDoItens(string nome, int qtd)
        {
            foreach (var item in Itens.Where(item => item.Produto.Nome == nome))
                item.AddQtdProduto(qtd); 
        }

        public void DiminuirQtdDoItem(string nome, int qtd)
        {
            foreach (var item in Itens.Where(item => item.Produto.Nome == nome))
                item.RemoveQtdProduto(qtd); 
        }

    }
}