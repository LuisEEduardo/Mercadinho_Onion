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

        public Produto GetByName(string nome)
            => _contexto.Set<Produto>().FirstOrDefault(x => x.Nome == nome);
    }
}
