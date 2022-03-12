using Mercadinho.Domain.Repositories;
using Mercearia.Models.VendaContext;

namespace Mercadinho.Data.Repositories
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}
