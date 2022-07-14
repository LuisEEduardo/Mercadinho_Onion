using Mercadinho.Domain.Models.VendaContext;
using Mercadinho.Domain.Repositories;

namespace Mercadinho.Data.Repositories
{
    public class PedidoRepositorio : BaseRepositorio<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(Contexto contexto)
            : base(contexto)
        {
        }

    }
}
