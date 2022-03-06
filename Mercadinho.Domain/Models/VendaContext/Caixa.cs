using System.Collections.Generic;
using System.Linq;
using Mercearia.Models.SharedContext;

namespace Mercearia.Models.VendaContext
{
    public class Caixa : Base
    {
        private IList<CarrinhoDeCompras> _carrinhoDeCompras;

        private Caixa()
        {
            _carrinhoDeCompras = new List<CarrinhoDeCompras>();
        }

        public static Caixa CriarCaixa()
        {
            return new Caixa();
        }

        public IList<CarrinhoDeCompras> CarrinhosDeCompras { get { return _carrinhoDeCompras.ToArray(); } }
        public bool CompraRealizada { get; private set; }

        public double ValorTotal()
        {
            double valorTotal = 0.0;
            foreach (var carrinho in _carrinhoDeCompras)
                valorTotal += carrinho.CalcularValorDoCarrinho();

            return valorTotal;
        }

        public double CalcularValorTroco(double pagamento)
        {
            double valorTotal = ValorTotal();
            if (pagamento > 0 && pagamento >= valorTotal)
                return valorTotal - pagamento;

            return 0;
        }

        public void AddCarrinho(CarrinhoDeCompras carrinhoDeCompras)
        {
            if (carrinhoDeCompras is not null)
                _carrinhoDeCompras.Add(carrinhoDeCompras);
        }

        public void RemoveCarrinho(CarrinhoDeCompras carrinhoDeCompras)
        {
            if (carrinhoDeCompras is not null)
                _carrinhoDeCompras.Remove(carrinhoDeCompras);
        }

        public void CancelarCompra()
        {
            _carrinhoDeCompras.Clear();
            CompraRealizada = false;
        }

        public void EfetivarCompra()
            => CompraRealizada = true;
    }
}