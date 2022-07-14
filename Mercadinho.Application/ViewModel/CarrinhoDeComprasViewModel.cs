using Mercadinho.Domain.Models.VendaContext.Enums;

namespace Mercadinho.Application.ViewModel
{
    public class CarrinhoDeComprasViewModel
    {
        public int Id { get; set; }
        public decimal ValorTotalCarrinho { get; set; }
        public EStatusCompra StatusCompra { get; set; }
    }
}
