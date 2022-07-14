using System.Collections.Generic;
using System.Linq;
using Mercadinho.Domain.Models.VendaContext;
using Mercadinho.Domain.Models.VendaContext.Enums;
using Mercearia.Models.SharedContext;

namespace Mercearia.Models.VendaContext
{
    public class CarrinhoDeCompras : Base
    {
        private IList<ItemCarrinho> _itens;

        private CarrinhoDeCompras()
        {
            _itens = new List<ItemCarrinho>();
        }

        public static CarrinhoDeCompras CriarCarrinhoDeCompras()
        {
            var carrinhoDeCompras = new CarrinhoDeCompras
            {
                StatusDaCompra = EStatusCompra.EmAndamento
            };

            return carrinhoDeCompras;
        }

        public IReadOnlyCollection<ItemCarrinho> Itens { get { return _itens.ToArray(); } }
        public double ValorTotalCarrinho { get; private set; }
        public EStatusCompra StatusDaCompra { get; set; }
        public Pedido Pedido { get; private set; }

        public double CalcularValorDoCarrinho()
        {
            double valorTotal = 0;
            foreach (var item in _itens)
                valorTotal += item.ValorTotalItem();

            ValorTotalCarrinho = valorTotal;
            return valorTotal;
        }

        public void AddItens(ItemCarrinho item)
        {
            var itemDoCarrinho = _itens.FirstOrDefault(i => i.Produto.Nome == item.Produto.Nome);

            if (itemDoCarrinho is null)
                _itens.Add(item);
            else
            {
                itemDoCarrinho.AddQtdProduto(item.Qtd);
                RemoveItemDaLista(item);
                _itens.Add(itemDoCarrinho);
            }
        }

        public void RemoveItemDaLista(ItemCarrinho item)
        {
            _itens.Remove(item);
        }

        public void LimparCarrinho()
        {
            _itens.Clear();
        }

        public void AddQtdDoItens(string nome, int qtd)
        {
            foreach (var item in _itens.Where(item => item.Produto.Nome == nome))
                item.AddQtdProduto(qtd);
        }

        public void DiminuirQtdDoItem(string nome, int qtd)
        {
            foreach (var item in _itens.Where(item => item.Produto.Nome == nome))
                item.RemoveQtdProduto(qtd);
        }

        public void FinalizarCompra()
        {
            StatusDaCompra = EStatusCompra.Finalizada;
        }

        public void CancelarCompra()
        {
            StatusDaCompra = EStatusCompra.Cancelada;
        }

    }
}