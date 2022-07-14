using Mercadinho.Application.ViewModel;
using System.Collections.Generic;

namespace Mercadinho.Application.Interface
{
    public interface IPedidoAplicacao
    {
        void Incluir(PedidoViewModel entidade);
        IEnumerable<PedidoViewModel> SelecionarTodos();
        PedidoViewModel SelecionarPorId(int id);
        void Excluir(int id);
        void Atualizar(PedidoViewModel entidade);
    }
}
