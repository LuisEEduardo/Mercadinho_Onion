using Mercadinho.Domain.Repositories;
using Mercearia.Models.VendaContext;

namespace Mercadinho.Data.Repositories
{
    public class ItemCarrinhoRepositorio : BaseRepositorio<ItemCarrinho>, IItemCarrinhoRepositorio
    {
        public ItemCarrinhoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}
