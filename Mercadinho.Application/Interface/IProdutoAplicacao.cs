using Mercadinho.Application.ViewModel;
using System.Collections.Generic;

namespace Mercadinho.Application.Interface
{
    public interface IProdutoAplicacao
    {
        void Incluir(ProdutoViewModel entidade);
        IEnumerable<ProdutoViewModel> SelecionarTodos();
    }
}
