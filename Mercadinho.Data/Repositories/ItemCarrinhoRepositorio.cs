using Mercadinho.Domain.Repositories;
using Mercearia.Models.VendaContext;

namespace Mercadinho.Data.Repositories
{
    internal class ItemCarrinhoRepositorio : BaseRepositorio<ItemCarrinho>, IItemCarrinhoRepositorio
    {
        public ItemCarrinhoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}
