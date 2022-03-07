using Mercadinho.Domain.Repositories;
using Mercearia.Models.VendaContext;

namespace Mercadinho.Data.Repositories
{
    public class CaixaRepositorio : BaseRepositorio<Caixa>, ICaixaRepositorio
    {
        public CaixaRepositorio(Contexto contexto) 
            : base(contexto)
        {
        }
    }
}