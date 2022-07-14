using Mercadinho.Domain.Models.VendaContext.Enums;
using System;

namespace Mercadinho.Application.ViewModel
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public int CarrinhoId { get; set; }
        // public CarrinhoDeCompras CarrinhoDeCompras { get; set; }
        public DateTime DataDaCompra { get; set; }
        public decimal ValorTotal { get; set; }
        public EFormaCompra FormaPagamento { get; set; }
        public bool PagamentoConfirmado { get; set; }
    }
}
