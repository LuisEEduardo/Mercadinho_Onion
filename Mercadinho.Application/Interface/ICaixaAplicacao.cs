using Mercadinho.Application.ViewModel;
using System.Collections.Generic;

namespace Mercadinho.Application.Interface
{
    public interface ICaixaAplicacao
    {
        void Incluir(CaixaViewModel entidade);
        IEnumerable<CaixaViewModel> SelecionarTodos();
        CaixaViewModel SelecionarPorId(int id);
        void Excluir(int id);
        void Atualizar(CaixaViewModel entidade);
    }
}
