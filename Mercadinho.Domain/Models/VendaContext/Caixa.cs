using System.Collections.Generic;
using Mercearia.Models.SharedContext;

namespace Mercearia.Models.VendaContext
{
    public class Caixa : Base
    {
        public Caixa()
        {
            CarrinhosDeCompras = new List<CarrinhoDeCompras>();
        }

        public IList<CarrinhoDeCompras> CarrinhosDeCompras { get; set; }
        public double Troco { get; set; }

        public double ValorTotal()
        {
            double valorTotal = 0.0;
            foreach (var carrinho in CarrinhosDeCompras)
            {
                valorTotal += carrinho.ValorCarrinho();
            }

            return valorTotal;
        }

        public void AddCarrinho(CarrinhoDeCompras carrinhoDeCompras)
        {
            CarrinhosDeCompras.Add(carrinhoDeCompras);
        }

        public void RemoveCarrinho(CarrinhoDeCompras carrinhoDeCompras)
        {
            CarrinhosDeCompras.Remove(carrinhoDeCompras);
        }
    }
}