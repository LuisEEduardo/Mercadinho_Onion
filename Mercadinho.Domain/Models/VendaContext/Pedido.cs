using Mercadinho.Domain.Models.VendaContext.Enums;
using Mercearia.Models.SharedContext;
using Mercearia.Models.VendaContext;
using System;

namespace Mercadinho.Domain.Models.VendaContext
{
    public class Pedido : Base
    {
        public static Pedido CriarPedido(
            int carrinhoId,
            DateTime dataDaCompra,
            decimal valorTotal,
            EFormaCompra formaPagamento,
            bool pagamentoConfirmado)
        {
            var pedido = new Pedido
            {
                CarrinhoId = carrinhoId,
                DataDaCompra = dataDaCompra,
                ValorTotal = valorTotal,
                FormaPagamento = formaPagamento,
                PagamentoConfirmado = pagamentoConfirmado
            };

            return pedido;
        }

        public int CarrinhoId { get; private set; }
        public CarrinhoDeCompras CarrinhoDeCompras { get; private set; }
        public DateTime DataDaCompra { get; private set; }
        public decimal ValorTotal { get; private set; }
        public EFormaCompra FormaPagamento { get; private set; }
        public bool PagamentoConfirmado { get; private set; }

        public void StatusPagamento(bool status)
        {
            PagamentoConfirmado = status;
        }

    }
}