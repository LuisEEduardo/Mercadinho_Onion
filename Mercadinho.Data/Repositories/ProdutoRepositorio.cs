using Mercadinho.Domain.Repositories;
using Mercearia.Models.VendaContext;
using System.Linq;

namespace Mercadinho.Data.Repositories
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(Contexto contexto) : base(contexto)
        {
        }

        public Produto SelecionarPorNome(string nome)
            => _contexto.Set<Produto>()
                .Where(x => x.Nome == nome)
                .FirstOrDefault();

    }
}
